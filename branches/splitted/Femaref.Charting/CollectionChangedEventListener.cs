using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Collections.Specialized;

namespace Femaref.Charting
{
    internal class CollectionChangedEventListener : IWeakEventListener
    {
        private readonly INotifyCollectionChanged source;
        private readonly NotifyCollectionChangedEventHandler handler;


        public CollectionChangedEventListener(INotifyCollectionChanged source, NotifyCollectionChangedEventHandler handler)
        {
            if (source == null) { throw new ArgumentNullException("source"); }
            if (handler == null) { throw new ArgumentNullException("handler"); }
            this.source = source;
            this.handler = handler;
        }


        public INotifyCollectionChanged Source { get { return source; } }

        public NotifyCollectionChangedEventHandler Handler { get { return handler; } }


        public bool ReceiveWeakEvent(Type managerType, object sender, EventArgs e)
        {
            handler(sender, (NotifyCollectionChangedEventArgs)e);
            return true;
        }
    }
}
