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

namespace EveTrader.Wpf.Controls
{
    /// <summary>
    /// Interaction logic for ExceptionDisplay.xaml
    /// </summary>
    public partial class ExceptionDisplay : Window
    {


        public string Header
        {
            get { return (string)GetValue(HeaderProperty); }
            set { SetValue(HeaderProperty, value); }
        }

        // Using a DependencyProperty as the backing store for Header.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty HeaderProperty =
            DependencyProperty.Register("Header", typeof(string), typeof(ExceptionDisplay), new UIPropertyMetadata(""));



        public string Details
        {
            get { return (string)GetValue(DetailsProperty); }
            set { SetValue(DetailsProperty, value); }
        }

        // Using a DependencyProperty as the backing store for Details.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty DetailsProperty =
            DependencyProperty.Register("Details", typeof(string), typeof(ExceptionDisplay), new UIPropertyMetadata(""));



        public string  Message
        {
            get { return (string )GetValue(MessageProperty); }
            set { SetValue(MessageProperty, value); }
        }

        // Using a DependencyProperty as the backing store for Message.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty MessageProperty =
            DependencyProperty.Register("Message", typeof(string ), typeof(ExceptionDisplay), new UIPropertyMetadata(""));
        private Exception iCurrent;

        


        public ExceptionDisplay()
        {
            InitializeComponent();
        }

        public Exception Current
        {
            get
            {
                return iCurrent;
            }
            set
            {
                iCurrent = value;
                Header = value.GetType().Name;
                Details = value.ToString();
                Message = value.Message;
            }
        }

        private void iOk_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void iCopy_Click(object sender, RoutedEventArgs e)
        {
            Clipboard.SetText(Current.ToString());
        }
    }
}
