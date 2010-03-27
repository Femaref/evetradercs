using System;
using System.Collections.Generic;
using System.Linq;
using Core.DomainModel;
using Core.Network.EveApi.Entities;
using Core.Network.EveApi.Requests;
using Core.Updaters.UpdateBase;

namespace Core.Updaters
{
    public class StandingUpdater : ICharacterUpdater, ICharacterUpdater<IStanding>
    {
        public bool UpdateCharacter(Character character)
        {
            return UpdateEntity(character);
        }

        #region IEntityUpdater<IStanding> Members

        public bool UpdateEntity(IStanding entity)
        {
            StandingRequest standingRequest = new StandingRequest(entity);

            if (entity.NextStandingUpdateTime <= DateTime.Now)
            {
                IEnumerable<Standing> standings = standingRequest.Request();

                if (standingRequest.ErrorCode == 0)
                {
                    entity.Standings = standings.OrderBy(s => s.Type).ToList();
                    entity.NextStandingUpdateTime.AddHours(3).AddMinutes(1);
                    return true;
                }
            }

            return false;
        }

        #endregion
    }
}
