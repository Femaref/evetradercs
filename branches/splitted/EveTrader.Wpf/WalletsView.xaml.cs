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
    /// Interaction logic for Wallets.xaml
    /// </summary>
    ///
    [Export(typeof(IWalletsView))]
    public partial class WalletsView : UserControl, IWalletsView
    {
        public WalletsView()
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
    }
}
