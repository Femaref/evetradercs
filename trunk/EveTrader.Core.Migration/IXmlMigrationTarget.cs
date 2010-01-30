using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Linq;

namespace EveTrader.Core.Migration
{
    public interface IXmlMigrationTarget
    {
        bool Upgrade(XDocument input);
        bool Downgrade(XDocument input);
    }
}
