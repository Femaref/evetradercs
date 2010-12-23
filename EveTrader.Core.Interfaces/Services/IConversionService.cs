using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EveTrader.Core.Services
{
    public interface IConversionService
    {
        bool ConversionNecessary();
        bool Convert();
        event EventHandler<ValueIncreasedEventArgs> CurrentObjectIncreased;
        event EventHandler<ValueIncreasedEventArgs> ObjectsIncreased;
        event EventHandler OperationFinished;
    }
}
