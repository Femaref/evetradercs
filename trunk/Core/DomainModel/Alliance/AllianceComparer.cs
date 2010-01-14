using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Core.DomainModel
{
    public class AllianceComparer : IEqualityComparer<Alliance>
    {
        #region Implementation of IEqualityComparer<Alliance>

        public bool Equals(Alliance x, Alliance y)
        {
            return x.ID == y.ID;
        }

        public int GetHashCode(Alliance obj)
        {
            return obj.ID;
        }

        #endregion
    }
}
