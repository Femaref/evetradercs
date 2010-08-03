using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EveTrader.Core.View;
using System.Waf.Applications;
using EveTrader.Core.Model;
using System.ComponentModel.Composition;
using System.Collections.ObjectModel;
using EveTrader.Core.Collections.ObjectModel;

namespace EveTrader.Core.ViewModel
{
    [Export]
    public class ApplicationLogViewModel : ViewModel<IApplicationLogView>, IRefreshableViewModel
    {
        private readonly TraderModel iModel;

        public SmartObservableCollection<ApplicationLog> Messages {get; set;}

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
            Messages.Clear();
            Messages.AddRange(iModel.ApplicationLog.OrderByDescending(a => a.Date).Take(20));
        }

        public void DataIncoming(object sender, Controllers.EntitiesUpdatedEventArgs e)
        {
            Refresh();
        }
    }
}
