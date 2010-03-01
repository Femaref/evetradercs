using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Core.DomainModel;
using Core.ClassExtenders;
using Core.Network.EveApi.Entities;

namespace Core.Network.EveApi.Requests
{
    public class AccountBalanceRequest : EveApiEntityRequest<IEnumerable<IAccountBalance>>
    {
        public AccountBalanceRequest(IAccount account)
            : this(account.ApiData, account.RequestFrom)
        {
        }
        public AccountBalanceRequest(Account account, EveApiResourceFrom from)
            : base(account, from)
        {

        }

        public override IEnumerable<IAccountBalance> Request()
        {
            return this.Parse(base.GetResponseXml());
        }

        private IEnumerable<IAccountBalance> Parse(System.Xml.Linq.XDocument document)
        {
            if (document.ToString().Contains("error code="))
                return new List<IAccountBalance>();

            var root = document.Element("eveapi").Element("result").Element("rowset");
            var balances = (from x in root.Elements()
                            select (IAccountBalance)new Wallet()
                                       {
                                           ID = x.Attribute("accountID").Value.ToInt32(),
                                           Balance = x.Attribute("balance").Value.ToDecimal(),
                                           Key = x.Attribute("accountKey").Value.ToInt32()
                                       });
            return balances;
        }

        protected override EveApiResourceType ResourceType
        {
            get { return EveApiResourceType.AccountBalance; }
        }

    }
}
