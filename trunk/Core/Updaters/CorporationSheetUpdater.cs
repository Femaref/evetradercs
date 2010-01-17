using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Core.DomainModel;
using Core.Network.EveApi.Requests;

namespace Core.Updaters
{
    public class CorporationSheetUpdater : ICharacterUpdater
    {
        #region ICharacterUpdater Members

        public bool UpdateCharacter(Character character)
        {
            CorporationSheetRequest corporationSheetRequest = new CorporationSheetRequest(character);

            if (character.NextCorporationSheetUpdateTime <= DateTime.Now)
            {
                Corporation c = corporationSheetRequest.Request();

                if (corporationSheetRequest.ErrorCode == 0)
                {
                    character.Corporation = c;
                    character.NextCorporationSheetUpdateTime = DateTime.Now.AddHours(6).AddMinutes(1);
                    return true;
                }
            }
            return false;
        }

        #endregion
    }
}
