using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Waf.Applications;
using EveTrader.Core.Visual.View;

namespace EveTrader.Core.Visual.ViewModel
{
    public class ConverterViewModel : ViewModel<IConverterView>, IRefreshableViewModel
    {
        public ConverterViewModel(IConverterView view)
            : base(view)
        {
        }

        public void Refresh()
        {
            throw new NotImplementedException();
        }

        public void DataIncoming(object sender, Services.EntitiesUpdatedEventArgs e)
        {
            throw new NotImplementedException();
        }

        public bool Updating
        {
            get { throw new NotImplementedException(); }
        }
    }
}
