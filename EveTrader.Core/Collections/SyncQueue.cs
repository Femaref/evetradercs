using System;
using System.Collections.Generic;
using System.Threading;

namespace EveTrader.Core.Collections
{
    //*****************************************************************************
    public class SyncQueue<T>
    {
        //--------------------------------------------------------------------------
        private Queue<T> _q = new Queue<T>();
        private AutoResetEvent _are = new AutoResetEvent(false);

        //==========================================================================
        // Enqueues an element without waiting
        public void Enqueue(T tItem)
        {
            lock (this)
            {
                _q.Enqueue(tItem);
                if (_q.Count == 1)
                {
                    _are.Set();
                }
            }
        }

        //==========================================================================
        // Dequeues an element from the inner queue, waits if no element is present
        //
        // This queue only works if there is one thread dequeueing. If multiple workers
        // are present, it could be tried to dequeue an element from the inner queue even
        // though none are present
        public T Dequeue()
        {
            lock (this)
            {
                if (_q.Count > 0)
                {
                    if (_q.Count == 1)
                    {
                        _are.Reset();
                    }
                    return _q.Dequeue();
                }
            }
            _are.WaitOne();
            lock (this)
            {
                return _q.Dequeue();
            }
        }
    }
}
