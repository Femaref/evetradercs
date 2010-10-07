using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EveTrader.Core.View;
using System.Waf.Applications;
using System.ComponentModel.Composition;
using EveTrader.Core.Model;
using Sheva.Windows.Data;
using System.Threading;
using System.Diagnostics;

namespace EveTrader.Core.ViewModel
{
    [Export]
    public class TransactionsViewModel : ViewModel<ITransactionsView>, IRefreshableViewModel
    {
        private readonly TraderModel iModel;

        private object iCurrentWalletLocker = new object();

        private Wallets iCurrentWallet;
        private ISettingsProvider iSettings;
        private bool iUpdating;

        public BindableCollection<Transactions> Transactions { get; private set; }
        public BindableCollection<Wallets> CurrentWallets { get; private set; }
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

        [ImportingConstructor]
        public TransactionsViewModel(ITransactionsView view, [Import(RequiredCreationPolicy = CreationPolicy.NonShared)] TraderModel tm, ISettingsProvider settings)
            : base(view)
        {
            iModel = tm;
            iSettings = settings;

            CurrentWallets = new BindableCollection<Wallets>();
            Transactions = new BindableCollection<Transactions>();
            this.ViewCore.EntitySelectionChanged += new EventHandler<EntitySelectionChangedEventArgs<Wallets>>(ViewCore_EntitySelectionChanged);

            RefreshCurrentWallets();
            SelectWallet(CurrentWallets.FirstOrDefault());
        }

        public void Refresh()
        {
            Thread updaterThread = new Thread(new ThreadStart(this.ThreadedRefresh));
            updaterThread.Name = "TransactionsRefresh";
            updaterThread.Start();
        }
        private void ThreadedRefresh()
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


        public void DataIncoming(object sender, Services.EntitiesUpdatedEventArgs e)
        {
            RefreshCurrentWallets();

            if (CurrentWallet != null && e.UpdatedEntities.Any(en => en.Name == CurrentWallet.Entity.Name))
                Refresh();
        }
        private void ViewCore_EntitySelectionChanged(object sender, EntitySelectionChangedEventArgs<Wallets> e)
        {
            Action a = () =>
            {
                SelectWallet(e.Selection);
            };

            Thread t = new Thread(new ThreadStart(a));
            t.Name = "SelectTransactionWallet";
            t.Start();
        }
    }
}
