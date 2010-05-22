using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EveTrader.Core.View
{
    public class EntitySelectionChangedEventArgs : EventArgs
    {
        public string Selection { get; set; }

        public EntitySelectionChangedEventArgs(string newSelection)
        {
            Selection = newSelection;
        }
    }
}
