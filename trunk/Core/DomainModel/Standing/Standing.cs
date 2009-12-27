using System.Collections.Generic;

namespace Core.DomainModel
{
    public class Standing : IGenericObject<Standing>
    {
        public int CharacterID { get; set; }
        public StandingTarget Target { get; set; }
        public StandingType Type { get; set; }
        public int TargetID { get; set; }
        public double Value { get; set; }

        #region IGenericObject<Standing> Members

        public IEqualityComparer<Standing> GetComparer()
        {
            return new StandingComparer();
        }

        #endregion
    }
}
