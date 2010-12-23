using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Waf.Applications;

namespace EveTrader.Core.Visual.ViewModel
{
    public interface ISettingsPage
    {
        object View { get; }
        event EventHandler Closed;
    }
}
