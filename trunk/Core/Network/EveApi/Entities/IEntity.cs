using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Core.DomainModel;

namespace Core.Updaters
{
    public interface IEntity : IAccount
    {
        string Name { get; set; }

        DateTime NextUpdateTime { get; }

        void BeforeUpdate();
        void AfterUpdate();
    }
}
