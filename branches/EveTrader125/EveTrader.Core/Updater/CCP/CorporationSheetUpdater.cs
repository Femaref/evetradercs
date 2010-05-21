using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EveTrader.Core.Model;
using EveTrader.Core.Network.Requests.CCP;

namespace EveTrader.Core.Updater.CCP
{
    public  class CorporationSheetUpdater : UpdaterBase<Corporations>, ICorporationSheetUpdater
    {
        public CorporationSheetUpdater(TraderModel tm)
            : base(tm)
        {
        }

        protected override bool InnerUpdate<U>(U entity)
        {
            CorporationSheetRequest csr = new CorporationSheetRequest(entity.Account, entity.ApiCharacterID);
            Corporations c = csr.Request();

            entity.Name = c.Name;
            entity.Npc = c.Npc;
            entity.Ticker = c.Ticker;

            foreach(Wallets w in c.Wallets)
            {
                var current = entity.Wallets.FirstOrDefault(ew => ew.AccountKey == w.AccountKey);
                if (current == null)
                {
                    entity.Wallets.Add(new Wallets() { AccountKey = w.AccountKey, Balance = 0, ID = 0, Name = w.Name, Entity = entity });
                }
                else
                {
                    current.Name = w.Name;
                }
            }

            iModel.SaveChanges();

            return true;
        }
    }
}
