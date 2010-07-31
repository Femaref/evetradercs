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
 //   [PartCreationPolicy(System.ComponentModel.Composition.CreationPolicy.NonShared)]
    [Export(typeof(TraderModel))]
    public partial class TraderModel
    {
        partial void OnContextCreated()
        {
            this.SavingChanges += new EventHandler(TraderModel_SavingChanges);
        }

        void TraderModel_SavingChanges(object sender, EventArgs e)
        {
            var changes = this.ObjectStateManager.GetObjectStateEntries(System.Data.EntityState.Modified | System.Data.EntityState.Added | System.Data.EntityState.Deleted);
            var distincts = changes.Select(c => c.EntitySet.Name).Distinct().ToList();
            Tables t = new Tables();
            if (distincts.Contains("Transactions") || distincts.Contains("ApiTransactions") || distincts.Contains("CustomTransactions"))
                t |= Tables.Transactions;
            if (distincts.Contains("Journal") || distincts.Contains("ApiJournal") || distincts.Contains("CustomJournal"))
                t |= Tables.Journal;
            if (distincts.Contains("Wallets"))
                t |= Tables.Wallets;
            if(distincts.Contains("WalletHistories"))
                t |= Tables.WalletHistory;
            if (distincts.Contains("MarketOrders"))
                t |= Tables.MarketOrders;
            if (distincts.Contains("Entity") || distincts.Contains("Corporations") || distincts.Contains("Characters"))
                t |= Tables.Entity;
            if (distincts.Contains("ApplicationLog"))
                t |= Tables.ApplicationLog;
            if (distincts.Contains("Accounts"))
                t |= Tables.Accounts;
            if (distincts.Contains("CachedPriceInfo"))
                t |= Tables.CachedPriceInfo;

            RaiseTablesChanged(t);
        }

        private void RaiseTablesChanged(Tables input)
        {
            var handler = this.TablesChanged;
            if (handler != null)
                handler(this, new TablesChangedEventArgs(input));
        }

        public event EventHandler<TablesChangedEventArgs> TablesChanged;

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

        public bool StillCached(string requestString, TimeSpan cachingTimer)
        {
            var cache = this.ApiCache.Where(c => c.RequestString == requestString).FirstOrDefault();
            if (cache == null)
                return false;
            //RequestDate + cachingTimer has to be later than UtcNow for the document to still be cached
            return (cache.RequestDate + cachingTimer) > DateTime.UtcNow;
        }

        public void SaveCache(string requestString, DateTime requestDate, string data)
        {
            var cache = this.ApiCache.Where(c => c.RequestString == requestString).FirstOrDefault();
            if (cache == null)
            {
                cache = new ApiCache() { RequestString = requestString };
                this.ApiCache.AddObject(cache);
            }
            cache.RequestDate = requestDate;
            cache.Data = data;
            this.SaveChanges();
        }

        public string LoadCache(string requestString)
        {
            var cache = this.ApiCache.Where(c => c.RequestString == requestString).FirstOrDefault();
            return cache != null ? cache.Data : "";
        }        
    }

    public partial class Wallets
    {
        public string DisplayName
        {
            get
            {
                if (this.Entity is Corporations)
                    return string.Format("{0}: {1}", this.Entity.Name, this.Name);
                return this.Name;
            }
        }
    }
}
