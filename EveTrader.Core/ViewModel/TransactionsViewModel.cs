using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EveTrader.Core.View;
using System.Waf.Applications;
using System.ComponentModel.Composition;
using EveTrader.Core.Model;
using EveTrader.Core.Collections.ObjectModel;
using System.Threading;

namespace EveTrader.Core.ViewModel
{
    [Export]
    public class TransactionsViewModel : ViewModel<ITransactionsView>, IRefreshableViewModel
    {
        private readonly TraderModel iModel;

        private object iCurrentWalletLocker = new object();

        private Wallets iCurrentWallet;
        private ISettingsProvider iSettings;

        public SmartObservableCollection<Transactions> Transactions { get; private set; }
        public SmartObservableCollection<Wallets> CurrentWallets { get; private set; }
        public Wallets CurrentWallet
        {
            get { return iCurrentWallet; }
        }
        public bool ApplyStartFilter
        {
            get
            {
                return iSettings.TransactionsApplyStartFilter;
            }
            set
            {
                iSettings.TransactionsApplyStartFilter = value;
                RaisePropertyChanged("ApplyStartFilter");
                Refresh();
            }
        }
        public bool ApplyEndFilter
        {
            get
            {
                return iSettings.TransactionsApplyEndFilter;
            }
            set
            {
                iSettings.TransactionsApplyEndFilter = value;
                RaisePropertyChanged("ApplyEndFilter");
                Refresh();
            }
        }
        public DateTime StartDate
        {
            get
            {
                return iSettings.TransactionsStartDate;
            }
            set
            {
                iSettings.TransactionsStartDate = value;
                RaisePropertyChanged("StartDate");
                if (ApplyStartFilter)
                    Refresh();
            }
        }
        public DateTime EndDate
        {
            get
            {
                return iSettings.TransactionsEndDate;
            }
            set
            {
                iSettings.TransactionsEndDate = value;
                RaisePropertyChanged("StartDate");
                if (ApplyEndFilter)
                    Refresh();
            }
        }

        [ImportingConstructor]
        public TransactionsViewModel(ITransactionsView view, [Import(RequiredCreationPolicy = CreationPolicy.NonShared)] TraderModel tm, ISettingsProvider settings)
            : base(view)
        {
            iModel = tm;
            iSettings = settings;

            CurrentWallets = new SmartObservableCollection<Wallets>(view.BeginInvoke);
            Transactions = new SmartObservableCollection<Transactions>(view.BeginInvoke);
            this.ViewCore.EntitySelectionChanged += new EventHandler<EntitySelectionChangedEventArgs<Wallets>>(ViewCore_EntitySelectionChanged);

            RefreshCurrentWallets();
            SelectWallet(CurrentWallets.FirstOrDefault());
        }

        public void Refresh()
        {
            Action a = () =>
            {
                lock (iCurrentWalletLocker)
                {
                    Transactions.Clear();
                    Func<Transactions, bool> filter = (t) => true;
                    if (ApplyStartFilter && ApplyEndFilter)
                        filter = (t) => t.Date >= StartDate && t.Date <= EndDate;
                    else if (ApplyStartFilter)
                        filter = (t) => t.Date >= StartDate;
                    else
                        filter = (t) => t.Date <= EndDate;

                    var cache = CurrentWallet.Transactions
                        .Where(filter)
                        .OrderByDescending(j => j.DateTime).ToList();
                    Transactions.AddRange(cache);
                }
            };

            Thread updaterThread = new Thread(new ThreadStart(a));
            updaterThread.Start();
        }

        private void RefreshCurrentWallets()
        {
            CurrentWallets.Clear();
            CurrentWallets.AddRange(iModel.Wallets);
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


        public void DataIncoming(object sender, Controllers.EntitiesUpdatedEventArgs e)
        {
            RefreshCurrentWallets();

            if (e.UpdatedEntities.Any(en => en.Name == CurrentWallet.Entity.Name))
                Refresh();
        }
        private void ViewCore_EntitySelectionChanged(object sender, EntitySelectionChangedEventArgs<Wallets> e)
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
