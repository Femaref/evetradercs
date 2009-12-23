namespace Core.DomainModel
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Xml.Linq;

    public class WalletTransaction : IGenericObject<WalletTransaction>
    {
        public int TransactionID { get; set; }
        public WalletTransactionType TransactionType { get; set; }
        public WalletTransactionFor TransactionFor { get; set; }
        public DateTime TransactionDateTime { get; set; }
        public int Quantity { get; set; }
        public double Price { get; set; }
        public int TypeID { get; set; }
        public string TypeName { get; set; }
        public int ClientID { get; set; }
        public string ClientName { get; set; }
        public int StationID { get; set; }
        public string StationName { get; set; }   
        
        public bool Ignore { get; set; }

        public IEqualityComparer<WalletTransaction> GetComparer()
        {
            return new WalletTransactionComparer();
        }
    }
}


