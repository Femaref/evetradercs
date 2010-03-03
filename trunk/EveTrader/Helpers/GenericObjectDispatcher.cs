using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Core.DomainModel;

namespace EveTrader.Helpers
{
    public class GenericObjectDispatcher
    {
        private object iLocker = new object();
        private List<IGenericObject> iObjects = new List<IGenericObject>();

        public GenericObjectDispatcher(IEnumerable<IGenericObject> input)
        {
            iObjects = new List<IGenericObject>(input);
        }

        public bool Add(IGenericObject obj)
        {
            lock(iLocker)
            {
                if(obj.ObjectID == -1)
                {
                    obj.ObjectID = iObjects.Max(io => io.ObjectID) + 1;
                }
                if(iObjects.Count(io => io.ObjectID == obj.ObjectID) == 0)
                {
                    iObjects.Add(obj);
                    OnObjectAdded(obj);
                    return true;
                }
                return false;
            }
        }

        public IEnumerable<T> GetByType<T> ()
        {
            lock (iLocker)
            {
                return iObjects.OfType<T>();
            }
        }
        public IEnumerable<T> GetByType<T> (Func<T, bool> predicate)
        {
            lock (iLocker)
            {
                return iObjects.OfType<T>().Where(predicate);
            }
            
        }
        public IGenericObject GetByID (int id)
        {
            lock (iLocker)
            {
                return iObjects.Single(go => go.ObjectID == id);
            }
        }
        IGenericObject this[int index]
        {
            get
            {
                return GetByID(index);
            }
            set
            {
                lock(iLocker)
                {
                    iObjects.RemoveAll(go => go.ObjectID == index);
                    iObjects.Add(value);
                }
            }
        }

        public event EventHandler<ObjectAddedEventArgs> ObjectAdded;

        private void OnObjectAdded(IGenericObject obj)
        {
            EventHandler<ObjectAddedEventArgs> handler = ObjectAdded;

            if(handler != null)
                handler(this, new ObjectAddedEventArgs(obj.GetType(), obj));

        }
    }
}
