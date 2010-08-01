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
        public CharacterListRequest(Accounts a, Func<string, TimeSpan, bool> stillCached, Action<string, DateTime, string> saveCache, Func<string, string> loadCache)
      : base(a,ApiRequestTarget.Account, stillCached, saveCache, loadCache)
        {
        }

        public override ApiRequestPage Page
        {
            get
            {
                return ApiRequestPage.CharactersList;
            }
        }

        protected override IEnumerable<Characters> Parse(System.Xml.Linq.XDocument doc)
        {
            return doc.Descendants("row").Select(r => new Characters
                 {
                     ID = r.Attribute("characterID").Value.ToInt32(),
                     Name = r.Attribute("name").Value,
                     Account = this.iAccount,
                     Corporation = new Corporations() { ID = r.Attribute("corporationID").Value.ToInt32(), Name = r.Attribute("corporationName").Value, Account = this.iAccount, Ticker="" }
                 });
        }

        public override TimeSpan CachingTime
        {
            get { return new TimeSpan(0, 0, 0); }
        }
    }
}
