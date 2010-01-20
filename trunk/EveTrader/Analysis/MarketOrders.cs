using System;
using Core.DomainModel;

namespace EveTrader.Analysis
{
    public static class MarketOrders
    {
        public static double GetAverageTransactionsPerDay(Core.DomainModel.MarketOrder marketOrder)
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
            double avgTransactions = GetAverageTransactionsPerDay(marketOrder);
            double volume;

            //if the estimated time until this order completion is lower than the orders remaining time
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
        //estimated time before complete buyout -> estimated time until order completed
        public static double GetEtcb(Core.DomainModel.MarketOrder marketOrder)
        {
            /*return marketOrder.VolumeRemaining / ReportHelper.GetAverageTransactionsCount(
                walletTransactions,
                marketOrder.Type,
                marketOrder.TypeId,
                marketOrder.StationId,
                (DateTime.Now - marketOrder.Issued).Days);*/

            return marketOrder.VolumeRemaining / GetAverageTransactionsPerDay(marketOrder);
        }
    }
}