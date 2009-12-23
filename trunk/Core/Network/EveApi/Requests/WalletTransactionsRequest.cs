using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Linq;
using Core.DomainModel;
using Core.DomainModel;
using Core.ClassExtenders;

namespace Core.Network.EveApi.Requests
{
    public class WalletTransactionsRequest : EveApiCharacterResourceRequest
    {
        protected override EveApiResourceType ResourceType
        {
            get 
            { 
                return EveApiResourceType.WalletTransactions;
            }
        }


        public WalletTransactionsRequest(Character character) : base (character.AccountId, character.ApiKey, character.Id)
        {
            
        }

        public IEnumerable<WalletTransaction> Request()
        {
            return this.Parse(base.GetResponseXml());
        }

        private IEnumerable<WalletTransaction> Parse(XDocument document)
        {
            return document.Descendants("row")
                             .Select(r => new WalletTransaction
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

        }
    }
}
