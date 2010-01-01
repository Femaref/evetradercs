using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Core.DomainModel
{
    public class WalletHistory : IGenericObject<WalletHistory>
    {
        public DateTime Key { get; set; }
        public double Value { get; set; }

        public IEqualityComparer<WalletHistory> GetComparer()
        {
            return new WalletHistoryComparer();
        }
    }
}
