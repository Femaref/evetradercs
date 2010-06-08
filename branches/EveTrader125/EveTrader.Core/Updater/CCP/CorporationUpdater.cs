using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EveTrader.Core.Model;
using System.ComponentModel.Composition;

namespace EveTrader.Core.Updater.CCP
{
    [Export]
    public class CorporationUpdater : UpdaterBase<Corporations>
    {
        private readonly EntityFactory iEntityFactory;
        private readonly List<IEntityUpdater<Corporations>> iUpdaters = new List<IEntityUpdater<Corporations>>();
        private readonly ICorporationSheetUpdater iCorpSheetUpdater;
        private readonly IAccountBalanceUpdater iAccountBalanceUpdater;

        [ImportingConstructor]
        public CorporationUpdater(TraderModel tm, EntityFactory ef,
            ICorporationSheetUpdater corpSheetUpdater,
            IAccountBalanceUpdater accountBalanceUpdater,
            IJournalUpdater journalUpdater,
            ITransactionsUpdater transactionsUpdater,
            IMarketOrdersUpdater marketOrdersUpdater)
            : base(tm)
        {
            iEntityFactory = ef;

            iCorpSheetUpdater = corpSheetUpdater;
            iAccountBalanceUpdater = accountBalanceUpdater;

            iUpdaters.Add((IEntityUpdater<Corporations>)journalUpdater);
            iUpdaters.Add((IEntityUpdater<Corporations>)transactionsUpdater);
            iUpdaters.Add((IEntityUpdater<Corporations>)marketOrdersUpdater);
        }
        protected override bool InnerUpdate<U>(U entity)
        {
            if (entity == null)
                throw new ArgumentNullException("entity");

            try
            {
                iCorpSheetUpdater.Update(entity);
            }
            catch (UpdaterFailedException ex)
            {
                iModel.WriteToLog(ex.ToString(), ex.InnerException.TargetSite.DeclaringType.Name + "." + ex.InnerException.TargetSite.Name);
            }

            

            if (!entity.Npc)
            {
                try
                {
                    iAccountBalanceUpdater.Update(entity);
                }
                catch (UpdaterFailedException ex)
                {
                    iModel.WriteToLog(ex.ToString(), ex.InnerException.TargetSite.DeclaringType.Name + "." + ex.InnerException.TargetSite.Name);
                }
               
                iUpdaters.ForEach(u =>
                {
                    try
                    {
                        u.Update(entity);
                    }
                    catch (UpdaterFailedException ex)
                    {
                        iModel.WriteToLog(ex.ToString(), ex.InnerException.TargetSite.DeclaringType.Name + "." + ex.InnerException.TargetSite.Name);
                    }
                }
                );
            }

            return true;
        }

        public bool Update(long corporationID)
        {
            return Update(iModel.Entity.OfType<Corporations>().Where(c => c.ID == corporationID).FirstOrDefault());
        }

        public bool Update(long corporationID, Accounts a, long apiCharacterID)
        {
            return Update(iEntityFactory.CreateCorporation(corporationID, a, apiCharacterID));
        }
    }
}
