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
        private Account iAccount;
        private Corporation iCorp;

        public AccountBalanceRequest(Corporation input)
            : base(input)
        {
            this.iAccount = input.ApiData;
            this.iCorp = input;
        }

        public override IEnumerable<AccountBalance> Request()
        {
            return this.Parse(base.GetResponseXml());
        }

        private IEnumerable<AccountBalance> Parse(System.Xml.Linq.XDocument document)
        {
            if (document.ToString().Contains("error code="))
                return new List<AccountBalance>();

            var root = document.Element("eveapi").Element("result").Element("rowset");
            var balances = (from x in root.Elements()
                    select new AccountBalance()
                               {
                                   ID = x.Attribute("accountID").Value.ToInt32(),
                                   Balance = x.Attribute("balance").Value.ToDecimal(),
                                   Key = x.Attribute("accountKey").Value.ToInt32()
                               });
            this.iCorp.Wallets = new List<AccountBalance>(balances);
            return balances;
        }

        protected override EveApiResourceType ResourceType
        {
            get { return EveApiResourceType.AccountBalance; }
        }

    }
}
