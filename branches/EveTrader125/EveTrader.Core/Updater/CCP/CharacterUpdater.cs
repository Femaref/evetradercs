using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EveTrader.Core.Model;
using System.ComponentModel.Composition;

namespace EveTrader.Core.Updater.CCP
{
    [Export]
    public class CharacterUpdater : UpdaterBase<Characters>
    {
        private List<IEntityUpdater<Characters>> iUpdaters = new List<IEntityUpdater<Characters>>();

        private readonly ICharacterSheetUpdater iCharSheetUpdater;
        private readonly IAccountBalanceUpdater iAccountBalanceUpdater;

        private readonly EntityFactory iEntityFactory;

        [ImportingConstructor]
        public CharacterUpdater(TraderModel tm, EntityFactory ef, 
            ICharacterSheetUpdater charSheetUpdater, 
            IAccountBalanceUpdater accountBalanceUpdater,
            IJournalUpdater journalUpdater,
            ITransactionsUpdater transactionsUpdater,
            IMarketOrdersUpdater marketOrdersUpdater)
            : base(tm)
        {
            iEntityFactory = ef;

            iCharSheetUpdater = charSheetUpdater;
            iAccountBalanceUpdater = accountBalanceUpdater;

            iUpdaters.Add((IEntityUpdater<Characters>)journalUpdater);
            iUpdaters.Add((IEntityUpdater<Characters>)transactionsUpdater);
            iUpdaters.Add((IEntityUpdater<Characters>)marketOrdersUpdater);
        }

        public bool Update(long characterID)
        {
            return Update(iModel.Entity.OfType<Characters>().Where(c => c.ID == characterID).FirstOrDefault());
        }

        public bool Update(long characterID, Accounts a)
        {
            return Update(iEntityFactory.CreateCharacter(characterID, a));
        }

        protected override bool InnerUpdate<U>(U entity)
        {
            if (entity == null)
                throw new ArgumentNullException("entity");

            iCharSheetUpdater.Update(entity);
            iAccountBalanceUpdater.Update(entity);

            iUpdaters.ForEach(u => u.Update(entity));
            return true;
        }
    }
}