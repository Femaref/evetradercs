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
using EveTrader.Core.Visual.View;
using System.ComponentModel.Composition;
using EveTrader.Core.Model.Trader;

namespace EveTrader.Wpf
{
    /// <summary>
    /// Interaction logic for ManageAccountsWindow.xaml
    /// </summary>
    [Export(typeof(IManageAccountsView)), PartCreationPolicy(CreationPolicy.NonShared)]
    public partial class ManageAccountsWindow : UserControl, IManageAccountsView
    {
        public ManageAccountsWindow()
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

        private void MenuItem_Click(object sender, RoutedEventArgs e)
        {
            if (iGrid.SelectedIndex != -1)
            {
                iTabControl.SelectedIndex = 0;
            }
        }
    }
}
