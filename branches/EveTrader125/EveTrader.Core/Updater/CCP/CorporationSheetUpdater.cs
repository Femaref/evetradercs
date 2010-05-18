using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EveTrader.Core.Model;

namespace EveTrader.Core.Updater.CCP
{
    public  class CorporationSheetUpdater : UpdaterBase<Corporations>, ICorporationSheetUpdater
    {
        public CorporationSheetUpdater(TraderModel tm)
            : base(tm)
        {
        }

        protected override bool InnerUpdate(Corporations entity)
        {
            throw new NotImplementedException();
        }
    }
}
