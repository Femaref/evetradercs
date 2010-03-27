using Core.DomainModel;

namespace Core.Network.EveApi
{
    public enum EveApiResourceFrom
    {
        [EnumStringValue("char")] 
        Character,
        [EnumStringValue("corp")] 
        Corporation,
        [EnumStringValue("account")] 
        Account
    }
}
