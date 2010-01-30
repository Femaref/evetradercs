using Core.DomainModel;

namespace Core.Network.EveApi
{
    public enum EveApiResourceType
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
        CorporationSheet
    }
}
