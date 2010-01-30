using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Core.Network;
using Core.Network.EveApi;

namespace Core.DomainModel
{
    public interface IAccount
    {
        Account ApiData { get; set; }
        EveApiResourceFrom RequestFrom { get;}
    }
}
