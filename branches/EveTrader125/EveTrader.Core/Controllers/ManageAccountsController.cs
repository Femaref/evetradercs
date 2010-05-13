using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel.Composition;
using System.Waf.Applications;
using EveTrader.Core.ViewModel;
using System.ComponentModel.Composition.Hosting;
using EveTrader.Core.View;
using EveTrader.Core.Model;

namespace EveTrader.Core.Controllers
{
    [Export]
    public class ManageAccountsController : Controller
    {
        private readonly CompositionContainer iContainer;

        [ImportingConstructor]
        public ManageAccountsController(CompositionContainer container)
        {
            iContainer = container;
            
        }

        public void Show()
        {
            ManageAccountsViewModel model = new ManageAccountsViewModel(iContainer.GetExportedValue<IManageAccountsView>(), iContainer.GetExportedValue<TraderModel>());
            model.Show();
        }

        public void Shutdown()
        {
            
        }

        public void Initialize()
        {
            
        }
    }
}
