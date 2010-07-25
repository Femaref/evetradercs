using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Waf.Applications;
using EveTrader.Core.View;
using System.ComponentModel.Composition;
using System.ComponentModel;
using System.Windows.Input;
using EveTrader.Core.Model;

namespace EveTrader.Core.ViewModel
{
    [Export]
    public class MainWindowViewModel : ViewModel<IMainWindowView>
    {
        private readonly ICommand iOpenManageAccountsCommand;
        private readonly ICommand iRegeneratePriceCache;

        private object iDashboardView;
        private object iWalletsView;
        private object iMarketOrdersView;

        public ICommand OpenManageAccountsCommand
        {
            get { return iOpenManageAccountsCommand; }
        }

        public ICommand RegeneratePriceCacheCommand
        {
            get { return iRegeneratePriceCache; }
        }
        private void OpenManageAccounts()
        {
            EventHandler handler = ManageAccountsClicked;
            if (handler != null)
                handler(this, new EventArgs());
        }

        public object DashboardView
        {
            get { return iDashboardView; }
            set
            {
                iDashboardView = value;
                RaisePropertyChanged("DashboardView");
            }
        }
        public object WalletsView
        {
            get { return iWalletsView; }
            set
            {
                iWalletsView = value;
                RaisePropertyChanged("WalletsView");
            }
        }

        public object PriceCacheView
        {
            get { return iPriceCache; }
            set
            {
                iPriceCache = value;
                RaisePropertyChanged("PriceCacheView");
            }
        }

        public object MarketOrdersView
        {
            get { return iMarketOrdersView; }
            set
            {
                iMarketOrdersView = value;
                RaisePropertyChanged("MarketOrdersView");
            }
        }
        public object ApplicationLogView
        {
            get { return iApplicationLogView; }
            set
            {
                iApplicationLogView = value;
                RaisePropertyChanged("ApplicationLogView");
            }
        }

        public event EventHandler ManageAccountsClicked;

        private readonly TraderModel iModel;

        [ImportingConstructor]
        public MainWindowViewModel(IMainWindowView view, TraderModel tm): base(view)
        {
            view.Closing += ViewClosing;

            iModel = tm;

            iOpenManageAccountsCommand = new DelegateCommand(OpenManageAccounts);
            iRegeneratePriceCache = new DelegateCommand(() => iModel.RegeneratePriceCache());
        }
        public void Show()
        {
            this.ViewCore.Show();
        }
        public event CancelEventHandler Closing;
        private object iApplicationLogView;
        private object iPriceCache;
        private object iTransactionsView;
        private  object iJournalView;

        protected virtual void OnClosing(CancelEventArgs e)
        {
            if (Closing != null) { Closing(this, e); }
        }
        private void ViewClosing(object sender, CancelEventArgs e)
        {
            OnClosing(e);
        }





        public object TransactionsView
        {
            get { return iTransactionsView; }
            set
            {
                iTransactionsView = value;
                RaisePropertyChanged("TransactionsView");
            }
        }

        public object JournalView
        {
            get
            {
                return iJournalView;
            }
            set
            {
                iJournalView = value;
                RaisePropertyChanged("JournalView");
            }
        }
    }
}
