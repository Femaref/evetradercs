using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Core.DomainModel;
using Core.Network.EveApi.Requests;
using Core.DomainModel;

namespace Core.Updaters
{
    public class CharacterMarketOrdersUpdater : ICharacterUpdater
    {
        public bool UpdateCharacter(Character character)
        {
            MarketOrdersRequest marketOrdersRequest = new MarketOrdersRequest(character);

            if (character.NextMarketOrdersUpdateTime <= DateTime.Now)
            {
                IEnumerable<MarketOrder> marketOrders = marketOrdersRequest.Request();

                if (marketOrdersRequest.ErrorCode == 0)
                {
                    character.MarketOrders = marketOrders.OrderByDescending(p => p.Id).ToList();
                    character.NextMarketOrdersUpdateTime = DateTime.Now.AddHours(1).AddMinutes(1);
                    return true;
                }
            }

            return false;
        }
    }
}
