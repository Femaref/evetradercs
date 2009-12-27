using System.Collections.Generic;
using Core.DomainModel;

namespace EveTrader
{
    public class UserData
    {
        public List<CustomPrice> CustomPrice { get; set; }

        public UserData()
        {
            this.CustomPrice = new List<CustomPrice>();
        }
    }
}
