﻿using System;
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
using EveTrader.Core.Collections.ObjectModel;
using System.Threading;

namespace EveTrader.Core.ViewModel
{
    [Export]
    public class WalletsViewModel : ViewModel<IWalletsView>, IRefreshableViewModel
    {
        private readonly TraderModel iModel;

        private object iUpdaterLock = new object();

        public SmartObservableCollection<DisplayWallets> EntityWallets { get; private set; }

        [ImportingConstructor]
        public WalletsViewModel(IWalletsView view, [Import(RequiredCreationPolicy = CreationPolicy.NonShared)] TraderModel tm)
            : base(view)
        {
            iModel = tm;
            EntityWallets = new SmartObservableCollection<DisplayWallets>(view.BeginInvoke);
            Refresh();
        }

        public void Refresh()
        {
            Action updater = () =>
                {
                    lock (iUpdaterLock)
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
                };
            Thread updaterThread = new Thread(new ThreadStart(updater));
            updaterThread.Start();
        }

        public void DataIncoming(object sender, Controllers.EntitiesUpdatedEventArgs e)
        {
            Refresh();
        }
    }
}
