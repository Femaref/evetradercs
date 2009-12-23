using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Core.DomainModel;
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
