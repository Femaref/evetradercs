using System.Collections.Generic;

namespace Core.DomainModel
{
    public class CharacterComparer : IEqualityComparer<Character>
    {
        public bool Equals(Character character1, Character character2)
        {
            return character1.ID == character2.ID;
        }

        public int GetHashCode(Character character)
        {
            return character.ID;
        }
    }
}
