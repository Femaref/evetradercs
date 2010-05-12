using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Waf.Applications;
using System.ComponentModel;

namespace EveTrader.Core.View
{
    public interface IMainWindowView : IView
    {
        event CancelEventHandler Closing;
        void Show();
        void Close();
    }
}
