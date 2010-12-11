using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel.Composition;

namespace EveTrader.Core.Services
{
    [Export(typeof(IPriceSourceSelector))]
    public class PriceSourceSelector : IPriceSourceSelector
    {
        private IEnumerable<IPriceLookup> iLookupServices = new List<IPriceLookup>();

        [ImportMany(AllowRecomposition=true)]
        public IEnumerable<IPriceLookup> LookupServices
        {
            get
            {
                return iLookupServices;
            }
            set
            {
                iLookupServices = value;
            }
        }


        public decimal Current(long typeID, OrderType type, long regionID = 10000002)
        {
            return iLookupServices.First().Average(typeID, type, regionID);
        }
    }
}
