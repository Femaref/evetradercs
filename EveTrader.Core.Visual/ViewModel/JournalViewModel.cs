using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Waf.Applications;
using EveTrader.Core.View;
using System.ComponentModel.Composition;
using EveTrader.Core.Model.Trader;
using System.Collections.ObjectModel;
using MoreLinq;
using System.Threading;
using System.Data.Objects.SqlClient;
using EveTrader.Core.Collections.ObjectModel;
using System.Windows.Input;
using EveTrader.Core.Model;


namespace EveTrader.Core.ViewModel
{
    [Export]
    public class JournalViewModel : ViewModel<IJournalView>, IRefreshableViewModel
    {
        private readonly TraderModel iModel;

        private Wallets iCurrentWallet;
        private ISettingsProvider iSettings;

        private object iCurrentWalletLocker = new object();
        private bool iUpdating;
        private bool iLoaded;

        public SmartObservableCollection<Wallets> CurrentWallets { get; private set; }
        public Sheva.Windows.Data.BindableCollection<DisplayJournal> JournalEntries { get; private set; }

        public Wallets CurrentWallet
        {
            get { return iCurrentWallet; }
        }
        public bool ApplyStartFilter
        {
            get
            {
                return iSettings.JournalApplyStartFilter;
            }
            set
            {
                iSettings.JournalApplyStartFilter = value;
                RaisePropertyChanged("ApplyStartFilter");
            }
        }
        public bool ApplyEndFilter
        {
            get
            {
                return iSettings.JournalApplyEndFilter;
            }
            set
            {
                iSettings.JournalApplyEndFilter = value;
                RaisePropertyChanged("ApplyEndFilter");
            }
        }
        public DateTime StartDate
        {
            get
            {
                return iSettings.JournalStartDate;
            }
            set
            {
                iSettings.JournalStartDate = value;
                RaisePropertyChanged("StartDate");
            }
        }
        public DateTime EndDate
        {
            get
            {
                return iSettings.JournalEndDate;
            }
            set
            {
                iSettings.JournalEndDate = value;
                RaisePropertyChanged("StartDate");
            }
        }
        public bool Updating
        {
            get
            {
                return iUpdating;
            }
            private set
            {
                iUpdating = value;
                RaisePropertyChanged("Updating");
            }
        }
        public ICommand LoadCommand { get; private set; }

        [ImportingConstructor]
        public JournalViewModel(IJournalView view, [Import(RequiredCreationPolicy = CreationPolicy.NonShared)] TraderModel tm, ISettingsProvider settings)
            : base(view)
        {
            iModel = tm;
            iSettings = settings;
            JournalEntries = new Sheva.Windows.Data.BindableCollection<DisplayJournal>();
            CurrentWallets = new SmartObservableCollection<Wallets>(ViewCore.BeginInvoke);
            this.ViewCore.EntitySelectionChanged += new EventHandler<EntitySelectionChangedEventArgs<Wallets>>(view_EntitySelectionChanged);
            LoadCommand = new DelegateCommand(Refresh, () => !Updating);

            RefreshCurrentWallets();
            SelectWallet(CurrentWallets.FirstOrDefault());
        }

        private void SelectWallet(Wallets w)
        {
            if (w == null)
                return;

            lock (iCurrentWalletLocker)
            {
                iCurrentWallet = w;
                RaisePropertyChanged("CurrentWallet");
            }
        }
        private void RefreshCurrentWallets()
        {
            CurrentWallets.Clear();
            CurrentWallets.AddRange(iModel.Wallets);
        }
        public void Refresh()
        {
            Thread t = new Thread(new ThreadStart(this.ThreadedRefresh));
            t.Name = "JournalRefresh";
            t.Start();
        }
        private void ThreadedRefresh()
        {
            lock (iCurrentWalletLocker)
            {
                iLoaded = true;
                Updating = true;
                JournalEntries.Clear();

                Func<Journal, bool> filter = (j) => true;
                if (ApplyStartFilter && ApplyEndFilter)
                    filter = (j) => j.Date >= StartDate && j.Date <= EndDate;
                else if (ApplyStartFilter)
                    filter = (j) => j.Date >= StartDate;
                else
                    filter = (j) => j.Date <= EndDate;

                var cache = CurrentWallet.Journal
                    .Where(filter)
                    .OrderByDescending(j => j.DateTime).ToList();

                JournalEntries.AddRange(AutoMapper.Mapper.Map<IEnumerable<Journal>, IEnumerable<DisplayJournal>>(cache));
                Updating = false;
            }
        }

        public void DataIncoming(object sender, Services.EntitiesUpdatedEventArgs e)
        {
            RefreshCurrentWallets();

            if (CurrentWallet != null && e.UpdatedEntities.Any(en => en.Name == CurrentWallet.Entity.Name) && iLoaded)
                Refresh();
        }
        private void view_EntitySelectionChanged(object sender, EntitySelectionChangedEventArgs<Wallets> e)
        {
            Action a = () =>
            {
                SelectWallet(e.Selection);
            };

            Thread t = new Thread(new ThreadStart(a));
            t.Name = "SelectJournalWallet";
            t.Start();
        }
    }
}