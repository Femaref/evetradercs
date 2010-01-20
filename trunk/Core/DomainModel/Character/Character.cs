using System;
using System.Collections.Generic;

namespace Core.DomainModel
{
    public class Character : IGenericObject<Character>
    {
        public int AccountId { get; set; }
        public string ApiKey { get; set; }
        public int Id { get; set; }

        public string Name { get; set; }
        public string Race { get; set; }
        public string BloodLine { get; set; }
        public CharacterGender Gender { get; set; }
        public Corporation Corporation { get; set; }
        public double Balance { get; set; }
        
        public List<WalletTransaction> WalletTransactions { get; set; }
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

        public Character()
        {
            this.Corporation = new Corporation();
            this.WalletTransactions = new List<WalletTransaction>();
            this.WalletJournal = new List<WalletJournalRecord>();
            this.MarketOrders = new List<MarketOrder>();
            this.CustomBuyPrices = new List<CustomPrice>();
            this.Assets = new List<Asset>();
            this.BalanceHistory = new List<WalletHistory>();

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
    }
}
