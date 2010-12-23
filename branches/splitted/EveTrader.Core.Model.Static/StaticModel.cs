using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel.Composition;
using System.Data.EntityClient;

namespace EveTrader.Core.Model.Static
{
    [PartCreationPolicy(System.ComponentModel.Composition.CreationPolicy.NonShared)]
    [Export(typeof(StaticModel))]
    public partial class StaticModel
    {
        [ImportingConstructor]
        public StaticModel([Import("StaticModelConnectionString")] IConnectionStringProvider sb)
            : base(new EntityConnection(sb.GetConnectionString()), "StaticModel")
        {
            this.ContextOptions.LazyLoadingEnabled = true;
            OnContextCreated();
        }
    }
}
