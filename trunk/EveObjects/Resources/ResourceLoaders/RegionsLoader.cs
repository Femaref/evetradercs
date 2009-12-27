using System.Collections.Generic;
using System.Linq;

namespace EveObjects.Resources.ResourceLoaders
{
    internal static class RegionsLoader
    {
        public static IList<Region> Load()
        {
            IList<Region> types = ResourceManager.Regions.Descendants("Region")
                       .Select(item => new Region
                        {
                            Id = item.Element("Id").Value.ToDouble(),
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
