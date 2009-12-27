using System.Collections.Generic;
using System.Linq;

namespace EveObjects
{
    public abstract class Jumps<SingletonType, JumpType> : Singleton<SingletonType> where SingletonType : new() where JumpType : Jump, new()
    {
        private IList<JumpType> jumps = null;

        public IList<JumpType> List
        {
            get
            {
                return jumps;
            }
            protected set
            {
                jumps = value;
            }
        }

        public IList<JumpType> GetFromJumps(double id)
        {
            return jumps.Where( jump => jump.FromId == id).ToList();
        }
        public IList<JumpType> GetToJumps(double id)
        {
            return jumps.Where( jump => jump.ToId == id).ToList();
        }
    }
}
