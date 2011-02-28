using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel.Composition;
using EveTrader.Core.Model.Trader;
using EveTrader.Core.Visual.ViewModel.Display;
using EveTrader.Core.Services;

namespace EveTrader.Core.ViewModel
{
    [InheritedExport]
    public interface IReportPage
    {
        object View { get; }
        string Name { get; }
        int Index { get; }
        void Refresh(object sender, EntitiesUpdatedEventArgs<long> e);
    }
}
