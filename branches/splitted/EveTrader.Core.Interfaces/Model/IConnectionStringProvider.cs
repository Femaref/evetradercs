using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel.Composition;

namespace EveTrader.Core.Model
{
    [InheritedExport]
    public interface IConnectionStringProvider
    {
        string GetConnectionString();
        void SetSource(string source);
    }
}
