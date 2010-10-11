using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EveTrader.Core.Model.Trader
{
    public partial class MarketOrders
    {
        public decimal AverageTransactionsPerDay
        {
            get
            {
                decimal delta =  this.VolumeEntered - this.VolumeRemaining;
                decimal daysPast = (DateTime.Now - this.Issued).Days;

                if ((MarketOrderState)this.OrderState == MarketOrderState.Canceled)
                {
                    delta = 0;
                }
                return delta / daysPast;
            }
        }

        public decimal EstimatedSoldAmount
        {
            get
            {
                decimal etcb = this.Etcb;
                decimal daysRemaining = this.Duration - (DateTime.Now - this.Issued).Days;
                decimal avgTransactions = this.AverageTransactionsPerDay;
                decimal volume;

                //if the estimated time until this order completion is lower than the orders remaining time
                if (etcb <= daysRemaining)
                {
                    volume = this.VolumeRemaining;
                }
                else
                {
                    volume = Math.Round(daysRemaining * avgTransactions);
                }

                return volume * this.Price;
            }
        }
        //estimated time before complete buyout -> estimated time until order completed
        public decimal Etcb
        {
            get
            {
                return this.VolumeRemaining / this.AverageTransactionsPerDay;
            }
        }
    }
}
