using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EveTrader.Core.Model;
using System.Diagnostics;

namespace EveTrader.Core.ViewModel.Display
{
    [DebuggerDisplay("ID: {ID}, TypeID: {TypeID}")]
    public class DisplayMarketOrders
    {
        public string StationName { get; set; }
        public string TypeName { get; set; }
        public long VolumeEntered { get; set; }
        public long VolumeRemaining { get; set; }
        public long MinimumVolume { get; set; }
        public MarketOrderState OrderState { get; set; }
        public long TypeID { get; set; }
        public long StationID { get; set; }
        public long Range { get; set; }
        public long Duration { get; set; }
        public decimal Escrow { get; set; }
        public string EntityName { get; set; }
        public DateTime Issued { get; set; }
        public DateTime IssuedDate { get; set; }
        public decimal Price { get; set; }
        public bool Bid { get; set; }

        public static implicit operator DisplayMarketOrders(MarketOrders input)
        {
            return new DisplayMarketOrders()
            {
                VolumeEntered = input.VolumeEntered,
                VolumeRemaining = input.VolumeRemaining,
                MinimumVolume = input.MinimumVolume,
                OrderState = (MarketOrderState)input.OrderState,
                TypeID = input.TypeID,
                StationID = input.StationID,
                Range = input.Range,
                Duration = input.Duration,
                Escrow = input.Escrow,
                EntityName = input.Entity.Name,
                Issued = input.Issued,
                IssuedDate = input.IssuedDate,
                Price = input.Price,
                Bid = input.Bid
            };
        }
    }
}
