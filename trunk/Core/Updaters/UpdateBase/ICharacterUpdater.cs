using Core.Updaters;

namespace Core.DomainModel
{
    public interface ICharacterUpdater<T> : IEntityUpdater<T> where T:IEntity
    {
        bool UpdateCharacter(Character character);
    }
    public interface ICharacterUpdater
    {
        bool UpdateCharacter(Character character);
    }
}
