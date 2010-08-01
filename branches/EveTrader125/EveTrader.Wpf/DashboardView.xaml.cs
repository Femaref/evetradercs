using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using EveTrader.Core.View;
using System.ComponentModel.Composition;
using System.Collections.Specialized;
using Visifire.Charts;
using System.Collections;
using System.Threading;
using System.ComponentModel;

namespace EveTrader.Wpf
{
    /// <summary>
    /// Interaction logic for DashboardView.xaml
    /// </summary>
    ///
    [Export(typeof(IDashboardView))]
    public partial class DashboardView : UserControl, IDashboardView
    {
        public DashboardView()
        {
            this.InitializeComponent();
        }

        #region IExtendedView Members

        public void Invoke(Action action)
        {
            this.Dispatcher.Invoke(action);
        }

        public void BeginInvoke(Action action)
        {
            this.Dispatcher.BeginInvoke(action);
        }

        #endregion


        #region IDashboardView Members

        public void ChartCollectionChanged(object sender, NotifyCollectionChangedEventArgs e)
        {
            if (e.Action == NotifyCollectionChangedAction.Reset)
            {
                this.iPrimaryChart.Series.Clear();
                this.iPrimaryChart.Series.Add(CreateLine("Profit", "Profit", 99));
                this.iPrimaryChart.Series.Add(CreateLine("Investment", "Investment", 100));
            }
            if (e.Action == NotifyCollectionChangedAction.Add)
            {
                foreach (var s in e.NewItems)
                {
                    this.iPrimaryChart.Series.Add(CreateStackedColumn(s as string, "Sales"));
                }
            }
        }
        private DataSeries CreateLine(string title, string bindingProperty, int zindex)
        {
            DataSeries ds = new DataSeries()
            {
                XValueFormatString = "dd.MM.yyyy",
                XValueType = ChartValueTypes.Date,
                LegendText = title,
                RenderAs = RenderAs.Line,
                ZIndex = zindex,
                DataMappings = new DataMappingCollection()
                {
                    new DataMapping() 
                    {
                        MemberName ="XValue",
                        Path = "Key"
                    },
                    new DataMapping() 
                    {
                        MemberName ="YValue",
                        Path = bindingProperty
                    }
                }
            };
            ds.MouseMove += new EventHandler<MouseEventArgs>(ds_MouseMove);
            ds.MouseDoubleClick += new MouseButtonEventHandler(ds_MouseDoubleClick);
            ds.SetBinding(DataSeries.DataSourceProperty, new Binding("DailyInfo"));
            return ds;
        }

        void ds_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            iDetailChart.Focus();
        }


        private DataSeries CreateStackedColumn(string entity, string bindingProperty)
        {
            DataSeries ds = new DataSeries()
            {
                XValueFormatString = "dd.MM.yyyy",
                XValueType = ChartValueTypes.Date,
                LegendText = entity,
                Bevel = true,
                MarkerType = Visifire.Commons.MarkerTypes.Square,
                RenderAs = RenderAs.StackedColumn,
                ToolTipText = entity,
                DataMappings = new DataMappingCollection()
                {
                    new DataMapping() 
                    {
                        MemberName ="XValue",
                        Path = "Key"
                    },
                    new DataMapping() 
                    {
                        MemberName ="YValue",
                        Path = string.Format("{0}[{1}]", bindingProperty,entity)
                    }
                }
            };

            ds.MouseMove += new EventHandler<MouseEventArgs>(ds_MouseMove);
            ds.MouseDoubleClick += new MouseButtonEventHandler(ds_MouseDoubleClick);
            ds.SetBinding(DataSeries.DataSourceProperty, new Binding("DailyInfo"));
            return ds;
        }

        void ds_MouseMove(object sender, MouseEventArgs e)
        {
            RaiseDetailsRequested((sender as DataPoint).XValue as DateTime?, (sender as DataPoint).Parent.DataMappings[1].Path);
        }

        public event EventHandler<DetailsRequestedEventArgs> DetailsRequested;

        private void RaiseDetailsRequested(DateTime? key, string bindingKey)
        {
            EventHandler<DetailsRequestedEventArgs> handler = DetailsRequested;

            if (handler != null && key.HasValue)
                handler(this, new DetailsRequestedEventArgs(key.Value, bindingKey));
        }

        #endregion
    }
}