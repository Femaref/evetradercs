using System.Collections.Generic;
using System.Linq;
using EveObjects.Resources.ResourceLoaders;

namespace EveObjects
{
    public class SolarSystems : Singleton<SolarSystems>
    {
        private IList<SolarSystem> solarSystems = null;

        public IList<SolarSystem> List
        {
            get
            {
                return solarSystems;
            }
        }

        public SolarSystems()
        {
            this.solarSystems = SolarSystemsLoader.Load();
        }

        public SolarSystem GetSolarSystemById(double id)
        {
            var systems = solarSystems.Where(item => item.Id == id);
            if (systems.Count() > 0)
                return systems.First();

            return new SolarSystem() {Name = "Unknown"};

        }

        public SolarSystem GetSolarSystemByName(string name)
        {
            try
            {
                return solarSystems.First(item => item.Name.ToLower() == name.ToLower());
            }
            catch
            {
                return new SolarSystem {Name = "Unknown"};
            }
        }

        public IList<SolarSystem> GetSolarSystemsByNamePart(string name)
        {
            return solarSystems.Where( item => item.Name.ToLower().Contains(name.ToLower())).ToList();
        }
    }
}
