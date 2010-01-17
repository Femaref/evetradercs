using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;
using Core.ClassExtenders;
using Core.DomainModel;

namespace Core.Network.EveApi.Requests
{
    public class MarketOrdersRequest : EveApiCharacterResourceRequest<IEnumerable<MarketOrder>>
    {
        protected override EveApiResourceType ResourceType
        {
            get 
            {
                return EveApiResourceType.MarketOrders;
            }
        }

        public MarketOrdersRequest(Character character) : base (character)
        {
        }

        public override IEnumerable<MarketOrder> Request()
        {
            return this.Parse(base.GetResponseXml());
        }

        private IEnumerable<MarketOrder> Parse(XDocument document)
        {
            return document.Descendants("row")
                             .Select(r => new MarketOrder
                             {
                                 Id = r.Attribute("orderID").Value.ToInt32(),
                                 CharacterId = r.Attribute("charID").Value.ToInt32(),
                                 StationId = r.Attribute("stationID").Value.ToInt32(),
                                 VolumeEntered = r.Attribute("volEntered").Value.ToInt32(),
                                 VolumeRemaining = r.Attribute("volRemaining").Value.ToInt32(),
                                 VolumeMinimum = r.Attribute("minVolume").Value.ToInt32(),
                                 OrderState = (MarketOrderState) Enum.Parse(typeof(MarketOrderState), r.Attribute("orderState").Value),
                                 TypeId = r.Attribute("typeID").Value.ToInt32(),
                                 Range = r.Attribute("range").Value.ToInt32(),
                                 AccountKey = r.Attribute("accountKey").Value.ToInt32(),
                                 Duration = r.Attribute("duration").Value.ToInt32(),
                                 Escrow = r.Attribute("escrow").Value.ToDouble(),
                                 Price = r.Attribute("price").Value.ToDouble(),
                                 Type = r.Attribute("bid").Value == "0" ? MarketOrderType.Sell : MarketOrderType.Buy,
                                 Issued = r.Attribute("issued").Value.ToDateTime()
                             });

        }
    }
}
