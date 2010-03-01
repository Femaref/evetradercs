using Core.DomainModel;
using Core.Network.EveApi.Entities;
using Core.Updaters;

namespace Core.Updaters.UpdateBase
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
