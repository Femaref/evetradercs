using System;
using System.Collections.Generic;
using System.Xml;

namespace Core.DomainModel
{
    public class Corporation : IGenericObject<Corporation>, IAccount
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Ticker { get; set; }
        public int CeoID { get; set; }
        public string CeoName { get; set; }
        public int HeadquarterStationID { get; set; }
        public string HeadquarterStationName { get; set; }
        public string Description { get; set; }
        public string Url { get; set; }
        public int AllianceID { get; set; }
        public string AllianceName { get; set; }
        public double TaxRate { get; set; }
        public int MemberCount { get; set; }
        public int MemberLimit { get; set; }
        public int Shares { get; set; }

        public List<KeyValuePair<int, string>> Divisions { get; set; }
        public List<KeyValuePair<int, string>> WalletDivisions { get; set; }

        public CorporationLogo Logo { get; set; }

        public List<AccountBalance> Wallets { get; set; }

        public DateTime NextAccountBalanceUpdate { get; set; }
        public DateTime NextAssetsUpdateTime { get; set; }


        public IEqualityComparer<Corporation> GetComparer()
        {
            return new CorporationComparer();
        }

        #region IAccount Members

        public Core.Network.Account ApiData { get; set; }

        #endregion
    }
}
