using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Linq;

namespace EveObjects.Resources.ResourceLoaders
{
    internal static class StationsLoader
    {
        public static IList<Station> Load()
        {
            IList<Station> stations = ResourceManager.Stations.Descendants("Station")
                       .Select(item => new Station
                        {
                            Id = item.Element("Id").Value.ToDouble(),
                            Name = item.Element("Name").Value
                        }).ToList();

            return stations;
        }
    }
}