namespace Core.Network.EveCentral
{
    public abstract class EveCentralResourceRequest : ResourceRequest
    {
        protected override ResourceRequestMethod Method
        {
            get
            {
                return ResourceRequestMethod.Get;
            }
        }
    }
}
