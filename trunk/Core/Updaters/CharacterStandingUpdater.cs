using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Core.DomainModel;
using Core.Network.EveApi.Requests;

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
                    return true;
                }
            }

            return false;
        }
    }
}
