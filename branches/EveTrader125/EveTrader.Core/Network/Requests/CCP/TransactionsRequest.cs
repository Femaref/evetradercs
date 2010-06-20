using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EveTrader.Core.Model;
using EveTrader.Core.ClassExtenders;

namespace EveTrader.Core.Network.Requests.CCP
{
    public class TransactionsRequest : ApiEntityRequestBase<IEnumerable<ApiTransactions>>
    {
        protected readonly long? iBeforeTransID;
        protected readonly long iAccountKey;

        public TransactionsRequest(Accounts a, long characterID, ApiRequestTarget target, Func<string, TimeSpan, bool> stillCached, Action<string, DateTime, string> saveCache, Func<string, string> loadCache, long? beforeTransID, long accountKey = 1000)
            : base(a, characterID, target, stillCached, saveCache, loadCache)
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
            if (document.ToString().Contains("error code="))
                throw new ArgumentException(string.Format("Api error encountered: {0}", this.ErrorCode));

            var root = document.Element("eveapi").Element("result").Element("rowset").Elements();

            var transactions = root.Select(r => new ApiTransactions
            {
                ExternalID = r.Attribute("transactionID").Value.ToInt64(),
                TransactionFor = r.Attribute("transactionFor").Value == "personal" ? (long)TransactionFor.Personal : (long)TransactionFor.Corporation,
                TransactionType = r.Attribute("transactionType").Value == "sell" ? (long)TransactionType.Sell : (long)TransactionType.Buy,
                DateTime = r.Attribute("transactionDateTime").Value.ToDateTime(),
                Date = r.Attribute("transactionDateTime").Value.ToDateTime().Date,
                Quantity = r.Attribute("quantity").Value.ToInt64(),
                Price = r.Attribute("price").Value.ToDecimal(),
                TypeID = r.Attribute("typeID").Value.ToInt64(),
                TypeName = r.Attribute("typeName").Value,
                ClientID = r.Attribute("clientID").Value.ToInt64(),
                ClientName = r.Attribute("clientName").Value,
                StationID = r.Attribute("stationID").Value.ToInt64(),
                StationName = r.Attribute("stationName").Value
            });

            return transactions;
        }

        public override TimeSpan CachingTime
        {
            get { return new TimeSpan(1, 0, 0); }
        }
    }
}
