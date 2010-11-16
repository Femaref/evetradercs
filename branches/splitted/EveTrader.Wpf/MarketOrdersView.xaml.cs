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
using EveTrader.Core.Model.Trader;

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
            x.GroupDescriptions.Add(new PropertyGroupDescription("StationName"));

        }

        private void comboBox1_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if(e.AddedItems.Count == 1)
                RaiseEntitySelectionChanged(e.AddedItems.Cast<Entities>().First());
        }

        public event EventHandler<EntitySelectionChangedEventArgs<Entities>> EntitySelectionChanged;

        private void RaiseEntitySelectionChanged(Entities input)
        {
            var handler = EntitySelectionChanged;
            if (handler != null)
                handler(this, new EntitySelectionChangedEventArgs<Entities>(input));
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