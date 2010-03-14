using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Core.DomainModel;

namespace EveTrader.Helpers
{
    public class DispatcherList<T> : IList<T> where T : IGenericObject
    {
        private readonly XmlGenericObjectDispatcher iDispatcher;
        private readonly Func<T, bool> iFilter = x => 1==1;

        private List<T> iCurrentData;

        private readonly object iLocker = new object();

        public DispatcherList(XmlGenericObjectDispatcher dispatcher)
        {
            iDispatcher = dispatcher;
            Update();
        }
        public DispatcherList(XmlGenericObjectDispatcher dispatcher, Func<T, bool> filter)
        {
            iDispatcher = dispatcher;
            iFilter = filter;
            Update();
        }


        #region Implementation of IEnumerable

        public IEnumerator<T> GetEnumerator()
        {
            lock (iLocker)
            {
                return iCurrentData.GetEnumerator();
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        #endregion

        #region Implementation of ICollection<T>

        public void Add(T item)
        {
            iDispatcher.Add(item);
            Update();
        }

        private void Update()
        {
            lock (iLocker)
            {
                var cache = iDispatcher.GetByType(iFilter);
                if (iCurrentData != cache)
                    iCurrentData = new List<T>(iDispatcher.GetByType(iFilter));
            }
        }

        public void Clear()
        {
            iDispatcher.RemoveRange((IEnumerable<IGenericObject>)iCurrentData);
            Update();
        }

        public bool Contains(T item)
        {
            return iCurrentData.Contains(item);
        }

        public void CopyTo(T[] array, int arrayIndex)
        {
            iCurrentData.CopyTo(array, arrayIndex);
        }

        public bool Remove(T item)
        {
            return iDispatcher.Remove(item);
        }

        public int Count
        {
            get { return iCurrentData.Count(); }
        }

        public bool IsReadOnly
        {
            get { return false; }
        }

        #endregion

        #region Implementation of IList<T>

        public int IndexOf(T item)
        {
            lock(iLocker)
            {
                return iCurrentData.IndexOf(item);
            }
        }

        public void Insert(int index, T item)
        {
            iDispatcher.Add(item);
            Update();
        }

        public void RemoveAt(int index)
        {

            iDispatcher.Remove(iCurrentData[index]);
            Update();
        }

        public T this[int index]
        {
            get { return iCurrentData[index]; }
            set
            {
                iDispatcher.Add(value);
                Update();
            }
        }

        #endregion
    }
}
