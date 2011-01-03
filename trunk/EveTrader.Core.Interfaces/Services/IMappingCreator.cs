using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel.Composition;

namespace EveTrader.Core.Services
{
    [InheritedExport]
    public interface IMappingCreator
    {
        void CreateMappings();
    }
}
