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
        private readonly List<ICorporationUpdater> iUpdater = new List<ICorporationUpdater>();

        public CorporationUpdater(TraderModel tm, EntityFactory ef, ICorporationSheetUpdater corpSheetUpdater)
            : base(tm)
        {
            iEntityFactory = ef;

            iUpdater.Add(corpSheetUpdater);
        }
        protected override bool InnerUpdate(Corporations entity)
        {
            if (entity == null)
                throw new ArgumentNullException("entity");

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
