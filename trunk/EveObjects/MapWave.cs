using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EveObjects
{
    public class MapWave
    {
        public Dictionary<double, int> Wave;
        public int Rank;
        public double FromSolarSystemId;
        public double ToSolarSystemId;

        public MapWave()
        {
            this.Wave = new Dictionary<double, int>();
            this.ToSolarSystemId = -1;
        }
    }
}
