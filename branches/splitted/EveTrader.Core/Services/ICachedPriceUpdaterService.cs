using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EveTrader.Core.Services
{
    public interface ICachedPriceUpdaterService
    {
        void Update(long typeID);
        void Update(IEnumerable<long> typeIDs);
    }
}
