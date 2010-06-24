using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EveTrader.Core.Model;
using EveTrader.Core.Network.Requests.CCP;
using System.ComponentModel.Composition;

namespace EveTrader.Core.Updater.CCP
{
    public class TransactionsEqualityComparer : EqualityComparer<ApiTransactions>
    {
        public override bool Equals(ApiTransactions x, ApiTransactions y)
        {
            return x.ExternalID == y.ExternalID;
        }

        public override int GetHashCode(ApiTransactions obj)
        {
            return obj.ExternalID.GetHashCode();
        }
    }

    [Export(typeof(ITransactionsUpdater))]
    public class TransactionsUpdater : UpdaterBase<Entities>, ITransactionsUpdater
    {
        [ImportingConstructor]
        public TransactionsUpdater(TraderModel tm)
            : base(tm)
        {
        }


        protected override bool InnerUpdate<U>(U entity)
        {
            List<long> recacheTypes = new List<long>();

            TransactionsRequest tr = null;
            foreach (Wallets w in entity.Wallets)
            {
                if (entity is Characters)
                    tr = new TransactionsRequest(entity.Account, entity.ID, ApiRequestTarget.Character, iModel.StillCached, iModel.SaveCache, iModel.LoadCache, 0, w.AccountKey);
                if (entity is Corporations)
                    tr = new TransactionsRequest(entity.Account, (entity as Corporations).ApiCharacterID, ApiRequestTarget.Corporation, iModel.StillCached, iModel.SaveCache, iModel.LoadCache, 0, w.AccountKey);
                var data = tr.Request();

                int beforeID = 0;


                int runs = 1;
                while (data.Count() == runs * 1000 && data.Min(t => t.Date) > DateTime.UtcNow.AddDays(-7))
                {
                    if (entity is Characters)
                        tr = new TransactionsRequest(entity.Account, entity.ID, ApiRequestTarget.Character, iModel.StillCached, iModel.SaveCache, iModel.LoadCache, beforeID, w.AccountKey);
                    if (entity is Corporations)
                        tr = new TransactionsRequest(entity.Account, (entity as Corporations).ApiCharacterID, ApiRequestTarget.Corporation, iModel.StillCached, iModel.SaveCache, iModel.LoadCache, beforeID, w.AccountKey);

                    data = data.Cast<ApiTransactions>().Union(tr.Request().Cast<ApiTransactions>(), new TransactionsEqualityComparer());

                    runs++;
                }
                foreach (var item in data)
                {
                    if (w.Transactions.OfType<ApiTransactions>().Count(t => t.Date == item.Date && t.ExternalID == item.ExternalID) == 0)
                    {
                        item.Wallet = w;
                        w.Transactions.Add(item);
                        recacheTypes.Add(item.TypeID);
                    }
                }
            }

            iModel.SaveChanges();

            foreach (long i in recacheTypes)
            {

                CachedPriceInfos cpi = null;
                if (iModel.CachedPriceInfo.Count(c => c.TypeID == i) == 0)
                {
                    cpi = new CachedPriceInfos() { TypeID = i };
                    iModel.CachedPriceInfo.AddObject(cpi);
                }
                else
                    cpi = iModel.CachedPriceInfo.First(c => c.TypeID == i);

                cpi.BuyPrice = iModel.Transactions.Where(t => t.TypeID == i && t.TransactionType == (long)TransactionType.Buy).OrderByDescending(t => t.DateTime).Take(10).Average(t => t.Price);
                cpi.SellPrice = iModel.Transactions.Where(t => t.TypeID == i && t.TransactionType == (long)TransactionType.Sell).OrderByDescending(t => t.DateTime).Take(10).Average(t => t.Price);

                iModel.WriteToLog(string.Format("Updated average prices for typeID {0}", cpi.TypeID), "TransactionUpdater.InnerUpdate()");
            }

            iModel.SaveChanges();

            return true;
        }
    }
}
