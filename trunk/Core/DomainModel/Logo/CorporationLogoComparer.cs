using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Core.DomainModel
{
    public class CorporationLogoComparer : IEqualityComparer<CorporationLogo>
    {
        #region Implementation of IEqualityComparer<CorporationLogo>

        public bool Equals(CorporationLogo x, CorporationLogo y)
        {
            return x.ID == y.ID;
        }

        public int GetHashCode(CorporationLogo obj)
        {
            return obj.ID;
        }

        #endregion
    }
}
