using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Core.Network.EveApi.Entities;

namespace Core.DomainModel
{
    [Serializable]
    public class Wallet : IGenericObject<Wallet>, IWalletJournal, IWalletTransactions, IAccountBalance
    {
        public int ID { get; set; }
        public int Key { get; set; }
        public string Name { get; set; }
        public decimal Balance { get; set; }
        public DateTime NextAccountBalanceUpdate{get; set; }

        public List<WalletTransaction> Transactions { get; set; }
        public DateTime NextWalletTransactionsUpdateTime {   get; set; }

        public List<WalletJournalRecord> Journal { get; set; }
        public DateTime NextWalletJournalUpdateTime{ get; set;}

        public Wallet()
        {
            this.Transactions = new List<WalletTransaction>();
            this.Journal = new List<WalletJournalRecord>();
            this.Name = "Noname";
        }

        public override int GetHashCode()
        {
            return ID*Key;
        }
        public override bool Equals(object obj)
        {
            Wallet w = obj as Wallet;
            if (w != null)
                return w.ID == this.ID && w.Key == w.Key;
            else
                return false;
            
        }

        #region IGenericObject<Wallet> Members

        public IEqualityComparer<Wallet> GetComparer()
        {
            return new WalletComparer();
        }

        #endregion

        public override string ToString()
        {
            return this.Name;
        }
    }
}