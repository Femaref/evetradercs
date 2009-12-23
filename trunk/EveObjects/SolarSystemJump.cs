using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EveObjects
{
    public class SolarSystemJump : Jump
    {
        public double FromRegionId { get; set; }
        public double FromConstellationId { get; set; }
        
        public double ToConstellationId { get; set; }
        public double ToRegionId { get; set; }

        public bool IsCrossConstellationJump
        {
            get
            {
                return this.FromConstellationId != this.ToConstellationId;
            }
        }
        public bool IsCrossRegionalJump
        {
            get
            {
                return this.FromRegionId != this.ToRegionId;
            }
        }
    }
}
