using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EveTrader.Core.Model.Trader;

namespace EveTrader.Core.Visual.View
{
    public interface IJournalView : IExtendedView
    {
        event EventHandler<EntitySelectionChangedEventArgs<Wallets>> EntitySelectionChanged;
    }
}
