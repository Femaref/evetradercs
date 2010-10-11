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

        public DateTime StartDate
        {
            get{ return (DateTime)GetValue(StartDateProperty);}
            set { SetValue(StartDateProperty, value); }
        }

        public DateTime EndDate
        {
            get { return (DateTime)GetValue(EndDateProperty); }
            set { SetValue(EndDateProperty, value); }
        }

        public bool EnableStartFilter
        {
            get { return (bool)GetValue(EnableStartFilterProperty); }
            set { SetValue(EnableStartFilterProperty, value); }
        }

        public bool EnableEndFilter
        {
            get { return (bool)GetValue(EnableEndFilterProperty); }
            set { SetValue(EnableEndFilterProperty, value); }
        } 
        

        // Using a DependencyProperty as the backing store for StartDate.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty StartDateProperty =
            DependencyProperty.RegisterAttached(
            "StartDate", 
            typeof(DateTime), 
            typeof(TimeframeSelector), 
            new FrameworkPropertyMetadata(
                DateTime.MinValue, 
                FrameworkPropertyMetadataOptions.BindsTwoWayByDefault));



        // Using a DependencyProperty as the backing store for EndDate.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty EndDateProperty =
            DependencyProperty.Register(
            "EndDate", 
            typeof(DateTime), 
            typeof(TimeframeSelector), 
            new FrameworkPropertyMetadata(
                DateTime.MinValue, 
                FrameworkPropertyMetadataOptions.BindsTwoWayByDefault));


        // Using a DependencyProperty as the backing store for ApplyStartFilter.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty EnableStartFilterProperty =
            DependencyProperty.Register(
            "EnableStartFilter", 
            typeof(bool), 
            typeof(TimeframeSelector), 
            new FrameworkPropertyMetadata(
                false, 
                FrameworkPropertyMetadataOptions.BindsTwoWayByDefault));


        // Using a DependencyProperty as the backing store for ApplyEndFilter.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty EnableEndFilterProperty =
            DependencyProperty.Register(
            "EnableEndFilter", 
            typeof(bool), 
            typeof(TimeframeSelector), 
            new FrameworkPropertyMetadata(
                false, 
                FrameworkPropertyMetadataOptions.BindsTwoWayByDefault));
    }
}
