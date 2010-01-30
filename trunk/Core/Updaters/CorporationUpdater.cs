using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using Core.DomainModel;

namespace Core.Updaters
{
    public class CorporationUpdater : ICharacterUpdater
    {
        #region ICharacterUpdater Members

        public bool UpdateCharacter(Character character)
        {

            List<ICorporationUpdater> updater = new List<ICorporationUpdater>()
                                        {
                                            new CorporationSheetUpdater(),
                                            new WalletUpdater()
                                        };

            bool updated = true;

            Action<ICorporationUpdater> iter = ic =>
            {
                if (!ic.UpdateCorporation(character.Corporation))
                {
                    Debug.WriteLine(
                        "Update failed in " +
                        ic.GetType().Namespace +
                        ic.GetType().Name);
                    updated &= false;
                }
                else return;
            };

            updater.ForEach(iter);

            return updated;
        }

        #endregion
    }
}
