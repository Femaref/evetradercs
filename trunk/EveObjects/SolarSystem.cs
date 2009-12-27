using System.Collections.Generic;
using System.Linq;

namespace EveObjects
{
    public class SolarSystem : MapObject
    {
        public double RegionId { get; set; }
        public double ConstellationId { get; set; }
        public double Security { get; set; }
        public string SecurityClass { get; set; }
        public IList<SolarSystem> Jumps
        {
            get
            {
                return EveObjects.SolarSystemJumps.Instance.GetFromJumps(this.Id).Select( jump => SolarSystems.Instance.GetSolarSystemById(jump.ToId)).ToList();
            }
        }
    }
}
