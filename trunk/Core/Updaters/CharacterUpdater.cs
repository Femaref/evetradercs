using System;
using System.Collections.Generic;
using System.Diagnostics;
using Core.DomainModel;
using Core.Network;

namespace Core.Updaters
{
    public class CharacterUpdater : ICharacterUpdater
    {
        public bool UpdateCharacter(Character character)
        {
            character.Corporation.ApiData = new Account()
                                                {
                                                    UserID = character.AccountId,
                                                    ApiKey = character.ApiKey,
                                                    CharacterID = character.Id
                                                };

            List<ICharacterUpdater> updater = new List<ICharacterUpdater>()
                                                  {

                                                      new CharacterWalletTransactionsUpdater(),
                                                      new CharacterWalletJournalUpdater(),
                                                      new CharacterMarketOrdersUpdater(),
                                                      //new CharacterAssetsUpdater(),
                                                      new CharacterInfoUpdater(),
                                                      new CharacterStandingUpdater(),
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
