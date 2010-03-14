using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Core.DomainModel;

namespace EveTrader.Helpers
{
    public class XmlGenericObjectDispatcher : IGenericObjectDispatcher
    {
        private object iLocker = new object();
        private List<IGenericObject> iObjects = new List<IGenericObject>();

        public XmlGenericObjectDispatcher(IEnumerable<IGenericObject> input)
        {
            iObjects = new List<IGenericObject>(input);
        }
        public XmlGenericObjectDispatcher()
        {
        }

        public bool Add(IGenericObject obj)
        {
            lock (iLocker)
            {
                if (obj.ObjectID == -1 || iObjects.Count(io => io.ObjectID == obj.ObjectID) != 0)
                {
                    obj.ObjectID = iObjects.Max(io => io.ObjectID) + 1;
                }
                if (iObjects.Count(io => io.ObjectID == obj.ObjectID) == 0)
                {
                    iObjects.Add(obj);
                    OnObjectAdded(obj);
                    return true;
                }
                return false;
            }
        }
        public bool AddRange(IEnumerable<IGenericObject> objects)
        {
            lock (iLocker)
            {
                try
                {
                    foreach (IGenericObject obj in objects)
                    {
                        Add(obj);
                    }
                }
                catch (Exception)
                {
                    return false;
                }
            }
            return true;
        }

        public IEnumerable<T> GetByType<T>() where T : IGenericObject
        {
            lock (iLocker)
            {
                return iObjects.OfType<T>();
            }
        }
        public IEnumerable<T> GetByType<T>(Func<T, bool> predicate) where T : IGenericObject
        {
            lock (iLocker)
            {
                return iObjects.OfType<T>().Where(predicate);
            }

        }
        public IGenericObject GetByID(int id)
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
                lock (iLocker)
                {
                    iObjects.RemoveAll(go => go.ObjectID == index);
                    Add(value);
                }
            }
        }


        public void RemoveRange(IEnumerable<IGenericObject> range)
        {
            lock(iLocker)
            {
                iObjects.RemoveAll(go => range.Contains(go));
            }
        }
        public int RemoveAll(Predicate<IGenericObject> where)
        {
            lock (iLocker)
            {
                return iObjects.RemoveAll(where);
            }
        }
        public int RemoveAll<T>()
        {
            lock(iLocker)
            {
                return iObjects.RemoveAll(x => x.GetType() == typeof(T));
            }
        }
        public bool Remove(IGenericObject item)
        {
            lock (iLocker)
            {
                return iObjects.Remove(item);
            }
        }

        public int Count
        {
            get { return iObjects.Count; }
        }

        public event EventHandler<ObjectAddedEventArgs> ObjectAdded;

        private void OnObjectAdded(IGenericObject obj)
        {
            EventHandler<ObjectAddedEventArgs> handler = ObjectAdded;

            if (handler != null)
                handler(this, new ObjectAddedEventArgs(obj.GetType(), obj));

        }
    }
}
