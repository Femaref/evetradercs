using System;
using System.Collections.Generic;
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
                    corporation.AllianceID = c.AllianceID;
                    corporation.AllianceName = c.AllianceName;
                    corporation.CeoID = c.CeoID;
                    corporation.CeoName = c.CeoName;
                    corporation.Description = c.Description;
                    corporation.Divisions = new List<SerializableKeyValuePair<int, string>>(c.Divisions);
                    corporation.HeadquarterStationID = c.HeadquarterStationID;
                    corporation.HeadquarterStationName = c.HeadquarterStationName;
                    corporation.ID = c.ID;
                    corporation.Logo = c.Logo;
                    corporation.MemberCount = c.MemberCount;
                    corporation.MemberLimit = c.MemberLimit;
                    corporation.Name = c.Name;
                    corporation.Shares = c.Shares;
                    corporation.TaxRate = c.TaxRate;
                    corporation.Ticker = c.Ticker;
                    corporation.Url = c.Url;
                    corporation.WalletDivisions = c.WalletDivisions;

                    corporation.NextCorporationSheetUpdateTime = DateTime.Now.AddHours(6).AddMinutes(1);

                    return true;
                }
            }
            return false;
        }

        #endregion
    }
}
