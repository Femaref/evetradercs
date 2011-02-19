using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EveTrader.Core.Visual.View;
using System.ComponentModel.Composition;

namespace EveTrader.Core.View
{
    [InheritedExport]
    public interface IBasicReportView : IExtendedView
    {
    }
}
