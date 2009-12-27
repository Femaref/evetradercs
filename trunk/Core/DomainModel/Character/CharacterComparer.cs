using System.Collections.Generic;

namespace Core.DomainModel
{
    public class CharacterComparer : IEqualityComparer<Character>
    {
        public bool Equals(Character character1, Character character2)
        {
            return character1.Id == character2.Id;
        }

        public int GetHashCode(Character character)
        {
            return character.Id;
        }
    }
}
