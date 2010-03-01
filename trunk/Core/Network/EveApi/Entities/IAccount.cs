using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Core.Network.EveApi.Entities
{
    public interface IAccount
    {
        Account ApiData { get; set; }
        EveApiResourceFrom RequestFrom { get;}
    }
}