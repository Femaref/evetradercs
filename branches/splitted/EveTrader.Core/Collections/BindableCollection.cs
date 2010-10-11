using System;
using System.Threading;
using System.ComponentModel;
using System.Collections.Generic;
using System.Windows.Threading;
using System.Collections.Specialized;
using System.Collections.ObjectModel;
using System.Diagnostics;

namespace Sheva.Windows.Data
{
    /// <summary>
    /// An ObservableCollection&lt;T&gt; enhanced with capability of free threading.
    /// </summary>
    [Serializable]
    public class BindableCollection<T> : ObservableCollection<T>
    {
        /// <summary>
        /// Initializes a new instance of the<see cref="BindingCollection&lt;T&gt;">BindingCollection</see>.
        /// </summary>
        public BindableCollection() : base() { }

        /// <summary>
        /// Initializes a new instance of the<see cref="BindingCollection&lt;T&gt;">BindingCollection</see>
        /// class that contains elements copied from the specified List&lt;T&gt;.
        /// </summary>
        /// <param name="list">The list from which the elements are copied.</param>
        /// <exception cref="System.ArgumentNullException">The list parameter cannot be null.</exception>
        public BindableCollection(List<T> list) : base(list) { }

        /// <summary>
        /// Initializes a new instance of the<see cref="BindingCollection&lt;T&gt;">BindingCollection</see>
        /// class that contains elements copied from the specified IEnumerable&lt;T&gt;.
        /// </summary>
        /// <param name="list">The list from which the elements are copied.</param>
        /// <exception cref="System.ArgumentNullException">The list parameter cannot be null.</exception>
        public BindableCollection(IEnumerable<T> list)
        {
            if (list == null) throw new ArgumentOutOfRangeException("The list parameter cannot be null.");
            foreach (T item in list)
            {
                this.Items.Add(item);
            }
        }

        /// <summary>
        /// Occurs when an item is added, removed, changed, moved, or the entire list is refreshed.
        /// </summary>
        public override event NotifyCollectionChangedEventHandler CollectionChanged;
        private bool iSuspendCollectionChangeNotification;

        protected override void OnCollectionChanged(NotifyCollectionChangedEventArgs e)
        {
            if (iSuspendCollectionChangeNotification)
                return;

            if (this.CollectionChanged != null)
            {
                using (IDisposable disposable = this.BlockReentrancy())
                {
                    foreach (Delegate del in this.CollectionChanged.GetInvocationList())
                    {
                        NotifyCollectionChangedEventHandler handler = (NotifyCollectionChangedEventHandler)del;
                        DispatcherObject dispatcherInvoker = del.Target as DispatcherObject;
                        ISynchronizeInvoke syncInvoker = del.Target as ISynchronizeInvoke;
                        if (dispatcherInvoker != null)
                        {
                            // We are running inside DispatcherSynchronizationContext,
                            // so we should invoke the event handler in the correct dispatcher.
                            dispatcherInvoker.Dispatcher.Invoke(DispatcherPriority.Normal, new ThreadStart(delegate
                            {
                                handler(this, e);
                            }));
                        }
                        else if (syncInvoker != null)
                        {
                            // We are running inside WindowsFormsSynchronizationContext,
                            // so we should invoke the event handler in the correct context.
                            syncInvoker.Invoke(del, new Object[] { this, e });
                        }
                        else
                        {
                            // We are running in free threaded context, so just directly invoke the event handler.
                            handler(this, e);
                        }
                    }
                }
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