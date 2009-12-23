using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Core.DomainModel;

namespace EveTrader.Analysis
{
    public static class MarketOrders
    {
        public static double GetAverageTransactionsPeerDay(Core.DomainModel.MarketOrder marketOrder)
        {
            double delta = marketOrder.VolumeEntered - marketOrder.VolumeRemaining;
            double daysPast = (DateTime.Now - marketOrder.Issued).Days;

            if (marketOrder.OrderState == MarketOrderState.Canceled)
            {
                delta = 0;
            }

            return delta / daysPast;
        }

        public static double GetEstimatedSoldAmount(Core.DomainModel.MarketOrder marketOrder)
        {
            double etcb = GetEtcb(marketOrder);
            double daysRemaining = marketOrder.Duration - (DateTime.Now - marketOrder.Issued).Days;
            double avgTransactions = GetAverageTransactionsPeerDay(marketOrder);
            double volume;

            if (etcb <= daysRemaining)
            {
                volume = marketOrder.VolumeRemaining;
            }
            else
            {
                volume = Math.Round(daysRemaining * avgTransactions);
            }

            return volume * marketOrder.Price;
        }
        public static double GetEtcb(Core.DomainModel.MarketOrder marketOrder)
        {
            /*return marketOrder.VolumeRemaining / ReportHelper.GetAverageTransactionsCount(
                walletTransactions,
                marketOrder.Type,
                marketOrder.TypeId,
                marketOrder.StationId,
                (DateTime.Now - marketOrder.Issued).Days);*/

            return marketOrder.VolumeRemaining / GetAverageTransactionsPeerDay(marketOrder);
        }
    }
}