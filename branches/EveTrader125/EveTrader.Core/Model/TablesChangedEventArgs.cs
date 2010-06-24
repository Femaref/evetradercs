using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EveTrader.Core.Model
{
    public class TablesChangedEventArgs : EventArgs
    {
        public TablesChangedEventArgs(Tables tables)
        {
            this.ChangedTables = tables;
        }

        public Tables ChangedTables { get; set; }
    }
}
