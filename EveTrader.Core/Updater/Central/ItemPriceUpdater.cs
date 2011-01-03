using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EveTrader.Core.Network.Requests.Central;
using EveTrader.Core.Model.Central;
using System.ComponentModel.Composition;

namespace EveTrader.Core.Updater.Central
{
    [Export]
    public class ItemPriceUpdater : CentralUpdaterBase
    {
        [ImportingConstructor]
        public ItemPriceUpdater([Import(RequiredCreationPolicy = CreationPolicy.Shared)] CentralModel cm)
            : base(cm)
        {
        }


        public override bool InnerUpdate(IEnumerable<long> typeIDs, IEnumerable<long> regionIDs, long minimumQuantity)
        {
            ItemPriceRequest ipr = new ItemPriceRequest(typeIDs, regionIDs, model.StillCached, model.SaveCache, model.LoadCache, "", 0);

            var response = ipr.Request();

            foreach (ItemPricesDto val in response)
            {
                var current = model.ItemPrices.FirstOrDefault(i => i.TypeID == val.TypeID && i.RegionID == val.RegionID);
                if (current == null)
                {
                    current = new ItemPrices() { TypeID = val.TypeID, RegionID = val.RegionID };
                    model.ItemPrices.AddObject(current);

                    model.SaveChanges();
                }

                AutoMapper.Mapper.Map<ItemPricesDto, ItemPrices>(val, current);

                model.ItemPrices.ApplyCurrentValues(current);
            }

            model.SaveChanges();

            return true;
        }
    }
}
