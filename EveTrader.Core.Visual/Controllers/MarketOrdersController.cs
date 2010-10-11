using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Linq;
using System.Text;
using System.Waf.Applications;
using EveTrader.Core.ViewModel;
using EveTrader.Core.Services;

namespace EveTrader.Core.Controllers
{
    [Export]
    public class MarketOrdersController : Controller
    {
        private MainWindowViewModel iMainView;
        private MarketOrdersViewModel iMarketOrdersView;

        [ImportingConstructor]
        public MarketOrdersController(MainWindowViewModel mainView, MarketOrdersViewModel marketOrdersView, IUpdateService updater)
        {
            iMainView = mainView;
            iMarketOrdersView = marketOrdersView;
            iMainView.MarketOrdersView = iMarketOrdersView.View;

            updater.Updated += iMarketOrdersView.DataIncoming;
        }

        public void Refresh()
        {
            iMarketOrdersView.Refresh();
        }
    }
}
