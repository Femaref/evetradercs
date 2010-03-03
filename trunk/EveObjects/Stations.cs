using System.Collections.Generic;
using System.Linq;
using EveObjects.Resources.ResourceLoaders;

namespace EveObjects
{
    public class Stations : Singleton<Stations>
    {
        private IList<Station> stations = null;

        public IList<Station> List
        {
            get
            {
                return stations;
            }
        }

        public Stations()
        {
            stations = StationsLoader.Load();
        }

        public Station GetStationById(int id)
        {
            var stat = stations.Where(station => station.Id == id);
            if (stat.Count() > 0)
                return stat.First();

            return new Station() { Name = "Unknown" };
        }
    }
}
