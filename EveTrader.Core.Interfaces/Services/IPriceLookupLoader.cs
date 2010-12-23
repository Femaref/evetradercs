using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EveTrader.Core.Services
{
    public interface IPriceLookupLoader
    {
        void Save(Func<long, OrderType, long, decimal> fun);
        Func<long, OrderType, long, decimal> Load();
    }
}
