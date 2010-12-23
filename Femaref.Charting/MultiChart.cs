using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Visifire.Charts;
using System.Collections;
using System.Windows;
using System.Windows.Controls;
using System.Collections.Specialized;

namespace Femaref.Charting
{
    public class MultiChart : Chart
    {

        #region SeriesSource (DependencyProperty)

        private CollectionChangedEventListener iSeriesChangedEventListener;

        public IEnumerable SeriesSource
        {
            get { return (IEnumerable)GetValue(SeriesSourceProperty); }
            set { SetValue(SeriesSourceProperty, value); }
        }
        public static readonly DependencyProperty SeriesSourceProperty = DependencyProperty.Register("SeriesSource", typeof(IEnumerable), typeof(MultiChart), new PropertyMetadata(default(IEnumerable), new PropertyChangedCallback(OnSeriesSourceChanged)));

        private static void OnSeriesSourceChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            IEnumerable oldValue = (IEnumerable)e.OldValue;
            IEnumerable newValue = (IEnumerable)e.NewValue;
            MultiChart source = (MultiChart)d;
            source.OnSeriesSourceChanged(oldValue, newValue);
        }

        protected virtual void OnSeriesSourceChanged(IEnumerable oldValue, IEnumerable newValue)
        {
            var oldNot = (oldValue as INotifyCollectionChanged);
            if(oldNot != null)
                CollectionChangedEventManager.RemoveListener(oldNot, iSeriesChangedEventListener);

            var newNot = (newValue as INotifyCollectionChanged);
            if (newNot != null)
            {
                iSeriesChangedEventListener = new CollectionChangedEventListener(newNot, NotifyCollectionChangedEventHandler);
                CollectionChangedEventManager.AddListener(newNot, iSeriesChangedEventListener);
            }

            ResetCollection(newValue);

            // TODO Listen for INotifyCollectionChanged with a weak event pattern
        }

        private void NotifyCollectionChangedEventHandler(object sender, NotifyCollectionChangedEventArgs e)
        {
            switch(e.Action)
            {
                case NotifyCollectionChangedAction.Add:
                    AddCollection(e.NewItems);
                    break;
                case NotifyCollectionChangedAction.Move:
                    MoveCollection(e.OldItems, e.OldStartingIndex, e.NewItems, e.NewStartingIndex);
                    break;
                case NotifyCollectionChangedAction.Remove:
                    RemoveCollection(e.OldItems, e.OldStartingIndex, e.NewItems, e.NewStartingIndex);
                    break;
                case NotifyCollectionChangedAction.Replace:
                    ReplaceCollection(e.OldItems, e.OldStartingIndex, e.NewItems, e.NewStartingIndex);
                    break;
                case NotifyCollectionChangedAction.Reset:
                    ResetCollection((IEnumerable)sender);
                    break;
            }
        }

        private void ReplaceCollection(IList oldItems, int oldIndex, IList newItems, int newIndex)
        {
            return;
        }

        private void RemoveCollection(IList oldItems, int oldIndex, IList newItems, int newIndex)
        {
            foreach (var item in oldItems)
                RemoveItem(item);
        }

        private void RemoveItem(object item)
        {
            DataTemplate dt = SelectDataTemplate(item);

            DataSeries ds = (dt.LoadContent() as DataSeries);

            if (ds != null)
                Series.Remove(ds);
        }

        private void MoveCollection(IList oldItems, int oldIndex, IList newItems, int newIndex)
        {
            return;
        }

        private void AddCollection(IList newItems)
        {
            foreach (var item in newItems)
                AddItem(item);
        }

        private void ResetCollection(IEnumerable newValue)
        {
            this.Series.Clear();

            if (newValue != null)
            {
                foreach (object item in newValue)
                {
                    AddItem(item);
                }
            }
        }

        protected virtual void AddItem(object item)
        {
            DataTemplate dataTemplate = SelectDataTemplate(item);

            // load data template content
            if (dataTemplate != null)
            {
                DataSeries series = dataTemplate.LoadContent() as DataSeries;

                if (series != null)
                {
                    // set data context
                    series.DataContext = item;

                    this.Series.Add(series);
                }
            }
        }

        protected virtual DataTemplate SelectDataTemplate(object item)
        {
            DataTemplate dataTemplate = null;

            // get data template
            if (this.SeriesTemplateSelector != null)
            {
                dataTemplate = this.SeriesTemplateSelector.SelectTemplate(item, this);
            }
            if (dataTemplate == null && this.SeriesTemplate != null)
            {
                dataTemplate = this.SeriesTemplate;
            }
            return dataTemplate;
        }
        #endregion

        #region SeriesTemplate (DependencyProperty)

        public DataTemplate SeriesTemplate
        {
            get { return (DataTemplate)GetValue(SeriesTemplateProperty); }
            set { SetValue(SeriesTemplateProperty, value); }
        }
        public static readonly DependencyProperty SeriesTemplateProperty = DependencyProperty.Register("SeriesTemplate", typeof(DataTemplate), typeof(MultiChart), new PropertyMetadata(default(DataTemplate)));

        #endregion

        #region SeriesTemplateSelector (DependencyProperty)

        public DataTemplateSelector SeriesTemplateSelector
        {
            get { return (DataTemplateSelector)GetValue(SeriesTemplateSelectorProperty); }
            set { SetValue(SeriesTemplateSelectorProperty, value); }
        }
        public static readonly DependencyProperty SeriesTemplateSelectorProperty = DependencyProperty.Register("SeriesTemplateSelector", typeof(DataTemplateSelector), typeof(MultiChart), new PropertyMetadata(default(DataTemplateSelector)));

        #endregion
    }
}
