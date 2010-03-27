using System.Collections.Generic;

namespace Core.DomainModel
{
    public class MarketOrderComparer : IEqualityComparer<MarketOrder>
    {
        public bool Equals(MarketOrder marketOrder1, MarketOrder marketOrder2)
        {
            return marketOrder1.ID == marketOrder2.ID;
        }

        public int GetHashCode(MarketOrder marketOrder)
        {
            return marketOrder.ID;
        }
    }
}
