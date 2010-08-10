using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EveTrader.Core.Model
{
    public enum MarketOrderState : long
    {
        OpenActive,
        Closed,
        ExpiredFulfilled,
        Canceled,
        Pending,
        CharacterDeleted
    }
}
