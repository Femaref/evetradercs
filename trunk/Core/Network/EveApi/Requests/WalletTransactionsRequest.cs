using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Xml.Linq;
using Core.ClassExtenders;
using Core.DomainModel;

namespace Core.Network.EveApi.Requests
{
    public class WalletTransactionsRequest : EveApiEntityRequest<IEnumerable<WalletTransaction>>
    {
        protected override EveApiResourceType ResourceType
        {
            get
            {
                return EveApiResourceType.WalletTransactions;
            }
        }
        protected override IList<ResourceRequestParameter> Parameters
        {
            get
            {
                IList<ResourceRequestParameter> parameters = base.Parameters;
                parameters.Add(new ResourceRequestParameter { Name = "accountKey", Value = this.iAccountKey.ToString() });
                parameters.Add(new ResourceRequestParameter() {Name = "beforeTransID", Value = this.iBeforeTransID.ToString()});
                return parameters;
            }
        }

        private int iAccountKey;
        private int iBeforeTransID = 0;

        public WalletTransactionsRequest(IAccount account, int accountKey)
            : this(account.ApiData, account.RequestFrom, accountKey)
        {
        }
        public WalletTransactionsRequest(Account account, EveApiResourceFrom from, int accountKey)
            : base(account, from)
        {
            this.iAccountKey = accountKey;
        }

        public override IEnumerable<WalletTransaction> Request()
        {
            return this.Parse(base.GetResponseXml());
        }

        public IEnumerable<WalletTransaction> Request(int beforeTransID)
        {
            this.iBeforeTransID = beforeTransID;
            return Request();
        }

        private IEnumerable<WalletTransaction> Parse(XDocument document)
        {
            if (this.ErrorCode != 0)
            {
                Debug.WriteLine(this.ToString());
                return null;
            }
               

            var root = document.Element("eveapi").Element("result").Element("rowset").Elements();

            var transactions = root.Select(r => new WalletTransaction
                             {
                                 TransactionID = r.Attribute("transactionID").Value.ToInt32(),
                                 TransactionFor = r.Attribute("transactionFor").Value == "personal" ? WalletTransactionFor.Personal : WalletTransactionFor.Undefined,
                                 TransactionType = r.Attribute("transactionType").Value == "sell" ? WalletTransactionType.Sell : WalletTransactionType.Buy,
                                 TransactionDateTime = r.Attribute("transactionDateTime").Value.ToDateTime().LocalizeEveTime(),
                                 Quantity = r.Attribute("quantity").Value.ToInt32(),
                                 Price = r.Attribute("price").Value.ToDouble(),
                                 TypeID = r.Attribute("typeID").Value.ToInt32(),
                                 TypeName = r.Attribute("typeName").Value,
                                 ClientID = r.Attribute("clientID").Value.ToInt32(),
                                 ClientName = r.Attribute("clientName").Value,
                                 StationID = r.Attribute("stationID").Value.ToInt32(),
                                 StationName = r.Attribute("stationName").Value
                             });

            return transactions;

        }
    }
}
