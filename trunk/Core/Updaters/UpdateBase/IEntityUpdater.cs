using Core.Network.EveApi.Entities;

namespace Core.Updaters.UpdateBase
{
    public interface IEntityUpdater<T> where T : IEntity
    {
        bool UpdateEntity(T entity);
    }
}