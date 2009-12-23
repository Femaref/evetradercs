using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Core.DomainModel
{
    /// <summary>
    /// What type of order was it on the market, buy or sell
    /// </summary>
    public enum MarketOrderType
    {
        /// <summary>
        /// Denotes a buy order
        /// </summary>
        Buy,

        /// <summary>
        /// Denotes a sell order
        /// </summary>
        Sell
    }
}
