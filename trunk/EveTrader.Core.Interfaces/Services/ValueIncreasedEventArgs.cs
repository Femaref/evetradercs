using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EveTrader.Core.Services
{
    public class ValueIncreasedEventArgs : EventArgs
    {
        public int NewValue { get; private set; }

        public ValueIncreasedEventArgs(int newValue)
        {
            NewValue = newValue;
        }
    }
}
