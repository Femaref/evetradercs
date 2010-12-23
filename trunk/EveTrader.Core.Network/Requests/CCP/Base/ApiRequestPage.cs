using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ClassExtenders;

namespace EveTrader.Core.Network.Requests.CCP
{
    public enum ApiRequestPage
    {
        AccountBalance,
        AssetList,
        [EnumStringValue("characters")]
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
        CorporationSheet,
        AllianceList,
        SkillTree,
        RefTypes
    }
}
