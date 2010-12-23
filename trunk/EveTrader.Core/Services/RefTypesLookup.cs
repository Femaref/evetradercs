using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel.Composition;
using EveTrader.Core.Model.Trader;

namespace EveTrader.Core.Services
{
    [Export(typeof(IRefTypesLookup))]
    public class RefTypesLookup : IRefTypesLookup
    {
        private readonly TraderModel iModel;


        [ImportingConstructor]
        public RefTypesLookup([Import(RequiredCreationPolicy = CreationPolicy.NonShared)] TraderModel tm)
        {
            iModel = tm;
        }


        public string Lookup(long id)
        {
            var grab = iModel.RefTypes.SingleOrDefault(r => r.ID == id);
            return grab == null ? "Unknown RefType" : grab.Name;
        }

        public long Lookup(string name)
        {
            var grab = iModel.RefTypes.SingleOrDefault(r => r.Name == name);
            return grab == null ? 0 : grab.ID;
        }
    }
}
