using System.Collections.Generic;
using System.Linq;

namespace EveObjects.Resources.ResourceLoaders
{
    internal static class SolarSystemJumpsLoader
    {
        public static IList<SolarSystemJump> Load()
        {
            IList<SolarSystemJump> jumps = ResourceManager.SolarSystemJumps.Descendants("SolarSystemJump")
                       .Select(item => new SolarSystemJump
                        {
                            FromRegionId = item.Element("FromRegionId").Value.ToDouble(),
                            FromConstellationId = item.Element("FromConstellationId").Value.ToDouble(),
                            FromId = item.Element("FromId").Value.ToDouble(),
                            ToId = item.Element("ToId").Value.ToDouble(),
                            ToConstellationId = item.Element("ToConstellationId").Value.ToDouble(),
                            ToRegionId = item.Element("ToRegionId").Value.ToDouble()
                        }).ToList();

            return jumps;
        }
    }
}