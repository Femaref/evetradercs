using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EveTrader.Core.Model;

namespace EveTrader.Core.ClassExtenders
{
    public static class EnumerableExtender
    {
        public static decimal GetProductAverageBuyPrice(this IEnumerable<Transactions> input, long typeID)
        {
            return GetProductAverageBuyPrice(input, typeID, DateTime.MinValue);
        }

        public static decimal GetProductAverageBuyPrice(this IEnumerable<Transactions> input, long typeID, DateTime beforeDate)
        {
            var cache = input.Where(i => i.TypeID == typeID && i.DateTime > beforeDate && i.TransactionType == (long)TransactionType.Buy).Take(10);
            if (cache.Count() > 0)
                return cache.Average(i => i.Price);
            return 0m;
        }
    }
}
