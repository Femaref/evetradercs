using System.Collections.Generic;
using System.Linq;

namespace EveObjects.Resources.ResourceLoaders
{
    internal static class ConstellationsLoader
    {
        public static IList<Constellation> Load()
        {
            IList<Constellation> types = ResourceManager.Constellations.Descendants("Constellation")
                       .Select(item => new Constellation
                        {
                            Id = item.Element("Id").Value.ToDouble(),
                            RegionId = item.Element("RegionId").Value.ToDouble(),
                            Name = item.Element("Name").Value,
                            x = item.Element("x").Value.ToDouble(),
                            y = item.Element("y").Value.ToDouble(),
                            z = item.Element("z").Value.ToDouble(),
                            Radius = item.Element("Radius").Value.ToDouble()
                        }).ToList();

            return types;
        }
    }
}
