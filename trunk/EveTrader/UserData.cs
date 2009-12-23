using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;
using Core.DomainModel;
using EveTrader.Helpers;

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
