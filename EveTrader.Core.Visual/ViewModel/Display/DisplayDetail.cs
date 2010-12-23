using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Diagnostics;
using System.ComponentModel;

namespace EveTrader.Core.Visual.ViewModel.Display
{
    [DebuggerDisplay("TypeName: {TypeName} Value: {Value}")]
    public class DisplayDetail : INotifyPropertyChanged
    {
        public string TypeName
        {
            get
            {
                return iTypeName;
            }
            set
            {
                iTypeName = value;
                RaisePropertyChanged("TypeName");
            }
        }
        public decimal Value
        {
            get
            {
                return iValue;
            }
            set
            {
                iValue = value;
                RaisePropertyChanged("Value");
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        private string iTypeName;
        private decimal iValue;

        private void RaisePropertyChanged(string p)
        {
            var handler = PropertyChanged;
            if (handler != null)
                handler(this, new PropertyChangedEventArgs(p));
        }
    }
}
