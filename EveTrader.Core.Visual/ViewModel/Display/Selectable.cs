using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EveTrader.Core.ViewModel.Display
{
    public class Selectable<T>
    {
        public event EventHandler<SelectedChangedEventArgs> SelectedChanged;
        private bool iIsSelected;


        public T Item { get; set; }

        public bool IsSelected
        {
            get
            {
                return iIsSelected;
            }
            set
            {
                iIsSelected = value;
                RaiseSelectedChanged(value);
            }
        }

        public Selectable(T item, bool isSelected)
        {
            Item = item;
            IsSelected = isSelected;
        }

        public static implicit operator Selectable<T>(T input)
        {
            return new Selectable<T>(input, false);
        }

        public static implicit operator T (Selectable<T> input)
        {
            return input.Item;
        }



        private void RaiseSelectedChanged(bool newValue)
        {
            var handler = SelectedChanged;
            if (handler != null)
                handler(this, new SelectedChangedEventArgs(newValue));
        }
    }
}
