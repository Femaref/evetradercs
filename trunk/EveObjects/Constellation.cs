using System.Collections.Generic;
using System.Linq;

namespace EveObjects
{
    public class Constellation : MapObject
    {
        public double RegionId { get; set; }

        public IList<SolarSystem> SolarSystems
        {
            get
            {
                return EveObjects.SolarSystems.Instance.List.Where ( solarSystem => solarSystem.ConstellationId == this.Id ).ToList();
            }
        }
    }
}
