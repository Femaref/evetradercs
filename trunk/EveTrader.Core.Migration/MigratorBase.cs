using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace EveTrader.Core.Migration
{
    public abstract class MigratorBase
    {
        public abstract bool Migrate();
    }
}
