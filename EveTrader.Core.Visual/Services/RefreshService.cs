using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EveTrader.Core.Visual.ViewModel;
using System.ComponentModel.Composition;

namespace EveTrader.Core.Services
{
    public class RefreshService : IRefreshService
    {
        private IEnumerable<IRefreshableViewModel> viewModels;

        [ImportingConstructor]
        public RefreshService([ImportMany] IEnumerable<IRefreshableViewModel> models)
        {
            viewModels = models;
        }

        public void Refresh()
        {
            foreach (var viewModel in viewModels)
                viewModel.Refresh();
        }
    }
}
