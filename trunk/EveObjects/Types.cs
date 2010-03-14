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
            var type = types.Where(item => item.Id == id);
            if (type.Count() > 0)
                return type.First();

            return new Type() { Name = "Unknown" };
        }
    }
}
