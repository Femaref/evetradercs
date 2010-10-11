using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EveTrader.Core.Model.Trader;
using ClassExtenders;

namespace EveTrader.Core.Network.Requests.CCP
{
    public class JournalRequest : ApiEntityRequestBase<IEnumerable<ApiJournal>>
    {
        protected readonly long iAccountKey;
        protected readonly long? iBeforeRefID;

        public JournalRequest(Accounts a, long characterID, ApiRequestTarget target, Func<string, TimeSpan, bool> stillCached, Action<string, DateTime, string> saveCache, Func<string, string> loadCache, long? beforeRefID, long accountKey = 1000)
            : base(a,characterID, target, stillCached, saveCache, loadCache)
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
        protected override IEnumerable<ApiJournal> Parse(System.Xml.Linq.XDocument document)
        {
            if (document.ToString().Contains("error code="))
                throw new ArgumentException(string.Format("Api error encountered: {0}", this.ErrorCode));

            var root = document.Element("eveapi").Element("result").Element("rowset").Elements();

            var records = root.Select(r => new ApiJournal
            {
                Date = r.Attribute("date").Value.ToDateTime().Date,
                DateTime = r.Attribute("date").Value.ToDateTime(),
                ExternalID = r.Attribute("refID").Value.ToInt64(),
                RefTypeID = r.Attribute("refTypeID").Value.ToInt64(),
                Amount = r.Attribute("amount").Value.ToDecimal(),
                Balance = r.Attribute("balance").Value.ToDecimal(),
                TaxAmount =
                    r.Attribute("taxAmount") != null
                        ? r.Attribute("taxAmount").Value.ToDecimal()
                        : 0,
                TaxReceiverID =
                    r.Attribute("taxReceiverID") != null
                        ? r.Attribute("taxReceiverID").Value.ToInt64()
                        : 0,
                OwnerID1 = r.Attribute("ownerID1").Value.ToInt32(),
                OwnerName1 = r.Attribute("ownerName1").Value,
                OwnerID2 = r.Attribute("ownerID2").Value.ToInt32(),
                OwnerName2 = r.Attribute("ownerName2").Value,
                ArgID1 = r.Attribute("argID1").Value.ToInt32(),
                ArgName1 = r.Attribute("argName1").Value,
                Reason = r.Attribute("reason").Value
            });

            return records;
        }

        public override TimeSpan CachingTime
        {
            get { return new TimeSpan(1, 0, 0); }
        }
    }
}
