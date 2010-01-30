using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Core.DomainModel
{
    public class WalletComparer : IEqualityComparer<Wallet>
    {
        #region Implementation of IEqualityComparer<Wallet>

        public bool Equals(Wallet x, Wallet y)
        {
            return x.ID == y.ID && x.Key == y.Key;
        }

        public int GetHashCode(Wallet obj)
        {
            return obj.GetHashCode();
        }

        #endregion
    }
}
