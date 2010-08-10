using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EveTrader.Core.Model
{
    [Flags]
    public enum Tables
    {
        Transactions = 1,
        Journal = 2,
        ApplicationLog = 4,
        Entity = 8,
        MarketOrders = 16,
        WalletHistory = 32,
        Accounts = 64,
        Wallets = 128,
        CachedPriceInfo = 256
    }
}
