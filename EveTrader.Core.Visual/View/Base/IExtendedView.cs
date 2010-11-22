using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Waf.Applications;

namespace EveTrader.Core.Visual.View
{
    public interface IExtendedView : IView
    {
        void Invoke(Action action);
        void BeginInvoke(Action action);
    }
}
