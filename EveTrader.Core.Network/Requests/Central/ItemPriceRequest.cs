using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EveTrader.Core.Model.Central;
using System.Xml.Linq;
using ClassExtenders;

namespace EveTrader.Core.Network.Requests.Central
{
    public class ItemPriceRequest : CentralRequestBase<IEnumerable<ItemPricesDto>>
    {

        public ItemPriceRequest            (IEnumerable<long> itemIDs,
            IEnumerable<long> regionIDs,
            Func<string, TimeSpan, bool> stillCached,
            Action<string, DateTime, string> saveCache,
            Func<string, string> loadCache,
            string developerKey = "",
            long minQuantity = 0)
            : base(
            (new CentralRequestConstructor(CentralRequestPage.ItemPrice))
            .AddData(itemIDs.Select(i => Tuple.Create("typeid", i.ToString())))
            .AddData(regionIDs.Select(i => Tuple.Create("regionlimit", i.ToString())))
            .AddData("minQ", minQuantity.ToString()), stillCached, saveCache, loadCache)
        {
        }

        protected override IEnumerable<ItemPricesDto> Parse(System.Xml.Linq.XDocument document)
        {
            List<ItemPricesDto> output = new List<ItemPricesDto>();

            foreach (XElement x in document.Element("evec_api").Element("marketstat").Elements("type"))
            {
                ItemPricesDto ipd = new ItemPricesDto()
                {
                    TypeID = x.Attribute("id").Value.ToInt64(),
                    RegionID = 0,
                    VolumeBuy = x.Element("buy").Element("volume").Value.ToInt64(),
                    AverageBuy = x.Element("buy").Element("avg").Value.ToDecimal(),
                    MaximumBuy = x.Element("buy").Element("max").Value.ToDecimal(),
                    MinimumBuy = x.Element("buy").Element("min").Value.ToDecimal(),
                    StandardDeviationBuy = x.Element("buy").Element("stddev").Value.ToDecimal(),
                    MedianBuy = x.Element("buy").Element("median").Value.ToDecimal(),
                    VolumeSell = x.Element("sell").Element("volume").Value.ToInt64(),
                    AverageSell = x.Element("sell").Element("avg").Value.ToDecimal(),
                    MaximumSell = x.Element("sell").Element("max").Value.ToDecimal(),
                    MinimumSell = x.Element("sell").Element("min").Value.ToDecimal(),
                    StandardDeviationSell = x.Element("sell").Element("stddev").Value.ToDecimal(),
                    MedianSell = x.Element("sell").Element("median").Value.ToDecimal()
                };
                output.Add(ipd);
            }

            return output;
        }

        public override TimeSpan CachingTime
        {
            get { return new TimeSpan(1, 0, 0); }
        }
    }
}
