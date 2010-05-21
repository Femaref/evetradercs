using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EveTrader.Core.Model;
using EveTrader.Core.ClassExtenders;

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
            if (document.ToString().Contains("error code="))
                throw new ArgumentException(string.Format("Api error encountered: {0}", this.ErrorCode));

            var root = document.Element("eveapi").Element("result").Element("rowset").Elements();

            var orders = root.Select(r => new MarketOrders
            {
                ID = 0,
                ExternalID = r.Attribute("orderID").Value.ToInt64(),
                Entity = new Entities(),
                StationID = r.Attribute("stationID").Value.ToInt64(),
                VolumeEntered = r.Attribute("volEntered").Value.ToInt64(),
                VolumeRemaining = r.Attribute("volRemaining").Value.ToInt64(),
                MinimumVolume = r.Attribute("minVolume").Value.ToInt64(),
                OrderState = (long)Enum.Parse(typeof(MarketOrderState), r.Attribute("orderState").Value),
                TypeID = r.Attribute("typeID").Value.ToInt64(),
                Range = r.Attribute("range").Value.ToInt64(),
                AccountKey = r.Attribute("accountKey").Value.ToInt64(),
                Duration = r.Attribute("duration").Value.ToInt64(),
                Escrow = r.Attribute("escrow").Value.ToDecimal(),
                Price = r.Attribute("price").Value.ToDecimal(),
                Bid = r.Attribute("bid").Value == "0",
                Issued = r.Attribute("issued").Value.ToDateTime()
            });

            return orders;
        }
    }
}
