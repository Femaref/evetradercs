using Core.DomainModel;

namespace Core.Network
{
    public enum ResourceRequestMethod
    {
        [EnumStringValue("GET")] 
        Get,
        [EnumStringValue("POST")] 
        Post
    }
}
