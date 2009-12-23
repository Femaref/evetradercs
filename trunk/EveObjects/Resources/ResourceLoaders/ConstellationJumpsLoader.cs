using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EveObjects.Resources.ResourceLoaders
{
    internal static class ConstellationJumpsLoader
    {
        public static IList<ConstellationJump> Load()
        {
            IList<ConstellationJump> jumps = ResourceManager.ConstellationJumps.Descendants("ConstellationJump")
                       .Select(item => new ConstellationJump
                        {
                            FromId = item.Element("FromId").Value.ToDouble(),
                            ToId = item.Element("ToId").Value.ToDouble()
                        }).ToList();

            return jumps;
        }
    }
}
