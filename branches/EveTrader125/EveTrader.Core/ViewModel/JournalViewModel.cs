using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Waf.Applications;
using EveTrader.Core.View;
using System.ComponentModel.Composition;
using EveTrader.Core.Model;

namespace EveTrader.Core.ViewModel
{
    public class JournalViewModel : ViewModel<IJournalView>
    {
        private readonly TraderModel iModel;

        [ImportingConstructor]
        public JournalViewModel(IJournalView view, TraderModel tm)
            : base(view)
        {
            iModel = tm;
        }
    }
}