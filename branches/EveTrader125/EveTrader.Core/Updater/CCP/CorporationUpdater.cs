using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EveTrader.Core.Model;

namespace EveTrader.Core.Updater.CCP
{
    public class CorporationUpdater : UpdaterBase<Corporations>
    {
        public CorporationUpdater(TraderModel tm)
            : base(tm)
        {
        }
        protected override bool InnerUpdate(Corporations entity)
        {
            return true;
        }
    }
}
