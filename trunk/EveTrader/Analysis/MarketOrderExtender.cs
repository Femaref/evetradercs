using System;
using Core.DomainModel;

namespace EveTrader.Analysis
{
    public static class MarketOrderExtender
    {
        public static double GetAverageTransactionsPerDay(this MarketOrder marketOrder)
        {
            double delta = marketOrder.VolumeEntered - marketOrder.VolumeRemaining;
            double daysPast = (DateTime.Now - marketOrder.Issued).Days;

            if (marketOrder.OrderState == MarketOrderState.Canceled)
            {
                delta = 0;
            }

            return delta / daysPast;
        }

        public static double GetEstimatedSoldAmount(this MarketOrder marketOrder)
        {
            double etcb = marketOrder.GetEtcb();
            double daysRemaining = marketOrder.Duration - (DateTime.Now - marketOrder.Issued).Days;
            double avgTransactions = marketOrder.GetAverageTransactionsPerDay();
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
        public static double GetEtcb(this MarketOrder marketOrder)
        {
            /*return marketOrder.VolumeRemaining / ReportHelper.GetAverageTransactionsCount(
                walletTransactions,
                marketOrder.Type,
                marketOrder.TypeId,
                marketOrder.StationId,
                (DateTime.Now - marketOrder.Issued).Days);*/

            return marketOrder.VolumeRemaining / marketOrder.GetAverageTransactionsPerDay();
        }
    }
}