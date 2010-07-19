using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EveTrader.Core.ViewModel.Display
{
    public class Selectable<T>
    {
        public T Item { get; set; }
        public bool IsSelected { get; set; }

        public Selectable(T item, bool isSelected)
        {
            Item = item;
            IsSelected = isSelected;
        }

        public static implicit operator Selectable<T>(T input)
        {
            return new Selectable<T>(input, false);
        }
    }
}
