using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Waf.Applications;
using System.ComponentModel.Composition;
using EveTrader.Core.ViewModel;
using EveTrader.Core.Services;

namespace EveTrader.Core.Controllers
{
    [Export]
    public class DashboardController : Controller
    {
        MainWindowViewModel iMainView;
        DashboardViewModel iDashboardView;

        [ImportingConstructor]
        public DashboardController(MainWindowViewModel mainView, DashboardViewModel dashboardView, IUpdateService updater)
        {

            iMainView = mainView;
            iDashboardView = dashboardView;
            iMainView.DashboardView = iDashboardView.View;

            updater.UpdateCompleted += iDashboardView.DataIncoming;
        }

        public void Refresh()
        {
            // randomly crashes the app at startup
           // iDashboardView.Refresh();
        }
    }
}
