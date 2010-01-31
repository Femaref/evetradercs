using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace Core.Migration
{
    public abstract class MigratorBase
    {
        public abstract bool MigrateUp();
        public abstract bool MigrateDown();
    }
}
