
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Waf.Applications;
using System.ComponentModel.Composition;
using EveTrader.Core.Model;
using EveTrader.Core.View;
using EveTrader.Core.ViewModel;
using System.Windows.Input;
using System.ComponentModel.Composition.Hosting;
using EveTrader.Core.Updater.CCP;
using System.Threading;
using System.Reflection;

namespace EveTrader.Core.Controllers
{
    [Export]
    public class ApplicationController : Controller
    {
        private readonly MainWindowViewModel iMainWindowViewModel;
        private readonly TraderModel iModel;
        private readonly ManageAccountsController iManageAccountsController;
        private readonly CompositionContainer iContainer;
        private readonly DashboardController iDashboardController;
        private readonly WalletsController iWalletsController;
        private readonly MarketOrdersController iMarketOrdersController;
        private readonly ApplicationLogController iApplicationLogController;
        private readonly PriceCacheController iPriceCacheController;
        private readonly ReportController iReportController;
        private readonly JournalController iJournalController;
        private readonly TransactionsController iTransactionsController;

        private readonly ISettingsProvider iSettings;

        private readonly CharacterUpdater iCharacterUpdater;
        private readonly CorporationUpdater iCorporationUpdater;

        private readonly StaticModel iStaticData;

        private readonly List<Controller> iControllers = new List<Controller>();
       



        [ImportingConstructor]
        public ApplicationController(MainWindowViewModel mainView,
            TraderModel tm,
            StaticModel sm,
            CompositionContainer container,
            ManageAccountsController manageAccountsController,
            DashboardController dashboardController,
            WalletsController walletsController,
            MarketOrdersController marketOrdersController,
            ApplicationLogController applicationLogController,
            PriceCacheController priceCacheController,
            JournalController journalController,
            TransactionsController transactionsController,
            ReportController reportController,
            ISettingsProvider settingsProvider,
            CharacterUpdater charUpdater,
            CorporationUpdater corpUpdater)
        {
            iMainWindowViewModel = mainView;

            iModel = tm;
            iModel.TablesChanged += new EventHandler<TablesChangedEventArgs>(iModel_TablesChanged);
            iStaticData = sm;
            iContainer = container;
            iManageAccountsController = manageAccountsController;
            iDashboardController = dashboardController;
            iWalletsController = walletsController;
            iMarketOrdersController = marketOrdersController;
            iApplicationLogController = applicationLogController;
            iPriceCacheController = priceCacheController;
            iJournalController = journalController;
            iTransactionsController = transactionsController;
            iReportController = reportController;

            iSettings = settingsProvider;

            iCharacterUpdater = charUpdater;
            iCorporationUpdater = corpUpdater;

            mainView.ManageAccountsClicked += (object o, EventArgs e) => { iManageAccountsController.Show(); };
        }

        void iModel_TablesChanged(object sender, TablesChangedEventArgs e)
        {
            if ((e.ChangedTables & Tables.ApplicationLog) == Tables.ApplicationLog)
                iApplicationLogController.Refresh();
        }

        public void Run()
        {
            iMainWindowViewModel.Show();
        }

        public void Shutdown()
        {
            iManageAccountsController.Shutdown();
            iModel.Dispose();
        }
    }
}
