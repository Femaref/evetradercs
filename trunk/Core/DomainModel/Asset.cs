using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Core.DomainModel
{
    public class Asset
    {
        [Obsolete("This is only guaranteed to be unique within this page load. IDs are recycled over time and it is possible for this to happen.")]
        public int Id { get; set; }  
        public int TypeId { get; set; }
        public int Quantity { get; set; }
        public int LocationId { get; set; }
        public AssetStorageType AssetStorageType { get; set; }
        public bool IsPacked { get; set; }
        public List<Asset> SubAssets;

        public Asset()
        {
            this.SubAssets = new List<Asset>();
        }
    }
}
