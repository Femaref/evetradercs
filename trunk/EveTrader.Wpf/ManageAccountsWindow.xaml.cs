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
    [Export(typeof(IManageAccountsView)), PartCreationPolicy(CreationPolicy.NonShared)]
    public partial class ManageAccountsWindow : Window, IManageAccountsView
    {
        public ManageAccountsWindow()
        {
            InitializeComponent();
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

        private void iSubmitDetails_Click(object sender, RoutedEventArgs e)
        {
            RaiseDataRequested(long.Parse(iUserID.Text), iApiKey.Text);
        }

        #region IManageAccountsView Members

        private void RaiseDataRequested(long userID, string apikey)
        {
            var handler = DataRequested;
            if (handler != null)
            {
                handler(this, new CharacterDataRequestedEventArgs(userID, apikey));
            }
        }

        public event EventHandler<CharacterDataRequestedEventArgs> DataRequested;

        private void RaiseAbortRequest()
        {
            var handler = AbortRequest;

            if (handler != null)
                handler(this, new EventArgs());
        }

        public event EventHandler AbortRequest;

        private void RaiseAddCharacters()
        {
            var handler = AddCharacters;

            if (handler != null)
                handler(this, new EventArgs());
        }

        public event EventHandler AddCharacters;
        #endregion


        private void iAbortRequest_Click(object sender, RoutedEventArgs e)
        {
            RaiseAbortRequest();
        }

        private void iAddCharacters_Click(object sender, RoutedEventArgs e)
        {
            RaiseAddCharacters();
        }
    }
}
