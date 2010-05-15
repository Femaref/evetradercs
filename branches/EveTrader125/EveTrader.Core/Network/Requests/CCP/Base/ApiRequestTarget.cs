using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EveTrader.Core.ClassExtenders;

namespace EveTrader.Core.Network.Requests.CCP
{
    public enum ApiRequestTarget
    {
        [EnumStringValue("character")]
        Character,
        [EnumStringValue("ccorporation")]
        Corporation,
        [EnumStringValue("account")]
        Account
    }
}
