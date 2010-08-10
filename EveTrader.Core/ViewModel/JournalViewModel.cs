using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Waf.Applications;
using EveTrader.Core.View;
using System.ComponentModel.Composition;
using EveTrader.Core.Model;
using System.Collections.ObjectModel;
using MoreLinq;
using System.Threading;
using System.Data.Objects.SqlClient;
using EveTrader.Core.Collections.ObjectModel;

namespace EveTrader.Core.ViewModel
{
    [Export]
    public class JournalViewModel : ViewModel<IJournalView>, IRefreshableViewModel
    {
        private readonly TraderModel iModel;

        private Wallets iCurrentWallet;
        private ISettingsProvider iSettings;

        private object iCurrentWalletLocker = new object();

        public SmartObservableCollection<Wallets> CurrentWallets { get; private set; }
        public SmartObservableCollection<Journal> JournalEntries { get; private set; }

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
                Refresh();
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
                Refresh();
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
                if (ApplyStartFilter)
                    Refresh();
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
                if (ApplyEndFilter)
                    Refresh();
            }
        }

        [ImportingConstructor]
        public JournalViewModel(IJournalView view, [Import(RequiredCreationPolicy = CreationPolicy.NonShared)] TraderModel tm, ISettingsProvider settings)
            : base(view)
        {
            iModel = tm;
            iSettings = settings;
            JournalEntries = new SmartObservableCollection<Journal>(ViewCore.BeginInvoke);
            CurrentWallets = new SmartObservableCollection<Wallets>(ViewCore.BeginInvoke);
            this.ViewCore.EntitySelectionChanged += new EventHandler<EntitySelectionChangedEventArgs<Wallets>>(view_EntitySelectionChanged);

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

            Refresh();
        }
        private void RefreshCurrentWallets()
        {
            CurrentWallets.Clear();
            CurrentWallets.AddRange(iModel.Wallets);
        }
        public void Refresh()
        {
            Action a = () =>
                {
                    lock (iCurrentWalletLocker)
                    {
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
                        JournalEntries.AddRange(cache);
                    }
                };

            Thread t = new Thread(new ThreadStart(a));
            t.Start();
        }

        public void DataIncoming(object sender, Controllers.EntitiesUpdatedEventArgs e)
        {
            RefreshCurrentWallets();

            if (e.UpdatedEntities.Any(en => en.Name == CurrentWallet.Entity.Name))
                Refresh();
        }
        public void view_EntitySelectionChanged(object sender, EntitySelectionChangedEventArgs<Wallets> e)
        {
            Action a = () =>
            {
                SelectWallet(e.Selection);
            };

            Thread t = new Thread(new ThreadStart(a));
            t.Start();
        }
    }
}