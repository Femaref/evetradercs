using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Reflection;

namespace EveTrader.Core.Services
{
    public interface IPriceSourceSelector
    {
        IEnumerable<IPriceLookup> LookupServices { get; set; }
        decimal Current(long typeID, OrderType type, long regionID = 10000002);
        Type CurrentSource { get; set; }
        MethodInfo CurrentMethod { get; set; }
        void ChangeLookup(string name);
        void ChangeLookup(Type type);
        void ChangeMethod(string name);
        void ChangeMethod(MethodBase method);
    }

}
