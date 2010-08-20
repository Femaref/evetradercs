using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.Diagnostics;
using System.Threading;

namespace EveTrader.Core.Collections.ObjectModel
{
    /// <summary>
    /// This class extends ObervableCollection and adds AddRange() support, as well with dispatcher thread invoking for multithreading.
    /// Original Code from http://www.damonpayne.com/Permalink.aspx?title=AddRangeForObservableCollectionInSilverlight3&date=2010-03-04
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class SmartObservableCollection<T> : ObservableCollection<T>
    {
        [DebuggerStepThrough]
        public SmartObservableCollection(Action<Action> dispatchingAction = null)
            : base()
        {
            iSuspendCollectionChangeNotification = false;
            if (dispatchingAction != null)
                iDispatchingAction = dispatchingAction;
            else
                iDispatchingAction = a => a();

        }


        private bool iSuspendCollectionChangeNotification;
        private Action<Action> iDispatchingAction;

        [DebuggerStepThrough]
        protected override void OnCollectionChanged(NotifyCollectionChangedEventArgs e)
        {
            if (!iSuspendCollectionChangeNotification)
            {
                iDispatchingAction(() =>
                {
                    base.OnCollectionChanged(e);
                });
            }
        }
        [DebuggerStepThrough]
        public void SuspendCollectionChangeNotification()
        {
            iSuspendCollectionChangeNotification = true;
        }
        [DebuggerStepThrough]
        public void ResumeCollectionChangeNotification()
        {
            iSuspendCollectionChangeNotification = false;
        }

        [DebuggerStepThrough]
        public void AddRange(IEnumerable<T> items)
        {
            this.SuspendCollectionChangeNotification();
            try
            {
                foreach (var i in items)
                {
                    base.InsertItem(base.Count, i);
                }
            }
            finally
            {
                this.ResumeCollectionChangeNotification();
                var arg = new NotifyCollectionChangedEventArgs(NotifyCollectionChangedAction.Reset);
                this.OnCollectionChanged(arg);
            }
        }

    }
}
