using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Core.Network.EveApi.Entities
{
    public interface  IAccountBalance
    {
        int ID { get; set; }
        int Key { get; set; }
        decimal Balance { get; set; }
        DateTime NextAccountBalanceUpdate { get; set; }
    }
}