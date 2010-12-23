using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Waf.Applications;
using System.ComponentModel.Composition;
using EveTrader.Core.Visual.View;

namespace EveTrader.Core.ViewModel
{
    [Export]
    public class PriceLookupSettingViewModel : ViewModel<IPriceLookupSettingView>, ISettingsPage
    {
        [ImportingConstructor]
        public PriceLookupSettingViewModel(IPriceLookupSettingView view)
            : base(view)
        {
        }

        public string Name
        {
            get { return "Price Lookup Settings"; }
        }

        public int Index
        {
            get { return 2; }
        }
    }
}
