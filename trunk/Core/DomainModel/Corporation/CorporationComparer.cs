using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Core.DomainModel
{
    public class CorporationComparer : IEqualityComparer<Corporation>
    {
        #region Implementation of IEqualityComparer<Corporation>

        public bool Equals(Corporation x, Corporation y)
        {
            return x.ID == y.ID;
        }

        public int GetHashCode(Corporation obj)
        {
            return obj.ID;
        }

        #endregion
    }
}
