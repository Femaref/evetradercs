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
using EveTrader.Core.View;
using System.ComponentModel.Composition;

namespace EveTrader.Wpf
{
    /// <summary>
    /// Interaction logic for ManageAccountsWindow.xaml
    /// </summary>
    [Export(typeof(IManageAccountsView))]
    public partial class ManageAccountsWindow : Window, IManageAccountsView
    {
        public ManageAccountsWindow()
        {
            InitializeComponent();
        }
    }
}
