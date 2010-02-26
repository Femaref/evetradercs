using System;
using System.Windows.Forms;
using Core;
using Core.ClassExtenders;
using Core.DomainModel;
using EveTrader.Analysis;

namespace EveTrader.Main.MarketOrders
{
    public class MarketOrderListViewItem : ListViewItem
    {
        public MarketOrder MarketOrder { get; set; }

        public static MarketOrderListViewItem Create(MarketOrder marketOrder, ListViewGroup group)
        {
            var item = new MarketOrderListViewItem
                           {
                               Text = marketOrder.OrderState.StringValue(),
                               Group = group,
                               MarketOrder = marketOrder
                           };

            item.SubItems.AddRange(
                new[]
                    {
                        Resources.Instance.EveObjects.Types.GetTypeById(marketOrder.TypeId).Name,
                        marketOrder.Price.FormatCurrency(),
                        PrepareQuantity(marketOrder),
                        marketOrder.Type == MarketOrderType.Buy
                            ? marketOrder.Escrow.FormatCurrency()
                            : (marketOrder.VolumeRemaining*marketOrder.Price).FormatCurrency(),
                        PrepareEtcb(marketOrder),
                        PrepareEstimatedSoldAmount(marketOrder),
                        Resources.Instance.EveObjects.Stations.GetStationById(marketOrder.StationId).Name,
                        string.Format(
                            "{0}d",
                            marketOrder.Duration - (DateTime.Now - marketOrder.Issued).Days)
                    });

            return item;
        }

        private static string PrepareEtcb(MarketOrder marketOrder)
        {
            double etcb = marketOrder.GetEtcb();

            if (double.IsInfinity(etcb))
            {
                return "−";
            }
            else
            {
                if (etcb < 1)
                {
                    return string.Format("{0}H", Math.Round(etcb*24));
                }
                else
                {
                    return string.Format("{0}d", Math.Round(etcb));
                }
            }
        }

        private static string PrepareQuantity(MarketOrder marketOrder)
        {
            return string.Format(
                "{0} / {1} /{2:  #} / {3:  #}",
                marketOrder.GetEstimatedSoldAmount() / marketOrder.Price,
                marketOrder.VolumeRemaining,
                marketOrder.VolumeEntered,
                marketOrder.VolumeMinimum);
        }

        private static string PrepareEstimatedSoldAmount(MarketOrder marketOrder)
        {
            double estimated = marketOrder.GetEstimatedSoldAmount();
            double etcb = marketOrder.GetEtcb();

            if (double.IsInfinity(estimated))
            {
                return "−";
            }
            else
            {
                double daysRemaining = marketOrder.Duration - (DateTime.Now - marketOrder.Issued).Days;

                if (double.IsInfinity(etcb))
                {
                    return "?";
                }
                else if (etcb < daysRemaining)
                {
                    return "Full";
                }
                else
                {
                    return estimated.FormatCurrency();
                }
            }
        }
    }
}