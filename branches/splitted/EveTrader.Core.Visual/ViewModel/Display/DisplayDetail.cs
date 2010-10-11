using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Diagnostics;

namespace EveTrader.Core.ViewModel.Display
{
    [DebuggerDisplay("TypeName: {TypeName} Value: {Value}")]
    public class DisplayDetail
    {
        public string TypeName { get; set; }
        public decimal Value { get; set; }
    }
}
