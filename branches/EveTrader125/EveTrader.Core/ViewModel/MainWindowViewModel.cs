using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Waf.Applications;
using EveTrader.Core.View;
using System.ComponentModel.Composition;
using System.ComponentModel;

namespace EveTrader.Core.ViewModel
{
    [Export]
    public class MainWindowViewModel : ViewModel<IMainWindowView>
    {
        [ImportingConstructor]
        public MainWindowViewModel(IMainWindowView view): base(view)
        {
            view.Closing += ViewClosing;
        }


        public void Show()
        {
            this.ViewCore.Show();
        }
        public event CancelEventHandler Closing;
        protected virtual void OnClosing(CancelEventArgs e)
        {
            if (Closing != null) { Closing(this, e); }
        }
        private void ViewClosing(object sender, CancelEventArgs e)
        {
            OnClosing(e);
        }
    }
}
