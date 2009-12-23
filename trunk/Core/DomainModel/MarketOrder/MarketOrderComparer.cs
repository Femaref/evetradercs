using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Core.DomainModel;

namespace Core.DomainModel
{
    public class MarketOrderComparer : IEqualityComparer<MarketOrder>
    {
        public bool Equals(MarketOrder marketOrder1, MarketOrder marketOrder2)
        {
            return marketOrder1.Id == marketOrder2.Id;
        }

        public int GetHashCode(MarketOrder marketOrder)
        {
            return marketOrder.Id;
        }
    }
}
