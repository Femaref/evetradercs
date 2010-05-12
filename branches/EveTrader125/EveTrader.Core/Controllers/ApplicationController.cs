using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Waf.Applications;
using System.ComponentModel.Composition;
using EveTrader.Core.Model;
using EveTrader.Core.View;
using EveTrader.Core.ViewModel;

namespace EveTrader.Core.Controllers
{
    [Export]
    public class ApplicationController : Controller
    {
        private readonly MainWindowViewModel iMainWindowViewModel;
        private readonly TraderModel iModel;

        [ImportingConstructor]
        public ApplicationController(MainWindowViewModel mainView, TraderModel tm)
        {
            iMainWindowViewModel = mainView;
            iModel = tm;

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
