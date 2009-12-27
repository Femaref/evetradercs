using System.Collections.Generic;
using System.Linq;
using EveObjects.Resources.ResourceLoaders;

namespace EveObjects
{
    public class Regions : Singleton<Regions>
    {
        private IList<Region> regions = null;

        public IList<Region> List
        {
            get
            {
                return regions;
            }
        }

        public Regions()
        {
            this.regions = RegionsLoader.Load();
        }

        public Region GetById(double id)
        {
            try
            {
                return regions.First(item => item.Id == id);
            }
            catch
            {
                return new Region {Name = "Unknown"};
            }
        }

        public Region GetByName(string name)
        {
            try
            {
                return regions.First(item => item.Name.ToLower() == name.ToLower());
            }
            catch
            {
                return new Region {Name = "Unknown"};
            }
        }

        public IList<Region> GetByNamePart(string name)
        {
            return regions.Where( item => item.Name.ToLower().Contains(name.ToLower())).ToList();
        }
    }
}
