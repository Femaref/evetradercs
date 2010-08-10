using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EveTrader.Core.Model;
using EveTrader.Core.ClassExtenders;
namespace EveTrader.Core.Network.Requests.CCP
{
    public class CorporationSheetRequest : ApiEntityRequestBase<Corporations>
    {
        public CorporationSheetRequest(Accounts a, long characterID, Func<string, TimeSpan, bool> stillCached, Action<string, DateTime, string> saveCache, Func<string, string> loadCache)
            : base(a, characterID, ApiRequestTarget.Corporation, stillCached, saveCache, loadCache)
        {
        }
        public override ApiRequestPage Page
        {
            get { return ApiRequestPage.CorporationSheet; }
        }

        protected override Corporations Parse(System.Xml.Linq.XDocument document)
        {
            var root = document.Element("eveapi").Element("result");

            Corporations c = new Corporations()
            {
                ID = root.Element("corporationID").Value.ToInt64(),
                Name = root.Element("corporationName").Value,
                //AllianceID = root.Element("allianceID").Value.ToInt64(),
                //AllianceName = root.Element("allianceName") != null ? root.Element("allianceName").Value : "",
               // CeoID = root.Element("ceoID").Value.ToInt64(),
                //CeoName = root.Element("ceoName").Value,
               // Description = root.Element("description").Value,
                //HeadquarterStationID = root.Element("stationID").Value.ToIn64(),
                //HeadquarterStationName = root.Element("stationName").Value,
                //MemberCount = root.Element("memberCount").Value.ToInt64(),
                //MemberLimit = root.Element("memberLimit").Value.ToInt64(),
                //Shares = root.Element("shares").Value.ToInt64(),
               // TaxRate = root.Element("taxRate").Value.ToDouble(),
                Ticker = root.Element("ticker").Value,
               // Url = root.Element("url").Value,
                //Logo = new CorporationLogo()
                //{
                //    CorporationID = root.Element("corporationID").Value.ToInt32(),
                //    Color1 = root.Element("logo").Element("color1").Value.ToInt32(),
                //    Color2 = root.Element("logo").Element("color2").Value.ToInt32(),
                //    Color3 = root.Element("logo").Element("color3").Value.ToInt32(),
                //    Shape1 = root.Element("logo").Element("shape1").Value.ToInt32(),
                //    Shape2 = root.Element("logo").Element("shape2").Value.ToInt32(),
                //    Shape3 = root.Element("logo").Element("shape3").Value.ToInt32()

                //}                                                 
            };
            foreach(Wallets w in 
                    (from x in
                         root.Elements().Where(
                         x => x.Name == "rowset" && x.Attribute("name").Value == "walletDivisions").First().Elements()
                     select
                         Wallets.CreateWallets(0,x.Attribute("description").Value, 0,x.Attribute("accountKey").Value.ToInt64())))
            {
                c.Wallets.Add(w);
            }
            return c;
        }

        public override TimeSpan CachingTime
        {
            get { return new TimeSpan(6, 0, 0); }
        }
    }
}
