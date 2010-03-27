using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Core.DomainModel
{
    public class CorporationLogo : IGenericObject<CorporationLogo>
    {
        public int CorporationID { get; set; }
        public int Shape1 { get; set; }
        public int Shape2 { get; set; }
        public int Shape3 { get; set; }
        public int Color1 { get; set; }
        public int Color2 { get; set; }
        public int Color3 { get; set; }

        #region Implementation of IGenericObject<CorporationLogo>

        public int ObjectID { get; set; }
        public IGenericObject Parent { get; set; }

        public IEqualityComparer<CorporationLogo> GetComparer()
        {
            return new CorporationLogoComparer();
        }

        #endregion
    }
}
