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

namespace EveTrader_Wpf
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
	}
}