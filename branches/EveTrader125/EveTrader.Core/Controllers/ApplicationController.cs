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



        [ImportingConstructor]
        public ApplicationController(MainWindowViewModel mainView,
            TraderModel tm,
            CompositionContainer container,
            ManageAccountsController manageAccountsController,
            DashboardController dashboardController,
            WalletsController walletsController)
        {
            iMainWindowViewModel = mainView;

            iModel = tm;
            iContainer = container;
            iManageAccountsController = manageAccountsController;
            iDashboardController = dashboardController;
            iWalletsController = walletsController;

            mainView.ManageAccountsClicked += (object o, EventArgs e) => { iManageAccountsController.Show(); };

            this.Initialize();
        }
        public void Initialize()
        {
            iDashboardController.Initialize();
            iManageAccountsController.Initialize();
            iWalletsController.Initialize();
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
