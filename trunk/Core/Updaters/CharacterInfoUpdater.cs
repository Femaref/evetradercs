using Core.DomainModel;
using Core.Network.EveApi.Requests;

namespace Core.Updaters
{
    public class CharacterInfoUpdater : ICharacterUpdater<Character>, ICharacterUpdater
    {

        public bool UpdateEntity(Character entity)
        {
            CharacterSheetRequest characterSheetRequest = new CharacterSheetRequest(entity);

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

        #region ICharacterUpdater<Character> Members

        public bool UpdateCharacter(Character character)
        {
            return this.UpdateEntity(character);
        }

        #endregion
    }
}
