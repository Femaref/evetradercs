using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EveTrader.Core.Model;
using EveTrader.Core.Network.Requests.CCP;

namespace EveTrader.Core.Updater.CCP
{
public class AccountBalanceUpdater : UpdaterBase<Entities>
    {
        public AccountBalanceUpdater(TraderModel tm) : base(tm)
        {
        }

        protected override bool InnerUpdate(Entities entity)
        {
            AccountBalanceRequest abr = null;

            if (entity is Characters)
                abr = new AccountBalanceRequest(entity.Account, entity.ID, ApiRequestTarget.Character);
            if (entity is Corporations)
                abr = new AccountBalanceRequest(entity.Account, (entity as Corporations).ApiCharacterID, ApiRequestTarget.Corporation);

            var data = abr.Request();

            foreach (Wallets w in data)
            {
                var current = entity.Wallets.FirstOrDefault(ew => ew.AccountKey == w.AccountKey);
                if (current == null)
                {
                    entity.Wallets.Add(new Wallets() { AccountKey = w.AccountKey, Balance = w.Balance, Name = "", Entity = entity, ID = 0 });
                }
                else
                {
                    current.Balance = w.Balance;
                }
            }

            iModel.SaveChanges();
            return true;
        }
    }
}
