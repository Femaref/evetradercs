using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EveTrader.Core.Services
{
    public interface IApplicationUpdateService
    {
        IEnumerable<UpdateFile> CheckUpdate();
        void Update();
    }
}
