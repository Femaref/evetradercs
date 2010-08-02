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


        public Wallets CurrentWallet
        {
            get { return iCurrentWallet; }
        }
        public SmartObservableCollection<Wallets> CurrentWallets { get; set; }
        private object iCurrentWalletLocker = new object();

        public SmartObservableCollection<Journal> JournalEntries { get; set; }

        private void RefreshCurrentWallets()
        {
            CurrentWallets.Clear();
            CurrentWallets.AddRange(iModel.Wallets);
        }
        void view_EntitySelectionChanged(object sender, EntitySelectionChangedEventArgs<Wallets> e)
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

        [ImportingConstructor]
        public JournalViewModel(IJournalView view, TraderModel tm, ISettingsProvider settings)
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

        public void Refresh()
        {
            JournalEntries.Clear();

            Action a = () =>
                {
                    lock (iCurrentWalletLocker)
                    {
                        var cache = CurrentWallet.Journal
                            .Where(j => j.DateTime > (DateTime.UtcNow - iSettings.JournalTimeframe))
                            .OrderByDescending(j => j.DateTime);
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
    }
}