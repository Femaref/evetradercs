using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Waf.Applications;
using System.ComponentModel.Composition;

namespace EveTrader.Core.ViewModel
{
    [InheritedExport]
    public interface ISettingsPage
    {
        object View { get; }
        string Name { get; }
        int Index { get; }
    }
}
