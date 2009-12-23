using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EveObjects.Resources.ResourceLoaders
{
    internal static class RegionJumpsLoader
    {
        public static IList<RegionJump> Load()
        {
            IList<RegionJump> jumps = ResourceManager.RegionJumps.Descendants("RegionJump")
                       .Select(item => new RegionJump
                        {
                            FromId = item.Element("FromId").Value.ToDouble(),
                            ToId = item.Element("ToId").Value.ToDouble()
                        }).ToList();

            return jumps;
        }
    }
}
