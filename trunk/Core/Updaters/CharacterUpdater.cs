using System;
using System.Collections.Generic;
using System.Diagnostics;
using Core.DomainModel;
using Core.Network;
using Core.Updaters.UpdateBase;

namespace Core.Updaters
{
    public class CharacterUpdater : ICharacterUpdater
    {
        public bool UpdateCharacter(Character character)
        {
            if (character.ApiData == null)
            {
                character.ApiData = new Account()
                                        {
                                            UserID = character.AccountId,
                                            ApiKey = character.ApiKey,
                                            CharacterID = character.ID
                                        };
                character.Corporation.ApiData = character.ApiData;
            }

            List<ICharacterUpdater> updater = new List<ICharacterUpdater>()
                                                  {
                                                      new WalletUpdater(),
                                                      new MarketOrdersUpdater(),
                                                      //new CharacterAssetsUpdater(),
                                                      new CharacterInfoUpdater(),
                                                      new StandingUpdater(),
                                                      new CorporationUpdater(),
                                                  };

            bool updated = true;

            Action<ICharacterUpdater> iter = ic =>
                                                 {
                                                     if (!ic.UpdateCharacter(character))
                                                     {
                                                         Debug.WriteLine(
                                                             "Update failed in " +
                                                             ic.GetType().Namespace +
                                                             ic.GetType().Name);
                                                         updated &= false;
                                                     }
                                                     else return;
                                                 };

            updater.ForEach(iter);

            return updated;
        }
    }
}
