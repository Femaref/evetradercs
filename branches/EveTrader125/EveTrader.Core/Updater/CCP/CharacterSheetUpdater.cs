using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EveTrader.Core.Model;
using EveTrader.Core.Network.Requests.CCP;
using System.ComponentModel.Composition;

namespace EveTrader.Core.Updater.CCP
{
    [Export(typeof(ICharacterSheetUpdater))]
    public class CharacterSheetUpdater : UpdaterBase<Characters>, ICharacterSheetUpdater
    {
        private readonly CorporationUpdater iCorporationUpdater;

        [ImportingConstructor]
        public CharacterSheetUpdater(TraderModel tm, CorporationUpdater corpUpdater)
            : base(tm)
        {
            iCorporationUpdater = corpUpdater;
        }

        protected override bool InnerUpdate<U>(U entity)
        {
            CharacterSheetRequest req = new CharacterSheetRequest(entity.Account, entity.ID, iModel.StillCached, iModel.SaveCache, iModel.LoadCache);

            Characters c = req.Request();

            entity.Name = c.Name;
            entity.Race = c.Race;
            entity.Balance = c.Balance;
            entity.Bloodline = c.Bloodline;
            entity.Gender = c.Gender;
            iCorporationUpdater.Update(c.Corporation.ID, entity.Account, entity.ID);
            entity.Corporation = iModel.Entity.OfType<Corporations>().First(s => s.ID == c.Corporation.ID);


            iModel.SaveChanges();

            return true;
        }
    }
}
