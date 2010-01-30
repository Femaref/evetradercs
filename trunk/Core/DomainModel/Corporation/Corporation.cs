using System;
using System.Collections.Generic;
using System.Xml;
using Core.Network;
using Core.Network.EveApi;
using Core.Updaters;

namespace Core.DomainModel
{
    public class Corporation : IGenericObject<Corporation>, IEntity, IWallet, IMarketOrder
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

        public DateTime NextCorporationSheetUpdateTime { get; set; }

        public List<SerializableKeyValuePair<int, string>> Divisions { get; set; }
        public List<SerializableKeyValuePair<int, string>> WalletDivisions { get; set; }

        public CorporationLogo Logo { get; set; }

        public IEqualityComparer<Corporation> GetComparer()
        {
            return new CorporationComparer();
        }

        #region IAccount Members

        public Account ApiData { get; set; }
        public EveApiResourceFrom RequestFrom { get { return EveApiResourceFrom.Corporation; } }

        #endregion

        #region Implementation of IWallet

        public List<Wallet> Wallets
        {
            get; set;
        }

        #endregion

        #region Implementation of IEntity

        public DateTime NextUpdateTime
        {
            get { throw new NotImplementedException(); }
        }

        public void BeforeUpdate()
        {
            throw new NotImplementedException();
        }

        public void AfterUpdate()
        {
            throw new NotImplementedException();
        }

        #endregion

        #region Implementation of IMarketOrder

        public List<MarketOrder> MarketOrders
        {
            get; set;
        }

        public DateTime NextMarketOrdersUpdateTime
        {
            get; set;
        }

        #endregion
    }
}
