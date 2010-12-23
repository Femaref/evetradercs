using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EveTrader.Core.Controllers;
using System.ComponentModel.Composition;

namespace EveTrader.Core.Visual.ViewModel
{
    [InheritedExport(typeof(IRefreshableViewModel))]
    public interface IRefreshableViewModel
    {
        void Refresh();
        void DataIncoming(object sender, Services.EntitiesUpdatedEventArgs e);
        bool Updating { get; }
    }
}
