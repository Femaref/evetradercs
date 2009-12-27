using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;
using Core.ClassExtenders;
using Core.DomainModel;

namespace Core.Network.EveApi.Requests
{
    public class AssetsRequest : EveApiCharacterResourceRequest
    {
        protected override EveApiResourceType ResourceType
        {
            get 
            {
                return EveApiResourceType.AssetList;
            }
        }

        public AssetsRequest(Character character) : base (character)
        {
        }

        public List<Asset> Request()
        {
            return this.Parse(base.GetResponseXml());
        }

        private List<Asset> Parse(XDocument document)
        {
            IEnumerable<XElement> rows;

            try
            {
                rows = document.Descendants("rowset").First(rowset => rowset.Attribute("name").Value == "assets").Elements();

                return this.Parse(rows, "0");
            }
            catch
            {
                return new List<Asset>();
            }
        }
        private List<Asset> Parse(IEnumerable<XElement> rows, string locationId)
        {
            return rows.Select(r => new Asset
                {
                    Id = r.Attribute("itemID").Value.ToInt32(),
                    LocationId = (r.Attribute("locationID").Value ?? locationId).ToInt32(),
                    TypeId = r.Attribute("typeID").Value.ToInt32(),
                    Quantity = r.Attribute("quantity").Value.ToInt32(),
                    AssetStorageType = (AssetStorageType) Enum.Parse(typeof (AssetStorageType), r.Attribute("flag").Value),
                    IsPacked = r.Attribute("singleton").Value == "0" ? true : false,
                    SubAssets = r.HasElements ? this.Parse(r.Descendants("row"), r.Attribute("locationID") != null ? r.Attribute("locationID").Value : locationId) : new List<Asset>()
                }).ToList();
        }
    }
}
