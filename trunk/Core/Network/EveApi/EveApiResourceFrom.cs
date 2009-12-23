using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Core.DomainModel;
using Core.DomainModel;

namespace Core.Network.EveApi
{
    public enum EveApiResourceFrom
    {
        [EnumStringValue("char")] 
        Character,
        [EnumStringValue("corp")] 
        Corporation,
        [EnumStringValue("account")] 
        Account
    }
}
