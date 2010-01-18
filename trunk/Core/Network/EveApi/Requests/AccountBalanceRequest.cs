using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Core.DomainModel;
using Core.ClassExtenders;

namespace Core.Network.EveApi.Requests
{
    public class AccountBalanceRequest : EveApiCorporationResourceRequest<IEnumerable<AccountBalance>>
    {
        public AccountBalanceRequest(IAccount input)
            : base(input)
        {
        }

        public override IEnumerable<AccountBalance> Request()
        {
            return this.Parse(base.CachedResponseXml);
        }

        private IEnumerable<AccountBalance> Parse(System.Xml.Linq.XDocument document)
        {
            var root = document.Element("eveapi").Element("result").Element("rowset");
            return (from x in root.Elements()
                    select new AccountBalance()
                               {
                                   ID = x.Attribute("accountID").Value.ToInt32(),
                                   Balance = x.Attribute("balance").Value.ToDecimal(),
                                   Key = x.Attribute("accountKey").Value.ToInt32()
                               });

        }

        protected override EveApiResourceType ResourceType
        {
            get { return EveApiResourceType.AccountBalance; }
        }

    }
}
