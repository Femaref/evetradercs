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
            return x.CorporationID == y.CorporationID;
        }

        public int GetHashCode(CorporationLogo obj)
        {
            return obj.CorporationID;
        }

        #endregion
    }
}
