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
        public AccountBalanceUpdater([Import(RequiredCreationPolicy = CreationPolicy.Shared)] TraderModel tm)
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

            if (abr.UpdateAvailable)
            {
                var data = abr.Request();

                foreach (Wallets w in data)
                {
                    var current = entity.Wallets.FirstOrDefault(ew => ew.AccountKey == w.AccountKey);
                    if (current == null)
                    {
                        string name = "";
                        if (entity is Characters)
                            name = entity.Name;
                        if (entity is Corporations)
                            name = string.Format("{0} {1}", entity.Name, w.AccountKey);
                        current = new Wallets() { AccountKey = w.AccountKey, Balance = w.Balance, Name = name, Entity = entity, ID = 0 };
                        entity.Wallets.Add(current);
                    }
                    else
                    {
                        current.Balance = w.Balance;
                    }
                    current.WalletHistory.Add(WalletHistories.CreateWalletHistories(0, w.Balance, abr.CurrentTime));
                }

                iModel.SaveChanges();
            }
            return true;
        }
    }
}
