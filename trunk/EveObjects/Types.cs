using System.Collections.Generic;
using System.Linq;
using EveObjects.Resources.ResourceLoaders;

namespace EveObjects
{
    public class Types : Singleton<Types>
    {
        private IList<Type> types = null;

        public IList<Type> List
        {
            get
            {
                return types;
            }
        }

        public Types()
        {
            types = TypesLoader.Load();
        }

        public Type GetTypeById(int id)
        {
            try
            {
                return types.First(item => item.Id == id);
            }
            catch
            {
                return new Type {Name = "Unknown"};
            }
        }

        /*public IList<Type> GetItemById(int id)
        {
            return items.First( item => item.Id == id);
        }*/
    }
}
