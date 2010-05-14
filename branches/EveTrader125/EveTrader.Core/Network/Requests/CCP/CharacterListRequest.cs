using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EveTrader.Core.Model;
using EveTrader.Core.ClassExtenders;

namespace EveTrader.Core.Network.Requests.CCP
{
    public class CharacterListRequest : ApiAccountRequestBase<IEnumerable<Characters>>
    {
        public CharacterListRequest(Accounts a)
            : base(a)
        {
        }

        public override ApiRequestPage Page
        {
            get
            {
                return ApiRequestPage.CharactersList;
            }
        }
        public override ApiRequestTarget Target
        {
            get
            {
                return ApiRequestTarget.Account;
            }
        }


        protected override IEnumerable<Characters> Parse(System.Xml.Linq.XDocument doc)
        {
            return doc.Descendants("row").Select(r => new Characters
                 {
                     ID = r.Attribute("characterID").Value.ToInt32(),
                     Name = r.Attribute("name").Value,
                     Account = this.iAccount,
                     Corporation = new Corporations() { ID = r.Attribute("corporationID").Value.ToInt32(), Name = r.Attribute("corporationName").Value, Account = this.iAccount }
                 });
        }
    }
}
