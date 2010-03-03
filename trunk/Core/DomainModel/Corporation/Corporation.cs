using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml;
using Core.Network;
using Core.Network.EveApi;
using Core.Network.EveApi.Entities;

namespace Core.DomainModel
{
    public class Corporation : IGenericObject<Corporation>, IEntity, IWallet, IMarketOrder, IStanding
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

        public Corporation()
        {
            this.Wallets = new List<Wallet>();
            this.Name = "";
            this.Ticker = "";
            this.CeoName = "";
            this.HeadquarterStationName = "";
            this.Description = "";
            this.Url = "";
            this.AllianceName = "";
        }

        public DateTime NextCorporationSheetUpdateTime { get; set; }

        public List<SerializableKeyValuePair<int, string>> Divisions { get; set; }
        public List<SerializableKeyValuePair<int, string>> WalletDivisions { get; set; }

        public CorporationLogo Logo { get; set; }

        int IGenericObject.ObjectID { get; set; }
        IGenericObject IGenericObject.Parent { get; set; }
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


        void IEntity.BeforeUpdate()
        {
            return;
        }
        void IEntity.AfterUpdate()
        {
            return;
        }

        void IWallet.BeforeUpdate()
        {
            return;
        }
        void IWallet.AfterUpdate()
        {
            foreach(Wallet w in this.Wallets)
            {
                var kvp = this.WalletDivisions.Where(wd => wd.Key == w.Key).SingleOrDefault();
                if(kvp.Value != null && kvp.Value != "")
                    w.Name = kvp.Value;
            }
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

        #region IStanding Members

        public List<Standing> Standings { get; set; }

        public DateTime NextStandingUpdateTime { get; set; }

        #endregion
    }
}
