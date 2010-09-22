using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EveTrader.Updater
{
    public interface IApplicationUpdateService
    {
        IEnumerable<UpdateFile> CheckUpdate();
        void Update();
    }
}
