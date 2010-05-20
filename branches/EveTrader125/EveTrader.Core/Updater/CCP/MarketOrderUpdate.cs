using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EveTrader.Core.Model;
using EveTrader.Core.Network.Requests.CCP;

namespace EveTrader.Core.Updater.CCP
{
    public class MarketOrderUpdate : UpdaterBase<Entities>
    {
        public MarketOrderUpdate(TraderModel tm)
            : base(tm)
        {
        }

        protected override bool InnerUpdate(Entities entity)
        {
            MarketOrdersRequest abr = null;

            if (entity is Characters)
                abr = new MarketOrdersRequest(entity.Account, entity.ID, ApiRequestTarget.Character);
            if (entity is Corporations)
                abr = new MarketOrdersRequest(entity.Account, (entity as Corporations).ApiCharacterID, ApiRequestTarget.Corporation);

            var data = abr.Request();

            foreach (var item in data)
            {
                var current = entity.MarketOrders.FirstOrDefault(mo => mo.ID == item.ID);
                if (current == null)
                {
                    item.Entity = entity;
                    entity.MarketOrders.Add(item);
                }
                else
                {
                    current.Duration = item.Duration;
                    current.Escrow = item.Escrow;
                    current.OrderState = item.OrderState;
                    current.Price = item.Price;
                    current.VolumeRemaining = item.VolumeRemaining;
                }
            }
            iModel.SaveChanges();

            return true;
        }
    }
}
