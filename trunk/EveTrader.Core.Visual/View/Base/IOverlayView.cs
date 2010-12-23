using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;

namespace EveTrader.Core.Visual.View
{
    public interface IOverlayView : IExtendedView
    {
        event EventHandler Closed;
    }
}
