using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EveTrader.Core.Model.Metric;
using System.Reflection;
using System.Linq.Expressions;
using EveTrader.Core.Updater.Metrics;
using System.ComponentModel.Composition;

namespace EveTrader.Core.Services
{
    public class MetricsPriceLookup : IPriceLookup
    {
        private readonly MetricModel iModel;
        private readonly ItemPriceUpdater iPriceUpdater;

        [ImportingConstructor]
        public MetricsPriceLookup([Import(RequiredCreationPolicy=CreationPolicy.NonShared)] MetricModel mm, ItemPriceUpdater ipu)
        {
            iModel = mm;
            iPriceUpdater = ipu;
        }

        private decimal Lookup(Func<ItemPrices, decimal> selector, long typeID, long regionID)
        {
            var where = WhereGenerator(typeID, regionID);

            if (!iModel.ItemPrices.Any(where))
                iPriceUpdater.Update(typeID, regionID);

            var current = iModel.ItemPrices.FirstOrDefault(where);

            if (current == null)
                return 0;

            return selector(current);
        }

        private Func<ItemPrices, bool> WhereGenerator(long typeID, long regionID)
        {
            return ip => { return ip.TypeID == typeID && ip.RegionID == regionID; };
        }

        private Func<ItemPrices, decimal> SelectorGenerator(MethodBase method, string type)
        {
            ParameterExpression pe = Expression.Parameter(typeof(ItemPrices), "arg");

            MemberInfo mi = typeof(ItemPrices).GetProperty(method.Name + type);

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
            return Lookup(SelectorGenerator(MethodInfo.GetCurrentMethod(), mot.ToString()), typeID, regionID);
        }

        public decimal Skew(long typeID, OrderType mot, long regionID = 10000002)
        {
            return Lookup(SelectorGenerator(MethodInfo.GetCurrentMethod(), mot.ToString()), typeID, regionID);
        }

        public decimal Variance(long typeID, OrderType mot, long regionID = 10000002)
        {
            return Lookup(SelectorGenerator(MethodInfo.GetCurrentMethod(), mot.ToString()), typeID, regionID);
        }

        public decimal StandardDeviation(long typeID, OrderType mot, long regionID = 10000002)
        {
            return Lookup(SelectorGenerator(MethodInfo.GetCurrentMethod(), mot.ToString()), typeID, regionID);
        }
        [LookupMethod]
        public decimal Simulated(long typeID, OrderType mot, long regionID = 10000002)
        {
            return Lookup(SelectorGenerator(MethodInfo.GetCurrentMethod(), mot.ToString()), typeID, regionID);
        }
    }
}
