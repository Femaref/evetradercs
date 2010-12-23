using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;

namespace EveTrader.Core.Collections.ObjectModel
{
    public class SmartGroupableObservableCollection<T> : SmartObservableCollection<T>, ICollectionView where T : class
    {

        public SmartGroupableObservableCollection(Action<Action> updateAction)
            : base(updateAction)
        {
        }

        #region ICollectionView

        public bool CanFilter
        {
            get { return true; }
        }

        public bool CanGroup
        {
            get { return true; }
        }

        public bool CanSort
        {
            get { return true; }
        }

        public bool Contains(object item)
        {
            var current = (item as T);
            if (current == null)
                throw new ArgumentNullException("item is not of an expected type");

            return this.Contains(current);
        }

        public System.Globalization.CultureInfo Culture
        {
            get
            {
                throw new NotImplementedException();
            }
            set
            {
                throw new NotImplementedException();
            }
        }

        public event EventHandler CurrentChanged;

        public event CurrentChangingEventHandler CurrentChanging;

        public object CurrentItem
        {
            get { throw new NotImplementedException(); }
        }

        public int CurrentPosition
        {
            get { throw new NotImplementedException(); }
        }

        public IDisposable DeferRefresh()
        {
            throw new NotImplementedException();
        }

        public Predicate<object> Filter
        {
            get
            {
                throw new NotImplementedException();
            }
            set
            {
                throw new NotImplementedException();
            }
        }

        public System.Collections.ObjectModel.ObservableCollection<GroupDescription> GroupDescriptions
        {
            get { throw new NotImplementedException(); }
        }

        public System.Collections.ObjectModel.ReadOnlyObservableCollection<object> Groups
        {
            get { throw new NotImplementedException(); }
        }

        public bool IsCurrentAfterLast
        {
            get { throw new NotImplementedException(); }
        }

        public bool IsCurrentBeforeFirst
        {
            get { throw new NotImplementedException(); }
        }

        public bool IsEmpty
        {
            get { return (this.Count == 0); }
        }

        public bool MoveCurrentTo(object item)
        {
            throw new NotImplementedException();
        }

        public bool MoveCurrentToFirst()
        {
            throw new NotImplementedException();
        }

        public bool MoveCurrentToLast()
        {
            throw new NotImplementedException();
        }

        public bool MoveCurrentToNext()
        {
            throw new NotImplementedException();
        }

        public bool MoveCurrentToPosition(int position)
        {
            throw new NotImplementedException();
        }

        public bool MoveCurrentToPrevious()
        {
            throw new NotImplementedException();
        }

        public void Refresh()
        {
            throw new NotImplementedException();
        }

        public SortDescriptionCollection SortDescriptions
        {
            get { throw new NotImplementedException(); }
        }

        public System.Collections.IEnumerable SourceCollection
        {
            get { return this; }
        }

        #endregion
    }
}
