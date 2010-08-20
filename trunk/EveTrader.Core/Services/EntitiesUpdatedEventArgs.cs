using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EveTrader.Core.Model;

namespace EveTrader.Core.Services
{
    public class EntitiesUpdatedEventArgs : EventArgs
    {
        public IEnumerable<Entities> UpdatedEntities { get; set; }

        public EntitiesUpdatedEventArgs(IEnumerable<Entities> updated)
        {
            UpdatedEntities = updated;
        }
    }
}
