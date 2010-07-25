using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Waf.Applications;
using EveTrader.Core.View;
using EveTrader.Core.Model;
using System.ComponentModel.Composition;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Diagnostics;
using EveTrader.Core.ViewModel.Display;

namespace EveTrader.Core.ViewModel
{
    [Export]
    public class WalletsViewModel : ViewModel<IWalletsView>
    {
        private readonly TraderModel iModel;

        public ObservableCollection<DisplayWallets> EntityWallets { get; private set; }


        [ImportingConstructor]
        public WalletsViewModel(IWalletsView view, TraderModel tm)
            : base(view)
        {
            iModel = tm;
            EntityWallets = new ObservableCollection<DisplayWallets>();
            Refresh();
        }

        public void Refresh()
        {
            EntityWallets.Clear();

            foreach (Entities e in iModel.Entity)
            {
                if (e is Characters)
                    EntityWallets.Add(new DisplayWallets() { Name = e.Name, Balance = e.Wallets.First().Balance });
                if (e is Corporations)
                {
                    foreach (Wallets w in e.Wallets)
                    {
                        EntityWallets.Add(new DisplayWallets() { Name = string.Format("{0}: {1}", e.Name, w.Name), Balance = w.Balance });
                    }
                }
            }
        }
    }
}
