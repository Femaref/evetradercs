using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Waf.Applications;
using EveTrader.Core.Visual.View;
using System.ComponentModel.Composition;
using System.ComponentModel;
using System.Windows.Input;
using EveTrader.Core.Model.Trader;
using EveTrader.Core.Controllers;
using System.Threading;
using EveTrader.Core.Services;
using System.Collections.ObjectModel;
using EveTrader.Core.Visual.ViewModel.Display;
using EveTrader.Core.Collections.ObjectModel;

namespace EveTrader.Core.Visual.ViewModel
{
    [Export]
    public class MainWindowViewModel : ViewModel<IMainWindowView>
    {
        private readonly ICommand iOpenManageAccountsCommand;
        private readonly ICommand iRegeneratePriceCache;
        private readonly ICommand iFetchApiDataCommand;
        private readonly ICommand iFetchStaticDataCommand;

        private readonly TraderModel iModel;
        private readonly IUpdateService iUpdateService;

        private bool iUpdating = false;
        private string iUpdatingText = ""; 
        private object iDashboardView;
        private object iWalletsView;
        private object iMarketOrdersView;
        private object iApplicationLogView;
        private object iPriceCache;
        private object iTransactionsView;
        private object iJournalView;
        private object iReportView;

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
        public ICommand FetchStaticDataCommand
        {
            get { return this.iFetchStaticDataCommand; }
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
      
        [ImportingConstructor]
        public MainWindowViewModel(
            IMainWindowView view, 
            [Import(RequiredCreationPolicy = CreationPolicy.NonShared)] TraderModel tm, 
            IUpdateService us)
            : base(view)
        {
            view.Closing += ViewClosing;

            iModel = tm;
            iUpdateService = us;

            iUpdateService.UpdateStarted += new EventHandler(iUpdateService_UpdateStarted);
            iUpdateService.UpdateCompleted += new EventHandler<EntitiesUpdatedEventArgs>(iUpdateService_UpdateCompleted);           

            iOpenManageAccountsCommand = new DelegateCommand(() =>  this.SettingsShown = true);
            iRegeneratePriceCache = new DelegateCommand(RegeneratePriceCache);
            iFetchApiDataCommand = new DelegateCommand(FetchApiData);
            iFetchStaticDataCommand = new DelegateCommand(FetchStaticData);
        }

        void iUpdateService_UpdateCompleted(object sender, EntitiesUpdatedEventArgs e)
        {
            Updating = false;
        }

        void iUpdateService_UpdateStarted(object sender, EventArgs e)
        {
            Updating = true;
        }

        public void Show()
        {
            this.ViewCore.Show();
        }

        private void FetchApiData()
        {
            if (this.Updating)
                return;
           
                this.UpdatingText = "Updating CCP Api data...";
                iUpdateService.Update();
        }

        private void FetchStaticData()
        {
            if (this.Updating)
                return;

            this.UpdatingText = "Updating Eve Static data...";
            iUpdateService.UpdateStatic();
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

        protected virtual void OnClosing(CancelEventArgs e)
        {
            if (Closing != null) { Closing(this, e); }
        }
        private void ViewClosing(object sender, CancelEventArgs e)
        {
            OnClosing(e);
        }

        public event CancelEventHandler Closing;

        private object converterView;
        public object ConverterView
        {
            get { return converterView; }
            set
            {
                converterView = value;
                RaisePropertyChanged("ConverterView");
            }
        }

        private bool converterShown;
        public bool ConverterShown
        {
            get { return converterShown; }
            set
            {
                converterShown = value;
                RaisePropertyChanged("ConverterShown");
            }
        }

        private object settingsView;
        public object SettingsView
        {
            get { return settingsView; }
            set
            {
                settingsView = value;
                RaisePropertyChanged("SettingsView");
            }
        }

        private bool settingsShown;
        public bool SettingsShown
        {
            get { return settingsShown; }
            set
            {
                settingsShown = value;
                RaisePropertyChanged("SettingsShown");
            }
        } 
    }
}
