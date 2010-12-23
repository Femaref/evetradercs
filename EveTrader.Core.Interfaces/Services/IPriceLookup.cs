using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EveTrader.Core.Services
{
    public interface IPriceLookup
    {
        decimal Minimum(long typeID, OrderType mot, long regionID = 10000002);
        decimal Maximum(long typeID, OrderType mot, long regionID = 10000002);
        decimal Average(long typeID, OrderType mot, long regionID = 10000002);
        decimal Kurtosis(long typeID, OrderType mot, long regionID = 10000002);
        decimal Skew(long typeID, OrderType mot, long regionID = 10000002);
        decimal Variance(long typeID, OrderType mot, long regionID = 10000002);
        decimal StandardDeviation(long typeID, OrderType mot, long regionID = 10000002);
        decimal Simulated(long typeID, OrderType mot, long regionID = 10000002);
    }
}
