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
using EveTrader.Core.Controllers;
using System.Threading;

namespace EveTrader.Core.ViewModel
{
    [Export]
    public class MainWindowViewModel : ViewModel<IMainWindowView>
    {
        private readonly ICommand iOpenManageAccountsCommand;
        private readonly ICommand iRegeneratePriceCache;
        private readonly ICommand iFetchApiDataCommand;

        private readonly TraderModel iModel;

        private object iDashboardView;
        private object iWalletsView;
        private object iMarketOrdersView;

        private bool iUpdating = false;
        private string iUpdatingText = "";

        public ICommand OpenManageAccountsCommand
        {
            get { return iOpenManageAccountsCommand; }
        }

        public ICommand RegeneratePriceCacheCommand
        {
            get { return iRegeneratePriceCache; }
        }

        public ICommand FetchApiDataCommand
        {
            get { return iFetchApiDataCommand; }
        }

        public bool Updating
        {
            get
            {
                return iUpdating;
            }
            set
            {
                iUpdating = value;
                RaisePropertyChanged("Updating");
            }
        }
        public string UpdatingText
        {
            get
            {
                return iUpdatingText;
            }
            set
            {
                iUpdatingText = value;
                RaisePropertyChanged("UpdatingText");
            }
        }
        
        private void OpenManageAccounts()
        {
            EventHandler handler = ManageAccountsClicked;
            if (handler != null)
                handler(this, new EventArgs());
        }
        private void FetchApiData()
        {
            if (this.Updating)
                return;
            Action updater = () =>
                {
                    this.UpdatingText = "Updating CCP Api data...";
                    this.Updating = true;
                    iUpdateService.Update();
                    this.Updating = false;
                };

            Thread t = new Thread(new ThreadStart(updater));
            t.Start();
        }

        private void RegeneratePriceCache()
        {
            if (this.Updating)
                return;
            Action updater = () =>
            {
                this.UpdatingText = "Regenerating Price Cache...";
                this.Updating = true;
                iModel.RegeneratePriceCache();
                this.Updating = false;
            };

            Thread t = new Thread(new ThreadStart(updater));
            t.Start();
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

        public object ReportView
        {
            get
            {
                return iReportView;
            }
            set
            {
                iReportView = value;
                RaisePropertyChanged("ReportView");
            }
        }

        public event EventHandler ManageAccountsClicked;

        

        [ImportingConstructor]
        public MainWindowViewModel(IMainWindowView view, [Import(RequiredCreationPolicy = CreationPolicy.NonShared)] TraderModel tm, IUpdateService us)
            : base(view)
        {
            view.Closing += ViewClosing;

            iModel = tm;
            iUpdateService = us;

            iOpenManageAccountsCommand = new DelegateCommand(OpenManageAccounts);
            iRegeneratePriceCache = new DelegateCommand(RegeneratePriceCache);
            iFetchApiDataCommand = new DelegateCommand(FetchApiData);
        }
        public void Show()
        {
            this.ViewCore.Show();
        }

        public event CancelEventHandler Closing;
        private object iApplicationLogView;
        private object iPriceCache;
        private object iTransactionsView;
        private object iJournalView;
        private readonly IUpdateService iUpdateService;
        private object iReportView;

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
