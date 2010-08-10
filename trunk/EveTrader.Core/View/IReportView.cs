using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections.Specialized;

namespace EveTrader.Core.View
{
    public interface IReportView : IExtendedView
    {
        void ChartCollectionChanged(object sender, NotifyCollectionChangedEventArgs e);
    }
}
