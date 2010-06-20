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

        private readonly CharacterUpdater iCharacterUpdater;
        private readonly CorporationUpdater iCorporationUpdater;

        private readonly Timer iUpdateTimer;
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
            CharacterUpdater charUpdater,
            CorporationUpdater corpUpdater)
        {
            iMainWindowViewModel = mainView;

            iModel = tm;
            iStaticData = sm;
            iContainer = container;
            iManageAccountsController = manageAccountsController;
            iDashboardController = dashboardController;
            iWalletsController = walletsController;
            iMarketOrdersController = marketOrdersController;
            iApplicationLogController = applicationLogController;
            iPriceCacheController = priceCacheController;

            iCharacterUpdater = charUpdater;
            iCorporationUpdater = corpUpdater;

            iUpdateTimer = new Timer(new TimerCallback(UpdateData), null, 0, 60 * 60 * 1000);

            mainView.ManageAccountsClicked += (object o, EventArgs e) => { iManageAccountsController.Show(); };
        }
        private void UpdateData(object o)
        {
            foreach (Characters c in iModel.Entity.OfType<Characters>())
                iCharacterUpdater.Update(c);
            foreach (Corporations c in iModel.Entity.OfType<Corporations>())
                iCorporationUpdater.Update(c);
            
        }

        public void Run()
        {
            iMainWindowViewModel.Show();
        }

        public void Shutdown()
        {
            iModel.Dispose();
        }
    }
}
