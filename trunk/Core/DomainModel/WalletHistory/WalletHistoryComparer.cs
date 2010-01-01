using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Core.DomainModel
{
   public class WalletHistoryComparer : IEqualityComparer<WalletHistory>
    {
        #region IEqualityComparer<WalletHistory> Members

        public bool Equals(WalletHistory x, WalletHistory y)
        {
            return (x.Key == y.Key) && (x.Value == y.Value);
        }

        public int GetHashCode(WalletHistory obj)
        {
            return obj.Key.GetHashCode();
        }

        #endregion
    }
}
