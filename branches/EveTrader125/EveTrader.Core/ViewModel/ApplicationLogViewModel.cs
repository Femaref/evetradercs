using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EveTrader.Core.View;
using System.Waf.Applications;
using EveTrader.Core.Model;
using System.ComponentModel.Composition;
using System.Collections.ObjectModel;

namespace EveTrader.Core.ViewModel
{
    [Export]
    public class ApplicationLogViewModel : ViewModel<IApplicationLogView>
    {
        private readonly TraderModel iModel;

        public ObservableCollection<ApplicationLog> Messages {get; set;}

        [ImportingConstructor]
        public ApplicationLogViewModel(IApplicationLogView view, TraderModel tm) : base(view)
        {
            iModel = tm;
            Messages = new ObservableCollection<ApplicationLog>();
            Refresh();
        }

        public void Refresh()
        {
            Messages.Clear();
            iModel.ApplicationLog.OrderByDescending(a => a.Date).Take(20).ToList().ForEach(a => Messages.Add(a));
        }

    }
}
