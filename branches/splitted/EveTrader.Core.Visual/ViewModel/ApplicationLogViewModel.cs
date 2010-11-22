using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EveTrader.Core.Visual.View;
using System.Waf.Applications;
using EveTrader.Core.Model.Trader;
using System.ComponentModel.Composition;
using System.Collections.ObjectModel;
using EveTrader.Core.Collections.ObjectModel;
using System.Threading;

namespace EveTrader.Core.Visual.ViewModel
{
    [Export]
    public class ApplicationLogViewModel : ViewModel<IApplicationLogView>, IRefreshableViewModel
    {
        private readonly TraderModel iModel;

        private object iUpdaterLock = new object();
        private bool iUpdating;

        public SmartObservableCollection<ApplicationLog> Messages {get; private set;}
        public bool Updating
        {
            get
            {
                return iUpdating;
            }
            private set
            {
                iUpdating = value;
                RaisePropertyChanged("Updating");
            }
        }

        [ImportingConstructor]
        public ApplicationLogViewModel(IApplicationLogView view, [Import(RequiredCreationPolicy=CreationPolicy.NonShared)] TraderModel tm)
            : base(view)
        {
            iModel = tm;
            Messages = new SmartObservableCollection<ApplicationLog>(view.BeginInvoke);
            Refresh();
        }

        public void Refresh()
        {
            Thread t = new Thread(new ThreadStart(this.ThreadedRefresh));
            t.Name = "ApplicationLogRefresh";
            t.Start();
        }
        private void ThreadedRefresh()
        {
            lock (iUpdaterLock)
            {
                Messages.Clear();
                Messages.AddRange(iModel.ApplicationLog.OrderByDescending(a => a.Date).Take(20));
            }
        }

        public void DataIncoming(object sender, Services.EntitiesUpdatedEventArgs e)
        {
            Refresh();
        }
    }
}
