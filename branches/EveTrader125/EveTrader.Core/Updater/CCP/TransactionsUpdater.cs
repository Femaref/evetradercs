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
            TransactionsRequest tr = null;
            foreach (Wallets w in entity.Wallets)
            {
                if (entity is Characters)
                    tr = new TransactionsRequest(entity.Account, entity.ID, ApiRequestTarget.Character, 0, w.AccountKey);
                if (entity is Corporations)
                    tr = new TransactionsRequest(entity.Account, (entity as Corporations).ApiCharacterID, ApiRequestTarget.Corporation, 0, w.AccountKey);
                var data = tr.Request();

                int beforeID = 0;


                int runs = 1;
                while (data.Count() == runs * 1000 && data.Min(t => t.Date) > DateTime.UtcNow.AddDays(-7))
                {
                    if (entity is Characters)
                        tr = new TransactionsRequest(entity.Account, entity.ID, ApiRequestTarget.Character, beforeID, w.AccountKey);
                    if (entity is Corporations)
                        tr = new TransactionsRequest(entity.Account, (entity as Corporations).ApiCharacterID, ApiRequestTarget.Corporation, beforeID, w.AccountKey);

                    data = data.Cast<ApiTransactions>().Union(tr.Request().Cast<ApiTransactions>(), new TransactionsEqualityComparer());

                    runs++;
                }
                foreach (var item in data)
                {
                    if (w.Transactions.OfType<ApiTransactions>().Count(t => t.Date == item.Date && t.ExternalID == item.ExternalID) == 0)
                    {
                        item.Wallet = w;
                        w.Transactions.Add(item);
                    }
                }
            }

            iModel.SaveChanges();

            return true;
        }
    }
}
