using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EveTrader.Core.Model;
using ClassExtenders;

namespace EveTrader.Core.Network.Requests.CCP
{
    public class AccountBalanceRequest : ApiEntityRequestBase<IEnumerable<Wallets>>
    {
        public AccountBalanceRequest(Accounts a, long characterID, ApiRequestTarget target, Func<string, TimeSpan, bool> stillCached, Action<string, DateTime, string> saveCache, Func<string, string> loadCache)
                      : base(a,characterID, target, stillCached, saveCache, loadCache)
        {
        }


        public override ApiRequestPage Page
        {
            get
            {
                return ApiRequestPage.AccountBalance;
            }
        }

        protected override IEnumerable<Wallets> Parse(System.Xml.Linq.XDocument document)
        {
            if (document.ToString().Contains("error code="))
                throw new ArgumentException(string.Format("Api error encountered: {0}", this.ErrorCode));

            var root = document.Element("eveapi").Element("result").Element("rowset");
            var balances = (from x in root.Elements()
                            select new Wallets()
                            {
                                ID = x.Attribute("accountID").Value.ToInt32(),
                                Balance = x.Attribute("balance").Value.ToDecimal(),
                                AccountKey = x.Attribute("accountKey").Value.ToInt32()
                            });
            return balances;
        }

        public override TimeSpan CachingTime
        {
            get { return new TimeSpan(0, 10, 0); }
        }
    }
}
