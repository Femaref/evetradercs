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

        private Wallets iCurrentWallet;
        private ISettingsProvider iSettings;

        public Wallets CurrentWallet
        {
            get { return iCurrentWallet; }
        }
        public SmartObservableCollection<Wallets> CurrentWallets { get; set; }
        private object iCurrentWalletLocker = new object();

        public SmartObservableCollection<Transactions> Transactions { get; set; }

        private void RefreshCurrentWallets()
        {
            CurrentWallets.Clear();
            CurrentWallets.AddRange(iModel.Wallets);
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

        void ViewCore_EntitySelectionChanged(object sender, EntitySelectionChangedEventArgs<Wallets> e)
        {
            Action a = () =>
            {
                SelectWallet(e.Selection);
            };

            Thread t = new Thread(new ThreadStart(a));
            t.Start();
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

        public void Refresh()
        {
            Transactions.Clear();

            Action a = () =>
            {
                lock (iCurrentWalletLocker)
                {
                    var cache = CurrentWallet.Transactions
                        .Where(j => j.DateTime > (DateTime.UtcNow - iSettings.TransactionTimeframe))
                        .OrderByDescending(j => j.DateTime);
                    Transactions.AddRange(cache);
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
    }
}
