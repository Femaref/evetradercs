using System;
using System.Collections.Generic;
using Core.DomainModel;
using Core.Network.EveApi.Requests;

namespace Core.Updaters
{
    public class CharacterAssetsUpdater : ICharacterUpdater
    {
        public bool UpdateCharacter(Character character)
        {
            AssetsRequest assetsRequest = new AssetsRequest(character);

            if (character.NextAssetsUpdateTime <= DateTime.Now)
            {
                List<Asset> assets = assetsRequest.Request();

                if (assetsRequest.ErrorCode == 0)
                {
                    character.Assets = assets;
                    character.NextAssetsUpdateTime = DateTime.Now.AddHours(1).AddMinutes(1);
                    return true;
                }
            }

            return false;
        }
    }
}
