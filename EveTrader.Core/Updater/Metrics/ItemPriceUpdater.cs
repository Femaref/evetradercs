using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EveTrader.Core.Network.Requests.Metrics;
using System.ComponentModel.Composition;
using EveTrader.Core.Model.Metric;

namespace EveTrader.Core.Updater.Metrics
{
    [Export]
    public class ItemPriceUpdater : MetricUpdaterBase
    {
        [ImportingConstructor]
        public ItemPriceUpdater ([Import(RequiredCreationPolicy= CreationPolicy.Shared)] MetricModel mm) : base(mm)
        {
        }


        protected override bool InnerUpdate(
            IEnumerable<long> typeIDs, 
            IEnumerable<long> regionsIDs, 
            long mininumQuantity = 0, 
            string developerKey = "")
        {
            ItemPriceRequest ipr = new ItemPriceRequest(typeIDs, regionsIDs, iModel.StillCached, iModel.SaveCache, iModel.LoadCache, "", 0);

            var response = ipr.Request();

            foreach (ItemPricesDto val in response)
            {
                var current = iModel.ItemPrices.FirstOrDefault(i => i.TypeID == val.TypeID && i.RegionID == val.RegionID);
                if (current == null)
                {
                    current = new ItemPrices() { TypeID = val.TypeID, RegionID = val.RegionID };
                    iModel.ItemPrices.AddObject(current);

                    iModel.SaveChanges();
                }

                AutoMapper.Mapper.Map<ItemPricesDto, ItemPrices>(val, current);

                iModel.ItemPrices.ApplyCurrentValues(current);
            }

            iModel.SaveChanges();

            return true;
        }
    }
}
