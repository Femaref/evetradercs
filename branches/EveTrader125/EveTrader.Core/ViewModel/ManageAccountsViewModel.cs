using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Waf.Applications;
using EveTrader.Core.View;
using EveTrader.Core.Model;
using System.ComponentModel;
using System.ComponentModel.Composition;

namespace EveTrader.Core.ViewModel
{
    public class ManageAccountsViewModel : ViewModel<IManageAccountsView>
    {
        private readonly TraderModel iModel;

        public event CancelEventHandler Closing;

        public ManageAccountsViewModel(IManageAccountsView view, TraderModel tm)
            : base(view)
        {
            iModel = tm;
            view.Closing += new System.ComponentModel.CancelEventHandler(ViewCore_Closing);
        }

        void ViewCore_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            OnClosing(e);
        }

        private void OnClosing(System.ComponentModel.CancelEventArgs e)
        {
            CancelEventHandler handler = Closing;
            if (handler != null)
                handler(this, e);
        }


        public void Show()
        {
            this.ViewCore.Show();
        }

        public void Shutdown()
        {
            iModel.Dispose();
        }
    }
}
