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
