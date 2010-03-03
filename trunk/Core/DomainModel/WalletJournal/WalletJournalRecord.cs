using System;
using System.Collections.Generic;

namespace Core.DomainModel
{
    public class WalletJournalRecord : IGenericObject<WalletJournalRecord>
    {
        public DateTime Date { get; set; }
        public long ReferenceID { get; set; }
        public int ReferenceTypeID { get; set; }
        public string OwnerName1 { get; set; }
        public int OwnerID1 { get; set; }
        public string OwnerName2 { get; set; }
        public int OwnerID2 { get; set; }
        public string ArgName1 { get; set; }
        public int ArgID1 { get; set; }
        public double Amount { get; set; }
        public double Balance { get; set; }
        public decimal TaxAmount { get; set; }
        public int TaxReceiverID { get; set; }
        public string Reason { get; set; }



        //        Name 	Type 	Description 
        //date 	date string 	Date & time of the transaction 
        //refID 	bigint 	ID of transaction. Guaranteed to be unique with this page call; Was previously subject to renumbering periodically to remain within the limit of a 32bit integer [1]. As of 10/01/2010 the values of refID being seen have exceeded this limit, indicating that CCP have upgraded this field to a bigint (64bit integer), removing the need for further renumbering. Use the last listed refID with the beforeRefID argument to walk the list (see Journal Walking, below). 
        //refTypeID 	int 	Transaction type. See RefTypes. 
        //ownerName1 	string 	Name of first party in the transaction. 
        //ownerID1 	int 	Character or corporation ID of the first party. 
        //ownerName2 	string 	Name of second party in the transaction. 
        //ownerID2 	int 	Character or corporation ID of the second party. 
        //argName1 	varies 	See Arguments, below. 
        //argID1 	int 	See Arguments, below. 
        //amount 	decimal 	The amount transferred between parties (if this shows up in the in-game wallet as green, the number is positive; if red, then negative). 
        //balance 	decimal 	The overall balance in this wallet, after this transaction. 
        //reason 	string 	See Arguments, below. 

        public bool Ignore { get; set; }

        int IGenericObject.ObjectID { get; set; }
        IGenericObject IGenericObject.Parent { get; set; }

        public IEqualityComparer<WalletJournalRecord> GetComparer()
        {
            return new WalletJournalComparer();
        }
    }
}
