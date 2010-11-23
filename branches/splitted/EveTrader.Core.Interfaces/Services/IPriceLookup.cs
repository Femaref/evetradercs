using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EveTrader.Core.Model.Trader;

namespace EveTrader.Core.Services
{
    public interface IPriceLookup
    {
        decimal Minimum(long typeID, TransactionType mot);
        decimal Maximum(long typeID, TransactionType mot);
        decimal Average(long typeID, TransactionType mot);
        decimal Kurtosis(long typeID, TransactionType mot);
        decimal Skew(long typeID, TransactionType mot);
        decimal Variance(long typeID, TransactionType mot);
        decimal StandardDeviation(long typeID, TransactionType mot);
        decimal Simulated(long typeID, TransactionType mot);
    }
}
