using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Xml.Linq;
using Core.ClassExtenders;
using Core.DomainModel;
using Core.Updaters;

namespace Core.Network.EveApi.Requests
{
    public class WalletJournalRequest : EveApiEntityRequest<IEnumerable<WalletJournalRecord>>
    {
        protected override EveApiResourceType ResourceType
        {
            get
            {
                return EveApiResourceType.WalletJournal;
            }
        }
        protected override IList<ResourceRequestParameter> Parameters
        {
            get
            {
                IList<ResourceRequestParameter> parameters = base.Parameters;
                parameters.Add(new ResourceRequestParameter { Name = "accountKey", Value = this.iAccountKey.ToString() });
                return parameters;
            }
        }

        private int iAccountKey;

        public WalletJournalRequest(IAccount account, int accountKey)
            : this(account.ApiData, account.RequestFrom, accountKey)
        {
        }
        public WalletJournalRequest(Account account, EveApiResourceFrom from, int accountKey)
            : base(account, from)
        {
            this.iAccountKey = accountKey;
        }

        public override IEnumerable<WalletJournalRecord> Request()
        {
            return this.Parse(base.GetResponseXml());
        }

        private IEnumerable<WalletJournalRecord> Parse(XDocument document)
        {
            if (this.ErrorCode != 0)
            {
                Debug.WriteLine(this.ToString());
                return null;
            }


            var root = document.Element("eveapi").Element("result").Element("rowset").Elements();

            var records = root.Select(r => new WalletJournalRecord
                                               {
                                                   Date = r.Attribute("date").Value.ToDateTime().LocalizeEveTime(),
                                                   ReferenceID = r.Attribute("refID").Value.ToInt64(),
                                                   ReferenceTypeID = r.Attribute("refTypeID").Value.ToInt32(),
                                                   Amount = r.Attribute("amount").Value.ToDouble(),
                                                   Balance = r.Attribute("balance").Value.ToDouble(),
                                                   TaxAmount =
                                                       r.Attribute("taxAmount") != null
                                                           ? r.Attribute("taxAmount").Value.ToDecimal()
                                                           : 0,
                                                   TaxReceiverID =
                                                       r.Attribute("taxReceiverID") != null
                                                           ? r.Attribute("taxReceiverID").Value.ToInt32()
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
    }
}
