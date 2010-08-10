using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Linq;
using System.Text;
using System.Waf.Applications;
using EveTrader.Core.ViewModel;

namespace EveTrader.Core.Controllers
{
    [Export]
    public class PriceCacheController : Controller
    {
        private MainWindowViewModel iMainView;
        private PriceCacheViewModel iPriceCacheView;

        [ImportingConstructor]
        public PriceCacheController(MainWindowViewModel mainView, PriceCacheViewModel priceCacheView, IUpdateService updater)
        {
            iMainView = mainView;
            iPriceCacheView = priceCacheView;
            iMainView.PriceCacheView = iPriceCacheView.View;

            updater.Updated += iPriceCacheView.DataIncoming;
        }

    }
}
