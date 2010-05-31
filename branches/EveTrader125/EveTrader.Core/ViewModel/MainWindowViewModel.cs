using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Waf.Applications;
using EveTrader.Core.View;
using System.ComponentModel.Composition;
using System.ComponentModel;
using System.Windows.Input;

namespace EveTrader.Core.ViewModel
{
    [Export]
    public class MainWindowViewModel : ViewModel<IMainWindowView>
    {
        private readonly ICommand iOpenManageAccountsCommand;

        private object iDashboardView;
        private object iWalletsView;
        private object iMarketOrdersView;

        public ICommand OpenManageAccountsCommand
        {
            get { return iOpenManageAccountsCommand; }
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

        [ImportingConstructor]
        public MainWindowViewModel(IMainWindowView view): base(view)
        {
            view.Closing += ViewClosing;

            iOpenManageAccountsCommand = new DelegateCommand(OpenManageAccounts);
        }
        public void Show()
        {
            this.ViewCore.Show();
        }
        public event CancelEventHandler Closing;
        private object iApplicationLogView;
        protected virtual void OnClosing(CancelEventArgs e)
        {
            if (Closing != null) { Closing(this, e); }
        }
        private void ViewClosing(object sender, CancelEventArgs e)
        {
            OnClosing(e);
        }



        
    }
}
