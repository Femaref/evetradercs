using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EveTrader.Core.Services;
using System.ComponentModel.Composition;
using System.Reflection;
using EveTrader.Core.Model.Central;
using EveTrader.Core.Updater.Central;
using System.Linq.Expressions;

namespace EveTrader.Core.Services
{
    public class CentralPriceLookup : IPriceLookup
    {
        private readonly CentralModel model;
        private readonly ItemPriceUpdater updater;

        [ImportingConstructor]
        public CentralPriceLookup([Import(RequiredCreationPolicy=CreationPolicy.NonShared)] CentralModel cm, ItemPriceUpdater ipu)
        {
            this.model = cm;
            this.updater = ipu;
        }

        private decimal Lookup(Func<ItemPrices, decimal> selector, long typeID, long regionID)
        {
            var where = WhereGenerator(typeID, regionID);

            try
            {
                if (!model.ItemPrices.Any(where))
                    updater.Update(typeID, regionID);
            }
            catch
            {
                return 0;
            }

            var current = model.ItemPrices.FirstOrDefault(where);

            if (current != null)
                return selector(current);

            current = model.ItemPrices.FirstOrDefault(WhereGenerator(typeID, 0));

            if(current != null)
                return selector(current);

            return 0;
        }

        private Func<ItemPrices, bool> WhereGenerator(long typeID, long regionID)
        {
            return ip => { return ip.TypeID == typeID && ip.RegionID == regionID; };
        }

        private Func<ItemPrices, decimal> SelectorGenerator(MethodBase method, string type)
        {
            ParameterExpression pe = Expression.Parameter(typeof(ItemPrices), "arg");

            MemberInfo mi = typeof(ItemPrices).GetProperty((method.Name != "Average" ? method.Name : "Median") + type);

            Func<ItemPrices, decimal> selectorExpression =
                Expression.Lambda<Func<ItemPrices, decimal>>(Expression.MakeMemberAccess(pe, mi), pe).Compile();

            return selectorExpression;
        }

        [LookupMethod]
        public decimal Minimum(long typeID, OrderType mot, long regionID = 10000002)
        {
            return Lookup(SelectorGenerator(MethodInfo.GetCurrentMethod(), mot.ToString()), typeID, regionID);
        }
        [LookupMethod]
        public decimal Maximum(long typeID, OrderType mot, long regionID = 10000002)
        {
            return Lookup(SelectorGenerator(MethodInfo.GetCurrentMethod(), mot.ToString()), typeID, regionID);
        }
        [LookupMethod]
        public decimal Average(long typeID, OrderType mot, long regionID = 10000002)
        {
            return Lookup(SelectorGenerator(MethodInfo.GetCurrentMethod(), mot.ToString()), typeID, regionID);
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
            return Lookup(SelectorGenerator(MethodInfo.GetCurrentMethod(), mot.ToString()), typeID, regionID);
        }

        public decimal Simulated(long typeID, OrderType mot, long regionID = 10000002)
        {
            throw new NotImplementedException();
        }
    }
}
