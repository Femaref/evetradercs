using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EveTrader.Core.Model.Trader;
using EveTrader.Core.Network.Requests.CCP;
using System.ComponentModel.Composition;

namespace EveTrader.Core.Updater.CCP
{
    public class JournalEqualityComparer : EqualityComparer<ApiJournal>
    {

        public override bool Equals(ApiJournal x, ApiJournal y)
        {
            return x.ExternalID == y.ExternalID;
        }

        public override int GetHashCode(ApiJournal obj)
        {
            return obj.ExternalID.GetHashCode();
        }
    }

    [Export(typeof(IJournalUpdater))]
    public class JournalUpdater : UpdaterBase<Entities>, IJournalUpdater
    {
        [ImportingConstructor]
        public JournalUpdater([Import(RequiredCreationPolicy = CreationPolicy.Shared)] TraderModel tm)
            : base(tm)
        {
        }


        protected override bool InnerUpdate<U>(U entity)
        {
            JournalRequest tr = null;
            foreach (Wallets w in entity.Wallets)
            {
                if (entity is Characters)
                    tr = new JournalRequest(entity.Account, entity.ID, ApiRequestTarget.Character, iModel.StillCached, iModel.SaveCache, iModel.LoadCache, 0, w.AccountKey);
                if (entity is Corporations)
                    tr = new JournalRequest(entity.Account, (entity as Corporations).ApiCharacterID, ApiRequestTarget.Corporation, iModel.StillCached, iModel.SaveCache, iModel.LoadCache, 0, w.AccountKey);

                if (tr.UpdateAvailable)
                {

                    var data = tr.Request();

                    int beforeID = 0;


                    int runs = 1;
                    while (data.Count() == runs * 1000 && data.Min(t => t.Date) > DateTime.UtcNow.AddDays(-7))
                    {
                        if (entity is Characters)
                            tr = new JournalRequest(entity.Account, entity.ID, ApiRequestTarget.Character, iModel.StillCached, iModel.SaveCache, iModel.LoadCache, beforeID, w.AccountKey);
                        if (entity is Corporations)
                            tr = new JournalRequest(entity.Account, (entity as Corporations).ApiCharacterID, ApiRequestTarget.Corporation, iModel.StillCached, iModel.SaveCache, iModel.LoadCache, beforeID, w.AccountKey);

                        data = data.Cast<ApiJournal>().Union(tr.Request().Cast<ApiJournal>(), new JournalEqualityComparer());

                        runs++;
                    }
                    foreach (var item in data)
                    {
                        if (w.Journal.OfType<ApiJournal>().Count(j => j.ExternalID == item.ExternalID) == 0)
                        {
                            item.Wallet = w;
                            w.Journal.Add(item);
                        }
                    }
                }
            }

            iModel.SaveChanges();

            return true;
        }
    }
}
