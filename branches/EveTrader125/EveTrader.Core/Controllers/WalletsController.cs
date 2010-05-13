using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EveTrader.Core.ViewModel;
using System.Waf.Applications;
using System.ComponentModel.Composition;

namespace EveTrader.Core.Controllers
{
    [Export]
    public class WalletsController : Controller
    {
        private MainWindowViewModel iMainView;
        private WalletsViewModel iWalletsView;

        [ImportingConstructor]
        public WalletsController(MainWindowViewModel mainView, WalletsViewModel walletsView)
        {
            iMainView = mainView;
            iWalletsView = walletsView;
        }

        public void Initialize()
        {
            iMainView.WalletsView = iWalletsView.View;
        }
    }
}
