using Core.DomainModel;

namespace Core.Updaters
{
    public class CharacterUpdater : ICharacterUpdater
    {
        public bool UpdateCharacter(Character character)
        {
            ICharacterUpdater walletTransactionsUpdater = new CharacterWalletTransactionsUpdater();
            ICharacterUpdater walletJournalUpdater = new CharacterWalletJournalUpdater();
            ICharacterUpdater marketOrdersUpdater = new CharacterMarketOrdersUpdater();
            //ICharacterUpdater assetsUpdater = new CharacterAssetsUpdater();
            ICharacterUpdater infoUpdater = new CharacterInfoUpdater();
            ICharacterUpdater standingUpdater = new CharacterStandingUpdater();

            bool updated = true;
                
            updated &= walletTransactionsUpdater.UpdateCharacter(character);
            updated &= walletJournalUpdater.UpdateCharacter(character);
            updated &= marketOrdersUpdater.UpdateCharacter(character);
            //updated &= assetsUpdater.UpdateCharacter(character);
            updated &= infoUpdater.UpdateCharacter(character);
            updated &= standingUpdater.UpdateCharacter(character);

            return updated;
        }
    }
}
