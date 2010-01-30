using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Core.Network;
using Core.Network.EveApi;

namespace Core.DomainModel
{
    public interface ISubEntityUpdater<TInput> where TInput : ISubEntity
    {
        bool UpdateSubEntity (TInput subEntity, Account apiData, EveApiResourceFrom from);
    }
}
