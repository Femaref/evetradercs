using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EveObjects.Resources.ResourceLoaders;

namespace EveObjects
{
    public class RegionJumps : Jumps<RegionJumps, RegionJump>
    {
        public RegionJumps()
        {
            this.List = RegionJumpsLoader.Load();
        }
    }
}
