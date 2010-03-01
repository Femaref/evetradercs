using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Core.Network.EveApi.Entities
{
    public interface IEntity : IAccount
    {
        string Name { get; set; }

        DateTime NextUpdateTime { get; }

        void BeforeUpdate();
        void AfterUpdate();
    }
}