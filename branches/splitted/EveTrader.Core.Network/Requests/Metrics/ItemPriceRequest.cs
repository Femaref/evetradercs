using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EveTrader.Core.Model.Metric;
using ClassExtenders;
using System.Xml.Linq;

namespace EveTrader.Core.Network.Requests.Metrics
{
    public class ItemPriceRequest : MetricsRequestBase<IEnumerable<ItemPricesDto>>
    {
        public IEnumerable<long> ItemIDs { get; private set; }
        public IEnumerable<long> RegionIDs { get; private set; }
        public long MinimumQuantity { get; private set; }

        public ItemPriceRequest(
            IEnumerable<long> itemIDs,
            Func<string, TimeSpan, bool> stillCached,
            Action<string, DateTime, string> saveCache,
            Func<string, string> loadCache,
            string developerKey = "",
            long minQuantity = 0
            )
            : this(itemIDs,
                Enumerable.Empty<long>(),
                stillCached,
                saveCache,
                loadCache,
                developerKey,
                minQuantity)
        {
        }
        public ItemPriceRequest(
            IEnumerable<long> itemIDs,
            IEnumerable<long> regionIDs,
            Func<string, TimeSpan, bool> stillCached,
            Action<string, DateTime, string> saveCache,
            Func<string, string> loadCache,
            string developerKey = "",
            long minQuantity = 0
            )
            : base(
            (new MetricsRequestConstructor(MetricsPage.ItemPrice, developerKey))
                .AddData("type_ids", itemIDs.Aggregate("", (s, l) => s + l + ",")) //aggregates itemIDs to a comma delimited string
                .AddData("min_quantity", minQuantity.ToString()),
            stillCached,
            saveCache,
            loadCache)
        {
            this.ItemIDs = itemIDs;
            this.RegionIDs = regionIDs;
        }


        protected override IEnumerable<ItemPricesDto> Parse(System.Xml.Linq.XDocument document)
        {
            List<ItemPricesDto> output = new List<ItemPricesDto>();

            foreach(XElement x in document.Element("evemetrics").Elements("type"))
            {
                foreach (XElement sub in x.Elements())
                {
                    ItemPricesDto ipd = new ItemPricesDto() 
                    { 
                        TypeID = x.Attribute("id").Value.ToInt64(),
                        LastUpload = sub.Element("last_upload").Value.ToDateTime(),
                        RegionID = x.Name == "global" ? 0 : x.Attribute("id").Value.ToInt64(),
                        MinimumBuy = sub.Element("buy").Element("minimum").Value.ToDecimal(),
                        MinimumSell = sub.Element("sell").Element("minimum").Value.ToDecimal(),
                        MaximumBuy = sub.Element("buy").Element("maximum").Value.ToDecimal(),
                        MaximumSell = sub.Element("sell").Element("maximum").Value.ToDecimal(),
                        MedianBuy = sub.Element("buy").Element("median").Value.ToDecimal(),
                        MedianSell = sub.Element("sell").Element("median").Value.ToDecimal(),
                        AverageBuy = sub.Element("buy").Element("average").Value.ToDecimal(),
                        AverageSell = sub.Element("sell").Element("average").Value.ToDecimal(),
                        KurtosisBuy = sub.Element("buy").Element("kurtosis").Value.ToDecimal(),
                        KurtosisSell = sub.Element("sell").Element("kurtosis").Value.ToDecimal(),
                        SkewBuy = sub.Element("buy").Element("skew").Value.ToDecimal(),
                        SkewSell = sub.Element("sell").Element("skew").Value.ToDecimal(),
                        VarianceBuy = sub.Element("buy").Element("variance").Value.ToDecimal(),
                        VarianceSell = sub.Element("sell").Element("variance").Value.ToDecimal(),
                        StandardDeviationBuy = sub.Element("buy").Element("standard_deviation").Value.ToDecimal(),
                        StandardDeviationSell = sub.Element("sell").Element("standard_deviation").Value.ToDecimal(),
                        SimulatedBuy = sub.Element("buy").Element("simulated").Value.ToDecimal(),
                        SimulatedSell = sub.Element("sell").Element("simulated").Value.ToDecimal()
                    };

                    output.Add(ipd);
                }
            }
            return output;
        }

        public override TimeSpan CachingTime
        {
            get { return new TimeSpan(0, 15, 0); }
        }
    }
}
