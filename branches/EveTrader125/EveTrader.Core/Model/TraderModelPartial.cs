using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Diagnostics;
using System.Reflection;
using System.ComponentModel.Composition;
using System.Data.Objects;
using MoreLinq;

namespace EveTrader.Core.Model
{
    [Export(typeof(TraderModel))]
    public partial class TraderModel
    {
        public string WriteToLog(string text, string callingMember)
        {
            var log = new Model.ApplicationLog() { Message = text, CallingClass = callingMember, Date = DateTime.UtcNow };
            this.ApplicationLog.AddObject(log);
            this.SaveChanges();
            return string.Format("{0} from {1} at {2}", log.Message, log.CallingClass, log.Date);
        }

        public void RegeneratePriceCache()
        {
            this.CachedPriceInfo.ForEach(c => this.CachedPriceInfo.DeleteObject(c));
            this.SaveChanges();

            foreach (long i in this.Transactions.Select(t => t.TypeID).Distinct())
            {
                CachedPriceInfos cpi = new CachedPriceInfos() { TypeID = i };

                cpi.BuyPrice = this.Transactions.Where(t => t.TypeID == i && t.TransactionType == (long)TransactionType.Buy).OrderByDescending(t => t.DateTime).Select(t => t.Price).Take(10).DefaultIfEmpty().Average();
                cpi.SellPrice = this.Transactions.Where(t => t.TypeID == i && t.TransactionType == (long)TransactionType.Sell).OrderByDescending(t => t.DateTime).Select(t => t.Price).Take(10).DefaultIfEmpty().Average();

                this.CachedPriceInfo.AddObject(cpi);
            }

            this.SaveChanges();
        }
        
    }
}
