using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Data;
using System.Windows;

namespace EveTrader.Wpf.Data
{
    public class UpdatingCollectionViewSource : CollectionViewSource
    {
        public static readonly DependencyProperty UpdatingProperty = 
            DependencyProperty.Register("Updating", typeof(bool), typeof(UpdatingCollectionViewSource));

        private object iCachedSource;

        public bool Updating
        {
            get
            {
                return ((bool)(base.GetValue(UpdatingCollectionViewSource.UpdatingProperty)));
            }
            set
            {
                base.SetValue(UpdatingCollectionViewSource.UpdatingProperty, value);
                if (value)
                    SetValue(UpdatingCollectionViewSource.SourceProperty, null);
                else
                    SetValue(UpdatingCollectionViewSource.SourceProperty, iCachedSource);

            }
        }

        protected override void OnSourceChanged(object oldSource, object newSource)
        {
            base.OnSourceChanged(oldSource, newSource);

            this.iCachedSource = newSource;
            if ((bool)GetValue(UpdatingCollectionViewSource.UpdatingProperty))
                SetValue(UpdatingCollectionViewSource.SourceProperty, null);
        }
    }
}
