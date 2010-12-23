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

namespace EveTrader.Wpf
{
    /// <summary>
    /// Interaction logic for PriceLookupSettingView.xaml
    /// </summary>
    [Export(typeof(IPriceLookupSettingView))]
    public partial class PriceLookupSettingView : UserControl, IPriceLookupSettingView
    {
        public PriceLookupSettingView()
        {
            InitializeComponent();
        }

        public void Invoke(Action action)
        {
            throw new NotImplementedException();
        }

        public void BeginInvoke(Action action)
        {
            throw new NotImplementedException();
        }
    }
}
