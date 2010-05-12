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
using System.Collections.ObjectModel;
using EveTrader.Core.View;
using System.ComponentModel.Composition;

namespace EveTrader.Wpf
{
	/// <summary>
	/// Interaction logic for MainWindow.xaml
	/// </summary>
    [Export(typeof(IMainWindowView))]
	public partial class MainWindow : Window, IMainWindowView
	{
		public MainWindow()
		{
			this.InitializeComponent();
			
			// Insert code required on object creation below this point.
		}


	}
}