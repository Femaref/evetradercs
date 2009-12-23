using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EveObjects.Resources.ResourceLoaders
{
    internal static class TypesLoader
    {
        public static IList<Type> Load()
        {
            IList<Type> types = ResourceManager.Types.Descendants("Type")
                       .Select(item => new Type
                        {
                            Id = item.Element("Id").Value.ToDouble(),
                            Name = item.Element("Name").Value,
                            Description = item.Element("Description").Value
                        }).ToList();

            return types;
        }
    }
}