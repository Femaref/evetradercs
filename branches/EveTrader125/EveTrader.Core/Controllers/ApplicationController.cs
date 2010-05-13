using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Waf.Applications;
using System.ComponentModel.Composition;
using EveTrader.Core.Model;
using EveTrader.Core.View;
using EveTrader.Core.ViewModel;
using System.Windows.Input;

namespace EveTrader.Core.Controllers
{
    [Export]
    public class ApplicationController : Controller
    {
        private readonly MainWindowViewModel iMainWindowViewModel;
        private readonly ManageAccountsController iManageAccounts;
        private readonly TraderModel iModel;

        private readonly ICommand iOpenManageAccountsCommand;

        public ICommand OpenManageAccountsCommand
        {
            get { return iOpenManageAccountsCommand; }
        }

        [ImportingConstructor]
        public ApplicationController(MainWindowViewModel mainView, ManageAccountsController manageAccounts, TraderModel tm)
        {
            iMainWindowViewModel = mainView;
            iManageAccounts = manageAccounts;
            iModel = tm;

            iOpenManageAccountsCommand = new DelegateCommand(OpenManageAccounts);

        }

        private void OpenManageAccounts()
        {
            iManageAccounts.Show();
        }

        public void Initialize()
        {
        }

        public void Run()
        {
            iMainWindowViewModel.Show();
        }

        public void Shutdown()
        {
            iModel.Dispose();
        }
    }
}
