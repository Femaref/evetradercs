using System;
using System.Collections.Generic;
using System.Linq;
using Core.DomainModel;
using Core.Network.EveApi.Requests;
using Core.Updaters.UpdateBase;

namespace Core.Updaters
{
    public class CharacterStandingUpdater : ICharacterUpdater
    {
        public bool UpdateCharacter(Character character)
        {
            StandingRequest standingRequest = new StandingRequest(character);

            if (character.NextStandingUpdateTime <= DateTime.Now)
            {
                IEnumerable<Standing> standings = standingRequest.Request();

                if (standingRequest.ErrorCode == 0)
                {
                    character.Standings = standings.OrderBy(s => s.Type).ToList();
                    character.NextStandingUpdateTime.AddHours(3).AddMinutes(1);
                    return true;
                }
            }

            return false;
        }
    }
}
