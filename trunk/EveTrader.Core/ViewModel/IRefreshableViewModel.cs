using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EveTrader.Core.Controllers;

namespace EveTrader.Core.ViewModel
{
    public interface IRefreshableViewModel
    {
        void Refresh();
        void DataIncoming(object sender, Services.EntitiesUpdatedEventArgs e);
        bool Updating { get; }
    }
}
