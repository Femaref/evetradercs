using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Waf.Applications;
using EveTrader.Core.Model.Trader;

namespace EveTrader.Core.View
{
    public interface ITransactionsView : IExtendedView
    {
        event EventHandler<EntitySelectionChangedEventArgs<Wallets>> EntitySelectionChanged;
    }
}
