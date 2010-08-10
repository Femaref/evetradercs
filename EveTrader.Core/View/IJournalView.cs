using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EveTrader.Core.Model;

namespace EveTrader.Core.View
{
    public interface IJournalView : IExtendedView
    {
        event EventHandler<EntitySelectionChangedEventArgs<Wallets>> EntitySelectionChanged;
    }
}
