using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EveTrader.Core.View
{
    public class EntitySelectionChangedEventArgs<T> : EventArgs
    {
        public T Selection { get; set; }

        public EntitySelectionChangedEventArgs(T newSelection)
        {
            Selection = newSelection;
        }
    }
}
