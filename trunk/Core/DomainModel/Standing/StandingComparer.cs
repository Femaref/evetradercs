using System.Collections.Generic;

namespace Core.DomainModel
{
    public class StandingComparer : IEqualityComparer<Standing>
    {
        public bool Equals(Standing x, Standing y)
        {
            return (x.CharacterID == y.CharacterID) && (x.Target == y.Target) && (x.TargetID == y.TargetID) &&
                   (x.Type == y.Type) && (x.Value == y.Value);

        }

        public int GetHashCode(Standing obj)
        {
            return (obj.CharacterID + obj.TargetID)*((int) obj.Target)*((int) obj.Type);
        }
    }
}
