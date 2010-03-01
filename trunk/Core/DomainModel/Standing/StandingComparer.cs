using System.Collections.Generic;

namespace Core.DomainModel
{
    public class StandingComparer : IEqualityComparer<Standing>
    {
        public bool Equals(Standing x, Standing y)
        {
            return (x.EntityID == y.EntityID) && (x.Target == y.Target) && (x.TargetID == y.TargetID) &&
                   (x.Type == y.Type) && (x.Value == y.Value);

        }

        public int GetHashCode(Standing obj)
        {
            return (obj.EntityID + obj.TargetID)*((int) obj.Target)*((int) obj.Type);
        }
    }
}
