using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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
            try
            {
                return stations.First(station => station.Id == id);
            }
            catch
            {
                return new Station {Name = "Unknown"};
            }
        }
    }
}
