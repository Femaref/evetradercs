using System;
using EveTrader.Core.Model;

namespace EveTrader.Core.Controllers
{
    public interface IUpdateService
    {
        bool AutoUpdate { get; set; }
        void Update();
        void Update(Entities e);
        event EventHandler<EntitiesUpdatedEventArgs> Updated;
    }
}
