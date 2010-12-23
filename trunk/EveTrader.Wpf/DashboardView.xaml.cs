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
using EveTrader.Core.Visual.View;
using System.ComponentModel.Composition;
using System.Collections.Specialized;
using Visifire.Charts;
using System.Collections;
using System.Threading;
using System.ComponentModel;
using System.Runtime.InteropServices;

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

            Binding binding = new Binding("ProfitAverage");
            binding.Source = this.DataContext;
            binding.Mode = BindingMode.OneWay;
            TrendLine trendLine = iPrimaryChart.TrendLines[0];


            trendLine.SetBinding(TrendLine.ValueProperty, binding);
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

        void ds_MouseMove(object sender, MouseEventArgs e)
        {
            DataPoint dp = (sender as DataPoint);
            RaiseDetailsRequested(dp.XValue as DateTime?, dp.Parent.DataMappings[1].Path);
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