using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EveTrader.Core.Model;

namespace EveTrader.Core.Network.Requests.CCP
{
    public class MarketOrdersRequest : ApiEntityRequestBase<IEnumerable<MarketOrders>>
    {
        public MarketOrdersRequest(Accounts a, long characterID, ApiRequestTarget target)
            : base(a, characterID, target)
        {
        }

        public override ApiRequestPage Page
        {
            get { return ApiRequestPage.MarketOrders; }
        }
        protected override IEnumerable<MarketOrders> Parse(System.Xml.Linq.XDocument document)
        {
            throw new NotImplementedException();
        }
    }
}
