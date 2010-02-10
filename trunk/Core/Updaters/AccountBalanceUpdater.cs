using System;
using System.Collections.Generic;
using System.Linq;
using Core.DomainModel;
using Core.Network.EveApi.Requests;

namespace Core.Updaters
{
    public class AccountBalanceUpdater : IEntityUpdater<IWallet>
    {
        #region Implementation of IEntityUpdater<IWallet>

        public bool UpdateEntity(IWallet entity)
        {
            AccountBalanceRequest accountBalanceRequest = new AccountBalanceRequest(entity);

            if ((entity.Wallets.Count() > 0 && entity.Wallets.Min(w => w.NextAccountBalanceUpdate) <= DateTime.Now) || entity.Wallets.Count == 0)
            {
                IEnumerable<IAccountBalance> accounts = accountBalanceRequest.Request();

                if (accountBalanceRequest.ErrorCode == 0)
                {
                    foreach (IAccountBalance iab in accounts)
                    {
                        IAccountBalance single;
                        single = entity.Wallets.Where(i => i.ID == iab.ID && i.Key == iab.Key).SingleOrDefault();
                        if (single != null)
                        {
                            single.Balance = iab.Balance;
                        }
                        else
                        {
                            single = iab;
                            entity.Wallets.Add((Wallet) single);
                        }
                        single.NextAccountBalanceUpdate = DateTime.Now.AddHours(1).AddMinutes(1);
                    }
                }
                return true;
            }
            return false;
        }

        #endregion
    }
}
