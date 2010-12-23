using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ClassExtenders;

namespace EveTrader.Core.Network.Requests.CCP
{
    public enum ApiRequestTarget
    {
        [EnumStringValue("char")]
        Character,
        [EnumStringValue("corp")]
        Corporation,
        [EnumStringValue("account")]
        Account,
        [EnumStringValue("eve")]
        Eve,
        [EnumStringValue("map")]
        Map,
        [EnumStringValue("server")]
        Server
    }
}
