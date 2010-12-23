using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Diagnostics;
using System.Reflection;
using System.ComponentModel.Composition;
using System.Data.Objects;
using MoreLinq;
using System.IO;
using System.Data.SQLite;
using System.Data.EntityClient;

namespace EveTrader.Core.Model.Trader
{
    [PartCreationPolicy(System.ComponentModel.Composition.CreationPolicy.Any)]
    [Export(typeof(TraderModel))]
    public partial class TraderModel
    {
        [ImportingConstructor]
        public TraderModel([Import("TraderModelConnectionString")] IConnectionStringProvider sb)
            : base(new EntityConnection(sb.GetConnectionString()), "TraderModel")
        {
            this.ContextOptions.LazyLoadingEnabled = true;
            OnContextCreated();
        }

        public string WriteToLog(string text, string callingMember)
        {
            var log = new ApplicationLog() { Message = text, CallingClass = callingMember, Date = DateTime.UtcNow };
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

        public new static string CreateDatabase()
        {
            return CreateDatabase(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "EveTrader", "EveTrader.db"));
        }
        public static string CreateDatabase(string path)
        {
            FileInfo fi = new FileInfo(path);

            if (!fi.Exists || fi.Length == 0)
            {
                string connection = string.Format("Data Source={0};Version=3;", path);
                string db_schema = Properties.Resources.tables;

                using (SQLiteConnection cn = new SQLiteConnection(connection))
                {
                    using (SQLiteCommand cmd = cn.CreateCommand())
                    {
                        cmd.CommandText = db_schema;
                        cmd.CommandType = System.Data.CommandType.Text;
                        cn.Open();
                        cmd.ExecuteNonQuery();
                    }
                }
            }
            return path;
        }

        public void Prune()
        {
            PruneTransactions();
        }

        private void PruneTransactions()
        {
            var wrongTransactions = this.Transactions.Where(t => t.TransactionFor == (long)TransactionFor.Corporation && (t.Wallet.Entity is Characters));
            foreach (var t in wrongTransactions)
                this.Transactions.DeleteObject(t);

            this.SaveChanges();
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
