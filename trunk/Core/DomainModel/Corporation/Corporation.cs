using System;
using System.Collections.Generic;

namespace Core.DomainModel
{
    public class Corporation: IGenericObject<Corporation>
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

        public Dictionary<int, string> Divisions { get; set; }
        public Dictionary<int, string> WalletDivisions { get; set; }

        public CorporationLogo Logo { get; set; }


        public IEqualityComparer<Corporation> GetComparer()
        {
            return new CorporationComparer();
        }
    }
}
