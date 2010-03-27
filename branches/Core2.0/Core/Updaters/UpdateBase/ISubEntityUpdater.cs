using Core.Network;
using Core.Network.EveApi;
using Core.Network.EveApi.Entities;

namespace Core.Updaters.UpdateBase
{
    public interface ISubEntityUpdater<TInput> where TInput : ISubEntity
    {
        bool UpdateSubEntity (TInput subEntity, Account apiData, EveApiResourceFrom from);
    }
}