using System;
using System.Collections.Generic;
using System.Data.Objects;
using System.Linq;
using EveTrader.Core.Model;

namespace ClassExtenders
{
    public static class EnumerableExtender
    {
        public static decimal AverageBuyPrice(this ObjectSet<Transactions> input, long typeID)
        {
            TraderModel tm = (input.Context as TraderModel);
            if(tm == null)
                return ((IEnumerable<Transactions>)input).AverageBuyPrice(typeID);
            return tm.CachedPriceInfo.Where(c => c.TypeID == typeID).Select(c => c.BuyPrice).FirstOrDefault();
        }

        public static decimal AverageBuyPrice(this IEnumerable<Transactions> input, long typeID)
        {
            return AverageBuyPrice(input, typeID, DateTime.MinValue);
        }

        public static decimal AverageBuyPrice(this IEnumerable<Transactions> input, long typeID, DateTime beforeDate)
        {
            var cache = input.Where(i => i.TypeID == typeID && i.DateTime > beforeDate && i.TransactionType == (long)TransactionType.Buy).Take(10);
            if (cache.Count() > 0)
                return cache.Average(i => i.Price);
            return 0m;
        }
    }
}
