using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Core.DomainModel;

namespace Core.DomainModel
{
    public class WalletJournalRecord : IGenericObject<WalletJournalRecord>
    {
        public DateTime Date { get; set; }
        public int ReferenceId  { get; set; }
        public int ReferenceTypeId  { get; set; }
        public double Amount  { get; set; }
        public double Balance  { get; set; }
        /*
         * unset:
        ownerName1="corpslave"
        ownerID1="150337897" 
        ownerName2="Secure Commerce Commission" 
        ownerID2="1000132"
       argName1="" 
        argID1="0" 
        reason=""
         * */

        public bool Ignore { get; set; }

        public IEqualityComparer<WalletJournalRecord> GetComparer()
        {
            return new WalletJournalComparer();
        }
    }
}
