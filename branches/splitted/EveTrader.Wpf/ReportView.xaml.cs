using System;
using System.Collections.Generic;
using System.Linq;
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
using Visifire.Charts;
using System.Collections.Specialized;
using EveTrader.Core.Visual.ViewModel.Display;
using EveTrader.Core.Model;

namespace EveTrader.Wpf
{
    /// <summary>
    /// Interaction logic for ReportView.xaml
    /// </summary>
    [Export(typeof(IReportView))]
    public partial class ReportView : UserControl, IReportView
    {
        public ReportView()
        {
            InitializeComponent();
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

        private DataSeries CreateLine(string title, long bindingIndex)
        {
            DataSeries ds = new DataSeries()
            {
                XValueFormatString = "dd.MM.yyyy",
                XValueType = ChartValueTypes.Date,
                LegendText = title,
                RenderAs = RenderAs.StepLine,
                DataMappings = new DataMappingCollection()
                {
                    new DataMapping() 
                    {
                        MemberName ="XValue",
                        Path = "Date"
                    },
                    new DataMapping() 
                    {
                        MemberName ="YValue",
                        Path = "Balance"
                    }
                }
            };
            Binding b = new Binding(string.Format("WalletHistories[{0}].Histories", bindingIndex));
            b.Source = this.DataContext;
            ds.SetBinding(DataSeries.DataSourceProperty, b);
            return ds;
        }


        #region IReportView Members

        public void ChartCollectionChanged(object sender, NotifyCollectionChangedEventArgs e)
        {
            iHistory.Series.Clear();

            var col = (sender as IList<KeyValuePair<long, string>>);

            foreach(var kvp in col)
                iHistory.Series.Add(CreateLine(kvp.Value, kvp.Key));
        }

        #endregion
    }
}
