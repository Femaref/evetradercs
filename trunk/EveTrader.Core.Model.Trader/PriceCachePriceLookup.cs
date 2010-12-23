using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EveTrader.Core.Services;
using System.ComponentModel.Composition;

namespace EveTrader.Core.Model.Trader
{
    public class PriceCachePriceLookup : IPriceLookup
    {
        private readonly TraderModel model;

        [ImportingConstructor]
        public PriceCachePriceLookup([Import(RequiredCreationPolicy = CreationPolicy.NonShared)] TraderModel tm)
        {
            model = tm;
        }

        public decimal Minimum(long typeID, OrderType mot, long regionID = 10000002)
        {
            throw new NotImplementedException();
        }

        public decimal Maximum(long typeID, OrderType mot, long regionID = 10000002)
        {
            throw new NotImplementedException();
        }

        [LookupMethod]
        public decimal Average(long typeID, OrderType mot, long regionID = 10000002)
        {
            var output = model.CachedPriceInfo.Where(c => c.TypeID == typeID);

            if (mot == OrderType.Buy)
                return (output.Count() == 1) ? output.Single().BuyPrice : 0m;
            else
                return (output.Count() == 1) ? output.Single().SellPrice : 0m;

            
        }

        public decimal Kurtosis(long typeID, OrderType mot, long regionID = 10000002)
        {
            throw new NotImplementedException();
        }

        public decimal Skew(long typeID, OrderType mot, long regionID = 10000002)
        {
            throw new NotImplementedException();
        }

        public decimal Variance(long typeID, OrderType mot, long regionID = 10000002)
        {
            throw new NotImplementedException();
        }

        public decimal StandardDeviation(long typeID, OrderType mot, long regionID = 10000002)
        {
            throw new NotImplementedException();
        }

        public decimal Simulated(long typeID, OrderType mot, long regionID = 10000002)
        {
            throw new NotImplementedException();
        }
    }
}
