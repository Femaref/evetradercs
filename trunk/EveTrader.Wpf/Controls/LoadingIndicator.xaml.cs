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
    /// Interaction logic for LoadingIndicator.xaml
    /// </summary>
    public partial class LoadingIndicator : UserControl
    {




        public Brush GridBackground
        {
            get { return (Brush)GetValue(GridBackgroundProperty); }
            set { SetValue(GridBackgroundProperty, value); }
        }

        // Using a DependencyProperty as the backing store for GridBackground.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty GridBackgroundProperty =
            DependencyProperty.Register("GridBackground", typeof(Brush), typeof(LoadingIndicator), new UIPropertyMetadata(Brushes.White));



        public double GridOpacity
        {
            get { return (double)GetValue(GridOpacityProperty); }
            set { SetValue(GridOpacityProperty, value); }
        }

        // Using a DependencyProperty as the backing store for GridOpacity.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty GridOpacityProperty =
            DependencyProperty.Register("GridOpacity", typeof(double), typeof(LoadingIndicator), new UIPropertyMetadata(0.75));



        public string Text
        {
            get { return (string)GetValue(TextProperty); }
            set { SetValue(TextProperty, value); }
        }

        // Using a DependencyProperty as the backing store for Text.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty TextProperty =
            DependencyProperty.Register("Text", typeof(string), typeof(LoadingIndicator), new UIPropertyMetadata("Loading..."));



        public bool IsRunning
        {
            get { return (bool)GetValue(IsRunningProperty); }
            set { SetValue(IsRunningProperty, value); }
        }

        // Using a DependencyProperty as the backing store for IsRunning.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty IsRunningProperty =
            DependencyProperty.Register("IsRunning", typeof(bool), typeof(LoadingIndicator), new UIPropertyMetadata(false));



        public bool IsIndeterminate
        {
            get { return (bool)GetValue(IsIndeterminateProperty); }
            set { SetValue(IsIndeterminateProperty, value); }
        }

        // Using a DependencyProperty as the backing store for IsDeterminate.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty IsIndeterminateProperty =
            DependencyProperty.Register("IsIndeterminate", typeof(bool), typeof(LoadingIndicator), new UIPropertyMetadata(true));



        public double ProgressHeight
        {
            get { return (double)GetValue(ProgressHeightProperty); }
            set { SetValue(ProgressHeightProperty, value); }
        }

        // Using a DependencyProperty as the backing store for ProgressHeight.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty ProgressHeightProperty =
            DependencyProperty.Register("ProgressHeight", typeof(double), typeof(LoadingIndicator), new UIPropertyMetadata(100.0));



        public double ProgressWidth
        {
            get { return (double)GetValue(ProgressWidthProperty); }
            set { SetValue(ProgressWidthProperty, value); }
        }

        // Using a DependencyProperty as the backing store for ProgressWidth.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty ProgressWidthProperty =
            DependencyProperty.Register("ProgressWidth", typeof(double), typeof(LoadingIndicator), new UIPropertyMetadata(100.0));


        public LoadingIndicator()
        {
            InitializeComponent();

        }

    }
}
