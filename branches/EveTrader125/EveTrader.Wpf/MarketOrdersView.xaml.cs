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
using EveTrader.Core.Model;

namespace EveTrader.Wpf
{
    /// <summary>
    /// Interaction logic for MarketOrdersView.xaml
    /// </summary>
    [Export(typeof(IMarketOrdersView))]
    public partial class MarketOrdersView : UserControl, IMarketOrdersView
    {
        public MarketOrdersView()
        {
            InitializeComponent();
            var x = (CollectionViewSource)this.Resources["iGroupedMarketOrders"];
            x.GroupDescriptions.Add(new PropertyGroupDescription("StationID"));

        }

        private void comboBox1_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            RaiseEntitySelectionChanged(e.AddedItems.Cast<Entities>().First().Name);
        }

        public event EventHandler<EntitySelectionChangedEventArgs> EntitySelectionChanged;

        private void RaiseEntitySelectionChanged(string selection)
        {
            var handler = EntitySelectionChanged;
            if (handler != null)
                handler(this, new EntitySelectionChangedEventArgs(selection));
        }
    }
}
