using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Core.DomainModel;
using Core.Network.EveApi.Requests;
using Core.DomainModel;
using Core.Updaters.DataRequest;
using Core.Network.EveApi.Requests;

namespace Core.Updaters
{
    public class CharacterInfoUpdater : ICharacterUpdater
    {
        public bool UpdateCharacter(Character character)
        {
            CharacterSheetRequest characterSheetRequest = new CharacterSheetRequest(character);
            
            try
            {
                characterSheetRequest.Request(); // updates passed character inside}
                return characterSheetRequest.ErrorCode == 0;
            }
            catch
            {
                return false;
            }
        }
    }
}
