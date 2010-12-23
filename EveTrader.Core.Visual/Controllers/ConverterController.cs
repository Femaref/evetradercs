using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Waf.Applications;
using System.ComponentModel.Composition;
using System.ComponentModel.Composition.Hosting;
using EveTrader.Core.Visual.ViewModel;
using EveTrader.Core.Visual.View;
using EveTrader.Core.Services;
using EveTrader.Core.Model.Trader;

namespace EveTrader.Core.Controllers
{
    [Export]
    public class ConverterController : Controller
    {

        [ImportingConstructor]
        public ConverterController(
            MainWindowViewModel mainView, 
            ConverterViewModel viewModel, 
            IConversionService cs, 
            [ImportMany] IEnumerable<IRefreshableViewModel> targets)
        {
            mainView.ConverterView = viewModel.View;
            
            mainView.ConverterShown = cs.ConversionNecessary();
            viewModel.Closed += (obj, e) => { mainView.ConverterShown = false; };

            foreach (IRefreshableViewModel v in targets)
                viewModel.Closed += (obj, e) => { v.Refresh(); };
        }
    }
}
