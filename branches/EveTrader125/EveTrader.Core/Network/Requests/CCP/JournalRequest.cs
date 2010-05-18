using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EveTrader.Core.Model;

namespace EveTrader.Core.Network.Requests.CCP
{
    public class JournalRequest : ApiEntityRequestBase<IEnumerable<Journal>>
    {
        protected readonly long iAccountKey;
        protected readonly long? iBeforeRefID;

        public JournalRequest (Accounts a, long characterID, ApiRequestTarget target, long? beforeRefID, long accountKey = 1000)
            : base(a, characterID, target)
        {
            iBeforeRefID = beforeRefID;
            iAccountKey = accountKey;

            if (beforeRefID.HasValue)
                iData.Add("beforeRefID", beforeRefID.Value.ToString());

            iData.Add("accountKey", accountKey.ToString());
        }

        public override ApiRequestPage Page
        {
            get { return ApiRequestPage.WalletJournal; }
        }
        protected override IEnumerable<Journal> Parse(System.Xml.Linq.XDocument document)
        {
            throw new NotImplementedException();
        }
    }
}
