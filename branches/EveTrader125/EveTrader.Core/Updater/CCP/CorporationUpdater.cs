using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EveTrader.Core.Model;

namespace EveTrader.Core.Updater.CCP
{
    public class CorporationUpdater : UpdaterBase<Corporations>
    {
        private readonly EntityFactory iEntityFactory;
        private readonly List<IEntityUpdater<Corporations>> iUpdater = new List<IEntityUpdater<Corporations>>();
        private readonly ICorporationSheetUpdater iCorpSheetUpdater;

        public CorporationUpdater(TraderModel tm, EntityFactory ef, ICorporationSheetUpdater corpSheetUpdater)
            : base(tm)
        {
            iEntityFactory = ef;

            iCorpSheetUpdater = corpSheetUpdater;
        }
        protected override bool InnerUpdate<U>(U entity)
        {
            if (entity == null)
                throw new ArgumentNullException("entity");

            iCorpSheetUpdater.Update(entity);

            iUpdater.ForEach(u => u.Update(entity));

            return true;
        }

        public bool Update(long corporationID)
        {
            return Update(iModel.Entity.OfType<Corporations>().Where(c => c.ID == corporationID).FirstOrDefault());
        }

        public bool Update(long corporationID, Accounts a)
        {
            return Update(iEntityFactory.CreateCorporation(corporationID, a));
        }
    }
}
