using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Waf.Applications;
using System.ComponentModel.Composition;
using EveTrader.Core.ViewModel;

namespace EveTrader.Core.Controllers
{
    [Export]
    public class DashboardController : Controller
    {
        MainWindowViewModel iMainView;
        DashboardViewModel iDashboardView;

        [ImportingConstructor]
        public DashboardController(MainWindowViewModel mainView, DashboardViewModel dashboardView)
        {
            iMainView = mainView;
            iDashboardView = dashboardView;
            iMainView.DashboardView = iDashboardView.View;
        }

        public void Refresh()
        {
            iDashboardView.Refresh();
        }
    }
}
