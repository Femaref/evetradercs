using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Waf.Applications;
using System.ComponentModel;

namespace EveTrader.Core.View
{
    public interface IManageAccountsView : IExtendedView
    {
        event EventHandler AbortRequest;
        event EventHandler AddCharacters;
        event EventHandler<CharacterDataRequestedEventArgs> DataRequested;
        event CancelEventHandler Closing;
        void Show();
        void Close();
    }
}
