using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;
using EveTrader.Core.Visual.View;

namespace EveTrader.Core.Visual.View
{
    public interface IConverterView : IExtendedView
    {
        event CancelEventHandler Closing;
        void Show();
        void Close();
    }
}
