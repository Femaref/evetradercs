﻿using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Linq;
using System.Text;
using System.Waf.Applications;
using EveTrader.Core.ViewModel;

namespace EveTrader.Core.Controllers
{
    [Export]
    public class MarketOrdersController : Controller
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
