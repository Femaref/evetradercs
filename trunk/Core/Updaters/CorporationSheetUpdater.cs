using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Core.DomainModel;
using Core.Network.EveApi.Requests;

namespace Core.Updaters
{
    public class CorporationSheetUpdater : ICorporationUpdater
    {
        #region ICharacterUpdater Members

        public bool UpdateCorporation(Corporation corporation)
        {
            CorporationSheetRequest corporationSheetRequest = new CorporationSheetRequest(corporation);

            if (corporation.NextCorporationSheetUpdateTime <= DateTime.Now)
            {
                Corporation c = corporationSheetRequest.Request();

                if (corporationSheetRequest.ErrorCode == 0)
                {
                    corporation.NextCorporationSheetUpdateTime = DateTime.Now.AddHours(6).AddMinutes(1);
                    return true;
                }
            }
            return false;
        }

        #endregion
    }
}
