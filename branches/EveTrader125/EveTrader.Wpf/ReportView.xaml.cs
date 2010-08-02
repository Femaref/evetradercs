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
using EveTrader.Core.View;
using System.ComponentModel.Composition;
using Visifire.Charts;
using System.Collections.Specialized;
using EveTrader.Core.ViewModel.Display;
using EveTrader.Core.Collections.ObjectModel;

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

        private DataSeries CreateLine(string title, int bindingIndex)
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
            ds.SetBinding(DataSeries.DataSourceProperty, new Binding(string.Format("WalletHistories[{0}].Histories", bindingIndex)));
            return ds;
        }


        #region IReportView Members

        public void ChartCollectionChanged(object sender, NotifyCollectionChangedEventArgs e)
        {
            if (e.Action == NotifyCollectionChangedAction.Reset)
            {
                iHistory.Series.Clear();

                var col = (sender as SmartObservableCollection<DisplayWalletHistory>);
                for (int i = 0; i < col.Count; i++)
                {
                    iHistory.Series.Add(CreateLine(col[i].Name, i));
                }
            }
            if(e.Action == NotifyCollectionChangedAction.Add)
            {
                DisplayWalletHistory dwh = (DisplayWalletHistory)e.NewItems[0];
                iHistory.Series.Add(CreateLine(dwh.Name, e.NewStartingIndex));
            }
            if (e.Action == NotifyCollectionChangedAction.Remove)
            {
                DisplayWalletHistory dwh = (DisplayWalletHistory)e.NewItems[0];
                DataSeries d = iHistory.Series.Where(ds => ds.LegendText == dwh.Name).First();
                iHistory.Series.Remove(d);
            }
                
        }

        #endregion
    }
}
