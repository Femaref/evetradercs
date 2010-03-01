using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Core.DomainModel;
using Core.Network.EveApi.Entities;
using Core.Network.EveApi.Requests;
using Core.Updaters.UpdateBase;

namespace Core.Updaters
{
    public class MarketOrdersUpdater : ICharacterUpdater<IMarketOrder>, ICharacterUpdater, ICorporationUpdater, ICorporationUpdater<IMarketOrder>
    {
        #region Implementation of IEntityUpdater<IMarketOrder>

        public bool UpdateEntity(IMarketOrder entity)
        {
            MarketOrdersRequest marketOrdersRequest = new MarketOrdersRequest(entity);

            if (entity.NextMarketOrdersUpdateTime <= DateTime.Now)
            {
                IEnumerable<MarketOrder> marketOrders = marketOrdersRequest.Request();

                if (marketOrdersRequest.ErrorCode == 0)
                {
                    entity.MarketOrders = marketOrders.OrderByDescending(p => p.Id).ToList();
                    entity.NextMarketOrdersUpdateTime = DateTime.Now.AddHours(1).AddMinutes(1);
                    return true;
                }
            }

            return false;
        }

        #endregion

        #region Implementation of ICharacterUpdater

        public bool UpdateCharacter(Character character)
        {
            return UpdateEntity(character);
        }

        #endregion

        #region Implementation of ICorporationUpdater<IMarketOrder>

        public bool UpdateCorporation(Corporation corporation)
        {
            return UpdateEntity(corporation);
        }

        #endregion
    }
}
