using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EveObjects.Resources.ResourceLoaders;

namespace EveObjects
{
    public class SolarSystemJumps : Jumps<SolarSystemJumps, SolarSystemJump>
    {
        public SolarSystemJumps()
        {
            this.List = SolarSystemJumpsLoader.Load();
        }
    }
}
