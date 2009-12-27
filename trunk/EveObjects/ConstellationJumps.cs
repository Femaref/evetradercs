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
