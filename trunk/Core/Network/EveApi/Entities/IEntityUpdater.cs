using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Core.Updaters;

namespace Core.DomainModel
{
    public interface IEntityUpdater<T> where T : IEntity
    {
        bool UpdateEntity(T entity);
    }
}
