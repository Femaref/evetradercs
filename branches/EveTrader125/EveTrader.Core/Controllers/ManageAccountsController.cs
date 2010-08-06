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
using EveTrader.Core.Updater.CCP;

namespace EveTrader.Core.Controllers
{
    [Export]
    public class ManageAccountsController : Controller
    {
        private readonly CompositionContainer iContainer;
        private ManageAccountsViewModel iViewModel;

        [ImportingConstructor]
        public ManageAccountsController(CompositionContainer container)
        {
            iContainer = container;
            
        }

        public void Show()
        {
            iViewModel = new ManageAccountsViewModel(
                iContainer.GetExportedValue<IManageAccountsView>(), 
                iContainer.GetExportedValue<TraderModel>(), 
                iContainer.GetExportedValue<IUpdateService>(),
                iContainer.GetExportedValue<EntityFactory>());
           iViewModel.Show();
        }

        public void Shutdown()
        {
            if (iViewModel != null)
                iViewModel.Shutdown();
        }
    }
}
