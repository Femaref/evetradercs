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
    /// Interaction logic for JournalView.xaml
    /// </summary>
    [Export(typeof(IJournalView))]
    public partial class JournalView : UserControl, IJournalView
    {
        public JournalView()
        {
            InitializeComponent();
            var x = (CollectionViewSource)this.Resources["iGroupedJournal"];
            x.GroupDescriptions.Add(new PropertyGroupDescription("Date"));
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

        private void comboBox1_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            RaiseEntitySelectionChanged(e.AddedItems.Cast<Wallets>().First());
        }
        private void RaiseEntitySelectionChanged(Wallets selection)
        {
            var handler = EntitySelectionChanged;
            if (handler != null)
                handler(this, new EntitySelectionChangedEventArgs<Wallets>(selection));
        }

        public event EventHandler<EntitySelectionChangedEventArgs<Wallets>> EntitySelectionChanged;

        #endregion
    }
}
