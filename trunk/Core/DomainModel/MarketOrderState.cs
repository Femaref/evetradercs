using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Core.DomainModel
{
    public enum MarketOrderState
    {
        /// <summary>
        /// If the market order is still active and up on the market
        /// </summary>
        [EnumStringValue("Active")] 
        OpenActive = 0,

        /// <summary>
        /// The order has been closed
        /// </summary>
        [EnumStringValue("Closed")] 
        Closed = 1,

        /// <summary>
        /// The order has expired, or has been fufilled so it is no longer active
        /// </summary>
        [EnumStringValue("Expired")] 
        ExpiredFulfilled = 2,

        /// <summary>
        /// The order was canceled
        /// </summary>
        [EnumStringValue("Canceled")] 
        Canceled = 3,

        /// <summary>
        /// The order is currently pending, and not on the market
        /// </summary>
        [EnumStringValue("Pending")] 
        Pending = 4,

        /// <summary>
        /// The character that this order was associated with has been deleted
        /// </summary>
        [EnumStringValue("Character Deleted")] 
        CharacterDeleted = 5
    }
}
