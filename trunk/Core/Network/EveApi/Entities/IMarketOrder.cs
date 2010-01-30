using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Core.DomainModel;

namespace Core.Updaters
{
    public interface IMarketOrder : IEntity
    {
        List<MarketOrder> MarketOrders { get; set; }
        DateTime NextMarketOrdersUpdateTime { get; set; }
    }
}
