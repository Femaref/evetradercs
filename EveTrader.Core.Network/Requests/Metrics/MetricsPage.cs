using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ClassExtenders;

namespace EveTrader.Core.Network.Requests.Metrics
{
    public enum MetricsPage
    {
        [EnumStringValue("item")]
        ItemPrice,
        [EnumStringValue("history")]
        ItemHistory,
        [EnumStringValue("orders")]
        ItemOrders
    }
}
