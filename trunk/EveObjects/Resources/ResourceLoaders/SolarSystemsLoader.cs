using System.Collections.Generic;
using System.Linq;

namespace EveObjects.Resources.ResourceLoaders
{
    internal static class SolarSystemsLoader
    {
        public static IList<SolarSystem> Load()
        {
            IList<SolarSystem> types = ResourceManager.SolarSystems.Descendants("SolarSystem")
                       .Select(item => new SolarSystem
                        {
                            Id = item.Element("Id").Value.ToDouble(),
                            Name = item.Element("Name").Value,
                            x = item.Element("x").Value.ToDouble(),
                            y = item.Element("y").Value.ToDouble(),
                            z = item.Element("z").Value.ToDouble(),
                            Radius = item.Element("Radius").Value.ToDouble(),
                            RegionId = item.Element("RegionId").Value.ToDouble(),
                            ConstellationId = item.Element("ConstellationId").Value.ToDouble(),
                            Security = item.Element("Security").Value.ToDouble(),
                            SecurityClass = item.Element("SecurityClass").Value
                        }).ToList();

            return types;
        }
    }
}
