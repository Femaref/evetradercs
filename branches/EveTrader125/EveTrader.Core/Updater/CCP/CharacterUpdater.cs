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
        private List<ICharacterUpdater> iUpdaters = new List<ICharacterUpdater>();

        private readonly EntityFactory iEntityFactory;

        [ImportingConstructor]
        public CharacterUpdater(TraderModel tm, EntityFactory ef, ICharacterSheetUpdater charListUpdater) :base(tm)
        {
            iEntityFactory = ef;

            iUpdaters.Add(charListUpdater);
        }

        public bool Update(long characterID)
        {
            return Update(iModel.Entity.OfType<Characters>().Where(c => c.ID == characterID).FirstOrDefault());
        }

        public bool Update(long characterID, Accounts a)
        {
            return Update(iEntityFactory.CreateCharacter(characterID, a));
        }

        protected override bool InnerUpdate(Characters c)
        {
            if (c == null)
                throw new ArgumentNullException("c");

                iUpdaters.ForEach(u => u.Update(c));
                return true;
        }
    }
}