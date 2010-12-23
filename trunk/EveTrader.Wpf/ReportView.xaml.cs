using System;
using System.ComponentModel.Composition;
using System.Windows.Controls;
using EveTrader.Core.Visual.View;

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
    }
}
