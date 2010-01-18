using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Core.Network;

namespace Core.DomainModel
{
    public interface IAccount
    {
        Account ApiData { get; set; }
    }
}
