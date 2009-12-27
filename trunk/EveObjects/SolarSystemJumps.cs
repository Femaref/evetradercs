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
