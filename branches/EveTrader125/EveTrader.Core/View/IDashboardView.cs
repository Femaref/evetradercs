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

        public DetailsRequestedEventArgs(DateTime key)
        {
            Key = key;
        }
    }

	public interface IDashboardView : IView
	{
        void ChartCollectionChanged(object sender, NotifyCollectionChangedEventArgs e);
        event EventHandler<DetailsRequestedEventArgs> DetailsRequested;
	}
	
}