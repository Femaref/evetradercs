using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EveTrader.Core.ViewModel;
using System.ComponentModel.Composition;

namespace EveTrader.Core.Controllers
{
    [Export]
    public class MarketOrdersController
    {
        private MainWindowViewModel iMainView;
        private MarketOrdersViewModel iMarketOrdersView;

        [ImportingConstructor]
        public MarketOrdersController(MainWindowViewModel mainView, MarketOrdersViewModel marketOrdersView)
        {
            iMainView = mainView;
            iMarketOrdersView = marketOrdersView;
        }

        public void Initialize()
        {
            iMainView.MarketOrdersView = iMarketOrdersView.View;
        }
    }
}
