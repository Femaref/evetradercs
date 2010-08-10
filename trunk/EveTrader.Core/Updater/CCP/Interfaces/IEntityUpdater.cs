using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EveTrader.Core.Model;

namespace EveTrader.Core.Updater.CCP
{
    public interface IEntityUpdater<in T> where T: Entities
    {
        bool Update<U>(U entity) where U : T;
    }
}
