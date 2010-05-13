using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel.Composition;
using System.Waf.Applications;
using EveTrader.Core.ViewModel;

namespace EveTrader.Core.Controllers
{
    [Export]
    public class ManageAccountsController : Controller
    {
        private readonly ManageAccountsViewModel iViewModel;

        [ImportingConstructor]
        public ManageAccountsController(ManageAccountsViewModel viewModel)
        {
            iViewModel = viewModel;

            iViewModel.Closing += new System.ComponentModel.CancelEventHandler(iViewModel_Closing);
        }

        void iViewModel_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            throw new NotImplementedException();
        }

        public void Show()
        {
            iViewModel.Show();
        }
    }
}
