using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel.Composition;
using EveTrader.Core.Model.Trader;
using EveTrader.Core.Network.Requests.CCP;

namespace EveTrader.Core.Updater.CCP
{
    [Export(typeof(IRefTypesUpdater))]
    public class RefTypesUpdater : StaticUpdaterBase, IRefTypesUpdater
    {
        [ImportingConstructor]
        public RefTypesUpdater([Import(RequiredCreationPolicy = CreationPolicy.Shared)] TraderModel tm)
            : base(tm)
        {
        }

        protected override bool InnerUpdate()
        {

            RefTypesRequest rtr = new RefTypesRequest(iModel.StillCached, iModel.SaveCache, iModel.LoadCache);
            var insert = rtr.Request();

            foreach (var t in insert)
            {
                var current = iModel.RefTypes.SingleOrDefault(r => r.ID == t.ID);
                if (current == null)
                {
                    current = new RefTypes() { ID = t.ID, Name = t.Name };
                    iModel.RefTypes.AddObject(current);
                    continue;
                }
                current.Name = t.Name;
            }

            iModel.SaveChanges();

            return true;

        }
    }
}
