using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Linq;

namespace EveTrader.Core.Services
{
    public interface IDatabaseImportService
    {
        void Import(XDocument xd);
    }
}
