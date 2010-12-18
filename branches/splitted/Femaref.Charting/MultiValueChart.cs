using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using Visifire.Charts;
using System.Reflection;
using System.Windows.Controls;
using System.Collections;
using System.Collections.Specialized;

namespace Femaref.Charting
{
    public class MultiValueChart : Chart
    {
        private List<PropertyInfo> iProperties = new List<PropertyInfo>();
        private Dictionary<PropertyInfo, IEnumerable<string>> iIndexableProperties = new Dictionary<PropertyInfo, IEnumerable<string>>();

        private void GenerateTypeInfo(Type t)
        {
            iProperties.Clear();

            foreach (var i in t.GetProperties(BindingFlags.Public | BindingFlags.Instance))
            {
                if (i.Name != "Key")
                    iProperties.Add(i);
            }
        }

        private void GenerateSeries()
        {
            this.Series.Clear();

            foreach (PropertyInfo pi in iProperties)
            {
                DataTemplate dataTemplate = SelectDataTemplate(pi);

                // load data template content
                if (dataTemplate != null)
                {
                    if (iIndexableProperties.ContainsKey(pi))
                    {
                        foreach (var index in iIndexableProperties[pi])
                        {
                            DataSeries current = dataTemplate.LoadContent() as DataSeries;
                            if (current != null)
                            {
                                current.LegendText = index;
                                current.DataMappings.Add(new DataMapping() { MemberName = "YValue", Path = string.Format("{0}[{1}]", pi.Name, index) });
                                current.DataContext = DataSource;
                                this.Series.Add(current);
                            }

                        }
                        continue;
                    }

                    DataSeries series = dataTemplate.LoadContent() as DataSeries;
                    if (series != null)
                    {
                        // set data context
                        series.DataContext = DataSource;

                        this.Series.Add(series);
                    }
                }
            }

        }


        #region CollectionMappings (DependencyProperty)

        public IEnumerable<KeyValuePair<PropertyInfo, IEnumerable<string>>> CollectionMappings
        {
            get { return (IEnumerable<KeyValuePair<PropertyInfo, IEnumerable<string>>>)GetValue(CollectionMappingsProperty); }
            set { SetValue(CollectionMappingsProperty, value); }
        }

        // Using a DependencyProperty as the backing store for CollectionMappings.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty CollectionMappingsProperty =
            DependencyProperty.Register("CollectionMappings", typeof(IEnumerable<KeyValuePair<PropertyInfo, IEnumerable<string>>>), typeof(MultiValueChart), new PropertyMetadata(new PropertyChangedCallback(OnColletionMappingsChanged)));

        static void OnColletionMappingsChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            var oldValue = (IEnumerable<KeyValuePair<PropertyInfo, IEnumerable<string>>>)e.OldValue;
            var newValue = (IEnumerable<KeyValuePair<PropertyInfo, IEnumerable<string>>>)e.NewValue;
            var obj = (MultiValueChart)d;
            obj.OnCollectionMappingsChanged(oldValue, newValue);
        }

        protected virtual void OnCollectionMappingsChanged(
            IEnumerable<KeyValuePair<PropertyInfo, IEnumerable<string>>> oldValue,
            IEnumerable<KeyValuePair<PropertyInfo, IEnumerable<string>>> newValue)
        {
            iIndexableProperties.Clear();

            var oldNot = (oldValue as INotifyCollectionChanged);
            if (oldNot != null)
                CollectionChangedEventManager.RemoveListener(oldNot, iSeriesChangedEventListener);

            var newNot = (newValue as INotifyCollectionChanged);
            if (newNot != null)
            {
                iSeriesChangedEventListener = new CollectionChangedEventListener(newNot, NotifyCollectionChangedEventHandler);
                CollectionChangedEventManager.AddListener(newNot, iSeriesChangedEventListener);
            }

            ResetCollection(newValue);

            GenerateSeries();
        }

        private void NotifyCollectionChangedEventHandler(object sender, NotifyCollectionChangedEventArgs e)
        {
            switch (e.Action)
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
                    ResetCollection((IEnumerable<KeyValuePair<PropertyInfo, IEnumerable<string>>>)sender);
                    break;
            }

            GenerateSeries();
        }

        private void ReplaceCollection(IList oldItems, int oldIndex, IList newItems, int newIndex)
        {
            return;
        }

        private void RemoveCollection(IList oldItems, int oldIndex, IList newItems, int newIndex)
        {
            foreach (var item in oldItems.Cast<IEnumerable<KeyValuePair<PropertyInfo, IEnumerable<string>>>>())
                RemoveItem(item);
        }

        private void RemoveItem(object item)
        {
            var current = (item as KeyValuePair<PropertyInfo, IEnumerable<string>>?);

            if (current.HasValue)
                iIndexableProperties.Remove(current.Value.Key);
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

        private void ResetCollection(IEnumerable<KeyValuePair<PropertyInfo, IEnumerable<string>>> newValue)
        {
            this.iIndexableProperties.Clear();

            if (newValue != null)

            {
                foreach (var x in newValue)
                    iIndexableProperties.Add(x.Key, x.Value);
            }
        }

        protected virtual void AddItem(object item)
        {
            var current = (item as KeyValuePair<PropertyInfo, IEnumerable<string>>?);
            
            if(current.HasValue && !iIndexableProperties.ContainsKey(current.Value.Key))
                iIndexableProperties.Add(current.Value.Key, current.Value.Value);
        }

        #endregion

        #region BindingType (DependencyProperty)
        public Type BindingType
        {
            get { return (Type)GetValue(BindingTypeProperty); }
            set { SetValue(BindingTypeProperty, value); }
        }

        // Using a DependencyProperty as the backing store for BindingType.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty BindingTypeProperty =
            DependencyProperty.Register("BindingType", typeof(Type), typeof(MultiValueChart), new PropertyMetadata(OnBindingTypeChanged));

        static void OnBindingTypeChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            var oldValue = (Type)e.OldValue;
            var newValue = (Type)e.NewValue;
            var obj = (MultiValueChart)d;

            obj.OnBindingTypeChanged(oldValue, newValue);
        }

        protected void OnBindingTypeChanged(Type oldType, Type newType)
        {
            GenerateTypeInfo(newType);

            GenerateSeries();
        }
        #endregion

        #region SeriesSource (DependencyProperty)

        public IEnumerable DataSource
        {
            get { return (IEnumerable)GetValue(DataSourceProperty); }
            set { SetValue(DataSourceProperty, value); }
        }
        public static readonly DependencyProperty DataSourceProperty = DependencyProperty.Register("DataSource", typeof(IEnumerable), typeof(MultiValueChart), new PropertyMetadata(default(IEnumerable)));

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
        public static readonly DependencyProperty SeriesTemplateProperty = DependencyProperty.Register("SeriesTemplate", typeof(DataTemplate), typeof(MultiValueChart), new PropertyMetadata(default(DataTemplate)));

        #endregion

        #region SeriesTemplateSelector (DependencyProperty)

        public DataTemplateSelector SeriesTemplateSelector
        {
            get { return (DataTemplateSelector)GetValue(SeriesTemplateSelectorProperty); }
            set { SetValue(SeriesTemplateSelectorProperty, value); }
        }
        public static readonly DependencyProperty SeriesTemplateSelectorProperty = DependencyProperty.Register("SeriesTemplateSelector", typeof(DataTemplateSelector), typeof(MultiValueChart), new PropertyMetadata(default(DataTemplateSelector)));
        private IWeakEventListener iSeriesChangedEventListener;

        #endregion

    }
}
