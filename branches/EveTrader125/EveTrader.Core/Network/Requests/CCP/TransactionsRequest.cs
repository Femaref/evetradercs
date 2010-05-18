using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EveTrader.Core.Model;

namespace EveTrader.Core.Network.Requests.CCP
{
    public class TransactionsRequest : ApiEntityRequestBase<IEnumerable<ApiTransactions>>
    {
        protected readonly long? iBeforeTransID;
        protected readonly long iAccountKey;

        public TransactionsRequest(Accounts a, long characterID, ApiRequestTarget target, long? beforeTransID, long accountKey = 1000)
            : base(a, characterID, target)
        {
            iBeforeTransID = beforeTransID;
            iAccountKey = accountKey;

            if (beforeTransID.HasValue)
                iData.Add("beforeTransID", beforeTransID.Value.ToString());

            iData.Add("accountKey", accountKey.ToString());
        }

        public override ApiRequestPage Page
        {
            get { return ApiRequestPage.WalletTransactions; }
        }

        protected override IEnumerable<ApiTransactions> Parse(System.Xml.Linq.XDocument document)
        {
            throw new NotImplementedException();
        }
    }
}
