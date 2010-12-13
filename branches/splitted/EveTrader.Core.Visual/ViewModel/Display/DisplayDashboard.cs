using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.ComponentModel;

namespace EveTrader.Core.Visual.ViewModel.Display
{
    [DebuggerDisplay("Key: {Key}, Profit: {Profit}, Investment: {Investment}, Sales Count:{Sales.Count}")]
    public class DisplayDashboard : INotifyPropertyChanged
    {
        private DateTime iKey;

        public DateTime Key
        {
            get { return iKey; }
            set
            {
                iKey = value;
                RaisePropertyChanged("Key");
            }
        }

        private decimal iProfit;

        public decimal Profit
        {
            get { return iProfit; }
            set
            {
                iProfit = value;
                RaisePropertyChanged("Profit");
            }
        }

        private decimal iInvestment;

        public decimal Investment
        {
            get { return iInvestment; }
            set
            {
                iInvestment = value;

                RaisePropertyChanged("Investment");
            }
        }

        private Dictionary<string, decimal> iSales = new Dictionary<string, decimal>();

        public Dictionary<string, decimal> Sales
        {
            get { return iSales; }
            set
            {
                iSales = value;
                RaisePropertyChanged("Sales");
            }
        }



        public DisplayDashboard()
        {
        }

        public event PropertyChangedEventHandler PropertyChanged;


        private void RaisePropertyChanged(string p)
        {
            var handler = PropertyChanged;
            if (handler != null)
                handler(this, new PropertyChangedEventArgs(p));
        }
    }
}
