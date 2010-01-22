using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Core.DomainModel;
using Core.Network.EveApi.Requests;

namespace Core.Updaters
{
    public class AccountBalanceUpdater : ICorporationUpdater
    {
        #region ICharacterUpdater Members

        public bool UpdateCorporation(Corporation corporation)
        {
            AccountBalanceRequest accountBalanceRequest = new AccountBalanceRequest(corporation);

            if (corporation.NextAccountBalanceUpdate <= DateTime.Now)
            {
                IEnumerable<AccountBalance> accounts = accountBalanceRequest.Request();

                if (accountBalanceRequest.ErrorCode == 0)
                {
                    corporation.NextAccountBalanceUpdate = DateTime.Now.AddHours(1).AddMinutes(1);
                    return true;
                }
            }

            return false;
        }

        #endregion
    }
}
