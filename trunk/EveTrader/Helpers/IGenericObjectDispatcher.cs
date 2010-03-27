using System;
using System.Collections.Generic;
using Core.DomainModel;

namespace EveTrader.Helpers
{
    public interface IGenericObjectDispatcher
    {
        bool Add(IGenericObject obj);
        bool AddRange(IEnumerable<IGenericObject> objects);
        IEnumerable<T> GetByType<T>() where T : IGenericObject;
        IEnumerable<T> GetByType<T>(Func<T, bool> predicate) where T : IGenericObject;
        IGenericObject GetByID(int id);
        void RemoveRange(IEnumerable<IGenericObject> range);
        int RemoveAll<T>(Func<T, bool> where);
        int RemoveAll<T>();
        bool Remove(IGenericObject item);
        int Count { get; }
        event EventHandler<ObjectAddedEventArgs> ObjectAdded;
    }
}