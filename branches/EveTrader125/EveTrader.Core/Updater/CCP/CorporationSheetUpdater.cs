using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EveTrader.Core.Model;
using EveTrader.Core.Network.Requests.CCP;

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
            var charID = (from a in 
                          where a.Entities.Contains(entity) 

            CorporationSheetRequest csr = new CorporationSheetRequest(entity.Account, 
            return true;
        }
    }
}
