using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EveTrader.Core.Model;
using EveTrader.Core.Network.Requests.CCP;
using System.ComponentModel.Composition;

namespace EveTrader.Core.Updater.CCP
{
    [Export(typeof(ICorporationSheetUpdater))]
    public  class CorporationSheetUpdater : UpdaterBase<Corporations>, ICorporationSheetUpdater
    {
        [ImportingConstructor]
        public CorporationSheetUpdater(TraderModel tm)
            : base(tm)
        {
        }

        protected override bool InnerUpdate<U>(U entity)
        {
            CorporationSheetRequest csr = new CorporationSheetRequest(entity.Account, entity.ApiCharacterID);
            Corporations c = csr.Request();

            entity.Name = c.Name;
            entity.Npc = c.ID <= 1000182;
            entity.Ticker = c.Ticker;

            if (c.ID > 1000182)
            {
                foreach (Wallets w in c.Wallets)
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
            }
            iModel.SaveChanges();

            return true;
        }
    }
}
