using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EveTrader.Core.Model.Trader;

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

    public class EntitiesUpdatedEventArgs<T> : EventArgs
    {
        public IEnumerable<T> UpdatedEntities { get; set; }

        public EntitiesUpdatedEventArgs(IEnumerable<T> updated)
        {
            UpdatedEntities = updated;
        }
    }
}
