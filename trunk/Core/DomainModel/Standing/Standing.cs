using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Core.DomainModel
{
    public class Standing
    {
        public int CharacterID { get; set; }
        public StandingTarget Target { get; set; }
        public StandingType Type { get; set; }
        public int TargetID { get; set; }
        public double Value { get; set; }
    }
}
