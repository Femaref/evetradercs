using System;
using EveTrader.Core.Model.Trader;

namespace EveTrader.Core.Services
{
    public interface IUpdateService
    {
        bool AutoUpdate { get; set; }
        void Update();
        void Update(Entities e);
        event EventHandler<EntitiesUpdatedEventArgs> UpdateCompleted;
        event EventHandler UpdateStarted;
    }
}
