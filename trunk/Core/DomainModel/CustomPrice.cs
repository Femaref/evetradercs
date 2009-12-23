using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Core.DomainModel
{
    public class CustomPrice
    {
        public int ProductId { get; set; }
        public int CharactedId { get; set; }
        public double? SellPrice  { get; set; }
        public double? BuyPrice  { get; set; }

        public CustomPrice()
        {
            this.SellPrice = null;
            this.BuyPrice = null;
        }
    }
}
