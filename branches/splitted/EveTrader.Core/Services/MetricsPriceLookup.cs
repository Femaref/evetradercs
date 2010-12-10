using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EveTrader.Core.Model.Metric;
using System.Reflection;
using System.Linq.Expressions;

namespace EveTrader.Core.Services
{
    public class MetricsPriceLookup : IPriceLookup
    {
        private readonly MetricModel iModel;

        public MetricsPriceLookup(MetricModel mm)
        {
            iModel = mm;
        }

        private decimal Lookup(Func<ItemPrices, decimal> selector, Func<ItemPrices, bool> where)
        {
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
                (Func<ItemPrices, decimal>)Expression.Lambda(Expression.MakeMemberAccess(pe, mi), pe).Compile();

            return selectorExpression;
        }

        public decimal Minimum(long typeID, OrderType mot, long regionID = 10000002)
        {
            return Lookup(SelectorGenerator(MethodInfo.GetCurrentMethod(), mot.ToString()), WhereGenerator(typeID, regionID));
        }

        public decimal Maximum(long typeID, OrderType mot, long regionID = 10000002)
        {
            return Lookup(SelectorGenerator(MethodInfo.GetCurrentMethod(), mot.ToString()), WhereGenerator(typeID, regionID));
        }

        public decimal Average(long typeID, OrderType mot, long regionID = 10000002)
        {
            return Lookup(SelectorGenerator(MethodInfo.GetCurrentMethod(), mot.ToString()), WhereGenerator(typeID, regionID));
        }

        public decimal Kurtosis(long typeID, OrderType mot, long regionID = 10000002)
        {
            return Lookup(SelectorGenerator(MethodInfo.GetCurrentMethod(), mot.ToString()), WhereGenerator(typeID, regionID));
        }

        public decimal Skew(long typeID, OrderType mot, long regionID = 10000002)
        {
            return Lookup(SelectorGenerator(MethodInfo.GetCurrentMethod(), mot.ToString()), WhereGenerator(typeID, regionID));
        }

        public decimal Variance(long typeID, OrderType mot, long regionID = 10000002)
        {
            return Lookup(SelectorGenerator(MethodInfo.GetCurrentMethod(), mot.ToString()), WhereGenerator(typeID, regionID));
        }

        public decimal StandardDeviation(long typeID, OrderType mot, long regionID = 10000002)
        {
            return Lookup(SelectorGenerator(MethodInfo.GetCurrentMethod(), mot.ToString()), WhereGenerator(typeID, regionID));
        }

        public decimal Simulated(long typeID, OrderType mot, long regionID = 10000002)
        {
            return Lookup(SelectorGenerator(MethodInfo.GetCurrentMethod(), mot.ToString()), WhereGenerator(typeID, regionID));
        }
    }
}
