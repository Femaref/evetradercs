using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EveTrader.Core.Visual.View;
using System.Waf.Applications;
using System.ComponentModel.Composition;
using EveTrader.Core.Collections.ObjectModel;
using System.Windows.Input;
using EveTrader.Core.ViewModel;

namespace EveTrader.Core.Visual.ViewModel
{
    [Export]
    public class SettingsViewModel : ViewModel<ISettingsView>, ISettingsParent
    {
        public SmartObservableCollection<ISettingsPage> SettingPages { get; private set; }

        private ICommand closeCommand;

        public ICommand CloseCommand
        {
            get { return closeCommand; }
            set
            {
                closeCommand = value;
                RaisePropertyChanged("CloseCommand");
            }
        }



        [ImportingConstructor]
        public SettingsViewModel(ISettingsView view, [ImportMany] IEnumerable<ISettingsPage> pages)
            : base(view)
        {
            SettingPages = new SmartObservableCollection<ISettingsPage>(view.BeginInvoke);

            SettingPages.AddRange(pages.OrderBy(p => p.Index).ThenBy(p => p.Name));

            CloseCommand = new DelegateCommand(() => RaiseClosed());
        }

        #region ISettingsParent

        public event EventHandler Closed;

        private void RaiseClosed()
        {
            var handler = Closed;

            if (handler != null)
                handler(this, EventArgs.Empty);
        }

        #endregion
    }
}
