using System.Collections.Generic;
using System.Linq;
using EveObjects.Resources.ResourceLoaders;

namespace EveObjects
{
    public class Constellations : Singleton<Constellations>
    {
        private IList<Constellation> constellations = null;

        public IList<Constellation> List
        {
            get
            {
                return constellations;
            }
        }

        public Constellations()
        {
            this.constellations = ConstellationsLoader.Load();
        }

        public Constellation GetById(double id)
        {
            try
            {
                return constellations.First(item => item.Id == id);
            }
            catch
            {
                return new Constellation {Name = "Unknown"};
            }
        }

        public Constellation GetByName(string name)
        {
            try
            {
                return constellations.First(item => item.Name.ToLower() == name.ToLower());
            }
            catch
            {
                return new Constellation {Name = "Unknown"};
            }
        }

        public IList<Constellation> GetByNamePart(string name)
        {
            return constellations.Where( item => item.Name.ToLower().Contains(name.ToLower())).ToList();
        }
    }
}
