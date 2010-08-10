using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EveTrader.Core.ViewModel.Display
{
    public class SelectedChangedEventArgs : EventArgs
    {
        bool NewValue { get; set; }

        public SelectedChangedEventArgs (bool newValue)
        {
            NewValue = newValue;
        }
    }
}
