using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EveTrader.Core.Model;
using EveTrader.Core.Network.Requests.CCP;
using System.ComponentModel.Composition;

namespace EveTrader.Core.Updater.CCP
{
    [Export(typeof(IMarketOrdersUpdater))]
    public class MarketOrdersUpdater : UpdaterBase<Entities>, IMarketOrdersUpdater
    {
        [ImportingConstructor]
        public MarketOrdersUpdater(TraderModel tm)
            : base(tm)
        {
        }

        protected override bool InnerUpdate<U>(U entity)
        {
            MarketOrdersRequest abr = null;

            if (entity is Characters)
                abr = new MarketOrdersRequest(entity.Account, entity.ID, ApiRequestTarget.Character, iModel.StillCached, iModel.SaveCache, iModel.LoadCache);
            if (entity is Corporations)
                abr = new MarketOrdersRequest(entity.Account, (entity as Corporations).ApiCharacterID, ApiRequestTarget.Corporation, iModel.StillCached, iModel.SaveCache, iModel.LoadCache);

            if (abr.UpdateAvailable)
            {
                var data = abr.Request();

                foreach (var item in data)
                {
                    var current = entity.MarketOrders.FirstOrDefault(mo => mo.ExternalID == item.ExternalID && mo.TypeID == item.TypeID);
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
            }
            return true;
        }
    }
}
