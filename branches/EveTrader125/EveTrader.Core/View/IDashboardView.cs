using System;
using System.Collections.Generic;
using System.Text;
using System.Waf.Applications;
using System.Collections.Specialized;

namespace EveTrader.Core.View
{
    public class DetailsRequestedEventArgs : EventArgs
    {
        public DateTime Key { get; set; }
        public string BindingKey { get; set; }

        public DetailsRequestedEventArgs(DateTime key, string bindingKey)
        {
            Key = key;
            BindingKey = bindingKey;
        }
    }

    public interface IDashboardView : IExtendedView
    {
        void ChartCollectionChanged(object sender, NotifyCollectionChangedEventArgs e);
        event EventHandler<DetailsRequestedEventArgs> DetailsRequested;
    }
    
}