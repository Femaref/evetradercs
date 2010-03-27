using System;
using System.Collections.Generic;

namespace Core.DomainModel
{
    public class MarketOrder : IGenericObject<MarketOrder>
    {
        public MarketOrderType Type { get; set;}
        public int ID { get; set;}
        public int EntityID { get; set;}
        public int StationID { get; set;}
        public int VolumeEntered { get; set;}
        public int VolumeRemaining { get; set;}
        public int VolumeMinimum { get; set;}
        public MarketOrderState OrderState { get; set;}
        public int TypeID { get; set;}
        public int Range { get; set;}
        public int AccountKey { get; set;}
        public int Duration { get; set;}
        public double Escrow { get; set;}
        public double Price { get; set;}
        public DateTime Issued { get; set;}
        
        public bool Ignore { get; set; }

        public int ObjectID { get; set; }
        public IGenericObject Parent { get; set; }

        public IEqualityComparer<MarketOrder> GetComparer()
        {
            return new MarketOrderComparer();
        }
    }
}
