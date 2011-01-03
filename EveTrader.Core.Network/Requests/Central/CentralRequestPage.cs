using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ClassExtenders;

namespace EveTrader.Core.Network.Requests.Central
{
    public enum CentralRequestPage
    {
        [EnumStringValue("marketstat")]
        ItemPrice,
        [EnumStringValue("quicklook")]
        ItemOrders
    }
}
