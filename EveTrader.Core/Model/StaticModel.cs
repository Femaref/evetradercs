using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel.Composition;
using System.Data.EntityClient;

namespace EveTrader.Core.Model
{
    [PartCreationPolicy(System.ComponentModel.Composition.CreationPolicy.NonShared)]
    [Export(typeof(StaticModel))]
    public partial class StaticModel
    {
        [ImportingConstructor]
        public StaticModel([Import("StaticModelConnection")] EntityConnectionStringBuilder sb)
            : base(new EntityConnection(sb.ToString()), "StaticModel")
        {
            this.ContextOptions.LazyLoadingEnabled = true;
            OnContextCreated();
        }
    }
}
