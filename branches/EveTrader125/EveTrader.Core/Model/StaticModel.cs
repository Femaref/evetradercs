using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel.Composition;

namespace EveTrader.Core.Model
{
    [PartCreationPolicy(System.ComponentModel.Composition.CreationPolicy.NonShared)]
    [Export(typeof(StaticModel))]
    public partial class StaticModel
    {

    }
}
