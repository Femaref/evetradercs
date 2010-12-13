using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EveTrader.Core.Services
{
    public interface IPriceSourceSelector
    {
        IEnumerable<IPriceLookup> LookupServices { get; set; }
        decimal Current(long typeID, OrderType type, long regionID = 10000002);
        void ChangeLookup(string name);
        void ChangeMethod(string name);
    }

}
