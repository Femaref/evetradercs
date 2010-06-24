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

namespace EveTrader.Core.ViewModel
{
    [Export]
    public class JournalViewModel : ViewModel<IJournalView>
    {
        private readonly TraderModel iModel;

        private Wallets iCurrentWallet;


        public Wallets CurrentWallet
        {
            get { return iCurrentWallet; }
        }
        public ObservableCollection<Wallets> CurrentWallets { get; set; }

        public ObservableCollection<Journal> JournalEntries { get; set; }

        private void RefreshCurrentWallets()
        {
            ViewCore.Invoke(() => CurrentWallets.Clear());
            iModel.Wallets.ForEach(w => ViewCore.Invoke(() => CurrentWallets.Add(w)));
        }
        void view_EntitySelectionChanged(object sender, EntitySelectionChangedEventArgs<Wallets> e)
        {
            SelectWallet(e.Selection);
        }

        private void SelectWallet(Wallets w)
        {
            iCurrentWallet = w;
            RaisePropertyChanged("CurrentWallet");

            Refresh();
        }

        [ImportingConstructor]
        public JournalViewModel(IJournalView view, TraderModel tm)
            : base(view)
        {
            iModel = tm;
            JournalEntries = new ObservableCollection<Journal>();
            CurrentWallets = new ObservableCollection<Wallets>();
            this.ViewCore.EntitySelectionChanged += new EventHandler<EntitySelectionChangedEventArgs<Wallets>>(view_EntitySelectionChanged);

            RefreshCurrentWallets();
            SelectWallet(CurrentWallets.First());
        }

        public void Refresh()
        {
            ViewCore.Invoke(() => JournalEntries.Clear());

            Action a = () =>
                {
                    List<Journal> cache = CurrentWallet.Journal.OrderByDescending(j => j.DateTime).ToList();
                    cache.ForEach(j => ViewCore.Invoke(() => JournalEntries.Add(j)));
                };

            Thread t = new Thread(new ThreadStart(a));
            t.Start();
        }
    }
}