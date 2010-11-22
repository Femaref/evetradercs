using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EveTrader.Core.Services
{
    public interface IRefTypesLookup
    {
        string Lookup(long id);
        long Lookup(string name);
    }
}
