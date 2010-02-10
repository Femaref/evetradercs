using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using Core.DomainModel;

namespace Core.Updaters
{
    public class WalletUpdater : ICharacterUpdater, ICharacterUpdater<IWallet>, ICorporationUpdater, ICorporationUpdater<IWallet>
    {
        #region Implementation of IEntityUpdater<IEntity>

        public bool UpdateEntity(IWallet entity)
        {
            entity.BeforeUpdate();
            bool sucess = true;

            AccountBalanceUpdater abu = new AccountBalanceUpdater();
            if (!abu.UpdateEntity(entity) && entity.Wallets.Count() == 0)
                return false;
            if(entity is Character)
                entity.Wallets.Single().Name = (entity as Character).Name;


            foreach(Wallet w in entity.Wallets)
            {
                WalletJournalUpdater wju = new WalletJournalUpdater();
                if (!wju.UpdateSubEntity(w, entity.ApiData, entity.RequestFrom))
                {
                    Debug.WriteLine("Update failed in " + wju);
                    sucess &= false;
                }
                WalletTransactionsUpdater wtu = new WalletTransactionsUpdater();
                if (!wtu.UpdateSubEntity(w, entity.ApiData, entity.RequestFrom))
                {
                    Debug.WriteLine("Update failed in " + wtu);
                    sucess &= false;
                }

            }
            entity.AfterUpdate();
            return sucess;
        }

        #endregion


        #region Implementation of ICharacterUpdater

        public bool UpdateCharacter(Character character)
        {
            return this.UpdateEntity(character);
        }

        #endregion

        #region Implementation of ICorporationUpdater

        public bool UpdateCorporation(Corporation corporation)
        {
            return this.UpdateEntity(corporation);
        }

        #endregion


    }
}
