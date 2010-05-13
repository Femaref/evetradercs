using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EveTrader.Core.Net.Requests.CCP
{
    public enum ApiRequestPage
    {
        AccountBalance,
        AssetList,
       // [EnumStringValue("characters")]
        CharactersList,
        CharacterSheet,
        JournalEntries,
        MarketOrders,
        StarbaseList,
        StarbaseDetail,
        WalletJournal,
        IndustryJobs,
        WalletTransactions,
        Standings,
        CorporationSheet
    }
}
