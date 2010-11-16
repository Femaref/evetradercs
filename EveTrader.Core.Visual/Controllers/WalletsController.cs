using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EveTrader.Core.ViewModel;
using System.Waf.Applications;
using System.ComponentModel.Composition;
using EveTrader.Core.Services;

namespace EveTrader.Core.Controllers
{
    [Export]
    public class WalletsController : Controller
    {
        private MainWindowViewModel iMainView;
        private WalletsViewModel iWalletsView;

        [ImportingConstructor]
        public WalletsController(MainWindowViewModel mainView, WalletsViewModel walletsView, IUpdateService updater)
        {
            iMainView = mainView;
            iWalletsView = walletsView;
            iMainView.WalletsView = iWalletsView.View;

            updater.UpdateCompleted += iWalletsView.DataIncoming;
        }
    }
}
