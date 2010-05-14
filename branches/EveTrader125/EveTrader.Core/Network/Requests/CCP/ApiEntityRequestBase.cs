using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EveTrader.Core.Model;

namespace EveTrader.Core.Network.Requests.CCP
{
    public abstract class ApiEntityRequestBase<T> : ApiAccountRequestBase<T>
    {
        protected long iCharacterID = 0;

        public ApiEntityRequestBase(Accounts a, long characterID)
            : base(a)
        {
            iCharacterID = characterID;
            this.iData.Add("characterID", iCharacterID.ToString());
        }
    }
}
