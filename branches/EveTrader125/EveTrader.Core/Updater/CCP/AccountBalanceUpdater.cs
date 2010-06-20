using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EveTrader.Core.Model;
using EveTrader.Core.Network.Requests.CCP;
using System.ComponentModel.Composition;

namespace EveTrader.Core.Updater.CCP
{
    [Export(typeof(IAccountBalanceUpdater))]
    public class AccountBalanceUpdater : UpdaterBase<Entities>, IAccountBalanceUpdater
    {
        [ImportingConstructor]
        public AccountBalanceUpdater(TraderModel tm)
            : base(tm)
        {
        }

        protected override bool InnerUpdate<U>(U entity)
        {
            AccountBalanceRequest abr = null;

            if (entity is Characters)
                abr = new AccountBalanceRequest(entity.Account, entity.ID, ApiRequestTarget.Character, iModel.StillCached, iModel.SaveCache, iModel.LoadCache);
            if (entity is Corporations)
                abr = new AccountBalanceRequest(entity.Account, (entity as Corporations).ApiCharacterID, ApiRequestTarget.Corporation, iModel.StillCached, iModel.SaveCache, iModel.LoadCache);

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
                current.WalletHistory.Add(WalletHistories.CreateWalletHistories(0, w.Balance, abr.CurrentTime));
            }

            iModel.SaveChanges();
            return true;
        }
    }
}
