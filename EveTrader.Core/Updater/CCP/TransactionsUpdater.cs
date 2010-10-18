using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EveTrader.Core.Model.Trader;
using EveTrader.Core.Network.Requests.CCP;
using System.ComponentModel.Composition;
using EveTrader.Core.Services;

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
        private readonly ICachedPriceUpdaterService iPriceUpdater;

        [ImportingConstructor]
        public TransactionsUpdater([Import(RequiredCreationPolicy = CreationPolicy.Shared)] TraderModel tm, ICachedPriceUpdaterService cpus)
            : base(tm)
        {
            iPriceUpdater = cpus;
        }


        protected override bool InnerUpdate<U>(U entity)
        {
            List<long> recache = new List<long>();

            TransactionsRequest tr = null;
            foreach (Wallets w in entity.Wallets)
            {
                if (entity is Characters)
                    tr = new TransactionsRequest(entity.Account, entity.ID, ApiRequestTarget.Character, iModel.StillCached, iModel.SaveCache, iModel.LoadCache, 0, w.AccountKey);
                if (entity is Corporations)
                    tr = new TransactionsRequest(entity.Account, (entity as Corporations).ApiCharacterID, ApiRequestTarget.Corporation, iModel.StillCached, iModel.SaveCache, iModel.LoadCache, 0, w.AccountKey);

                if (tr.UpdateAvailable)
                {

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
                        if (!w.Transactions.OfType<ApiTransactions>().Any(t => t.Date == item.Date && t.ExternalID == item.ExternalID))
                        {
                            if ((entity is Characters) && item.TransactionFor == (long)TransactionFor.Corporation)
                                continue;

                            item.Wallet = w;
                            w.Transactions.Add(item);
                            if(!recache.Contains(item.TypeID))
                                recache.Add(item.TypeID);
                        }
                    }
                }
            }

            iModel.SaveChanges();

            iPriceUpdater.Update(recache);

            return true;
        }
    }
}
