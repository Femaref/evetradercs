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

namespace EveTrader.Wpf.Controls
{
    /// <summary>
    /// Interaction logic for TimeframeSelector.xaml
    /// </summary>
    public partial class TimeframeSelector : UserControl
    {
        public TimeframeSelector()
        {
            InitializeComponent();
        }

        public Binding StartDate { get; set; }
        public Binding EndDate { get; set; }
        public Binding EnableStartFilter { get; set; }
        public Binding EnableEndFilter { get; set; }

        private void TimeframeSelector_Loaded(object sender, RoutedEventArgs e)
        {
            iStartDate.SetBinding(DatePicker.SelectedDateProperty, StartDate);
            iEndDate.SetBinding(DatePicker.SelectedDateProperty, EndDate);
            iEnableStartFilter.SetBinding(CheckBox.IsCheckedProperty, EnableStartFilter);
            iEnableEndFilter.SetBinding(CheckBox.IsCheckedProperty, EnableEndFilter);
        }



    }
}
