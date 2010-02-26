using System;
using System.Collections.Generic;
using Core.Network;
using Core.Network.EveApi;
using Core.Updaters;

namespace Core.DomainModel
{
    public class Character : IEntity, IGenericObject<Character>, IAccount, IWallet, IMarketOrder
    {
        //[Obsolete("Use IAccount.ApiData")]
        public int AccountId { get; set; }
       // [Obsolete("Use IAccount.ApiData")]
        public string ApiKey { get; set; }
        public int ID { get; set; }

        public string Name { get; set; }
        public string Race { get; set; }
        public string BloodLine { get; set; }
        public CharacterGender Gender { get; set; }
        public Corporation Corporation { get; set; }
        public double Balance { get; set; }

        [Obsolete("Use Wallets.* instead")]
        public List<WalletTransaction> WalletTransactions { get; set; }
        [Obsolete("Use Wallets.* instead")]
        public List<WalletJournalRecord> WalletJournal { get; set; }
        public List<MarketOrder> MarketOrders { get; set; }
        public List<Asset> Assets { get; set; }
        public List<CustomPrice> CustomBuyPrices { get; set; }
        public List<Standing> Standings { get; set; }
        public List<WalletHistory> BalanceHistory { get; set; }

        public DateTime NextWalletTransactionsUpdateTime { get; set; }
        public DateTime NextWalletJournalUpdateTime { get; set; }
        public DateTime NextMarketOrdersUpdateTime { get; set; }
        public DateTime NextAssetsUpdateTime { get; set; }
        public DateTime NextStandingUpdateTime { get; set; }

        public int AccountingLevel { get; set; }

        public DateTime NextUpdateTime
        {
            get
            {
                DateTime result = DateTime.MinValue;

                result = this.NextWalletTransactionsUpdateTime > result ? this.NextWalletTransactionsUpdateTime : result;
                result = this.NextWalletJournalUpdateTime > result ? this.NextWalletJournalUpdateTime : result;
                result = this.NextMarketOrdersUpdateTime > result ? this.NextMarketOrdersUpdateTime : result;
                result = this.NextAssetsUpdateTime > result ? this.NextAssetsUpdateTime : result;
                result = this.NextStandingUpdateTime > result ? this.NextStandingUpdateTime : result;

                return result;
            }
        }

        void IEntity.BeforeUpdate()
        {
            return;
        }

        void IWallet.AfterUpdate()
        {
            return;
        }

        void IWallet.BeforeUpdate()
        {
            return;
        }

        void IEntity.AfterUpdate()
        {
            return;
        }

        public Character()
        {
            this.Name = "";
            this.Race = "";
            this.BloodLine = "";

            this.Corporation = new Corporation();
            this.MarketOrders = new List<MarketOrder>();
            this.CustomBuyPrices = new List<CustomPrice>();
            this.Assets = new List<Asset>();
            this.BalanceHistory = new List<WalletHistory>();
            this.Wallets = new List<Wallet>();


            this.NextWalletTransactionsUpdateTime = DateTime.Now;
            this.NextWalletJournalUpdateTime = DateTime.Now;
            this.NextMarketOrdersUpdateTime = DateTime.Now;
            this.NextAssetsUpdateTime = DateTime.Now;
        }

        public IEqualityComparer<Character> GetComparer()
        {
            return new CharacterComparer();
        }

        public override string ToString()
        {
            return this.Name;
        }

        #region IAccount Members

        private Account iApiData;
        public Core.Network.Account ApiData
        {
            get { return iApiData; }
            set
            {
                iApiData = value;
                this.Corporation.ApiData = value;
            }
        }

        public EveApiResourceFrom RequestFrom { get { return EveApiResourceFrom.Character; } }

        #endregion

        #region IWallet Members

        public List<Wallet> Wallets
        {
            get; set;
        }

        #endregion
    }
}
