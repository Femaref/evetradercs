using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EveObjects.Resources.ResourceLoaders;

namespace EveObjects
{
    public class ConstellationJumps : Jumps<ConstellationJumps, ConstellationJump>
    {
        public ConstellationJumps()
        {
            this.List = ConstellationJumpsLoader.Load();
        }
    }
}
