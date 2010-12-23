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
using System.Windows.Shapes;
using System.ComponentModel.Composition;
using EveTrader.Core.Visual.View;
using System.ComponentModel;

namespace EveTrader.Wpf
{
    /// <summary>
    /// Interaction logic for ConverterWindow.xaml
    /// </summary>
    [Export(typeof(IConverterView))]
    public partial class ConverterView : UserControl, IConverterView
    {
        public ConverterView()
        {
            InitializeComponent();
        }

        public void Invoke(Action action)
        {
            Dispatcher.Invoke(action);
        }

        public void BeginInvoke(Action action)
        {
            Dispatcher.BeginInvoke(action);
        }

        private void RaiseClosed()
        {
            var handler = Closed;

            if (handler != null)
                handler(this, EventArgs.Empty);
        }

        public event EventHandler Closed;
    }
}
