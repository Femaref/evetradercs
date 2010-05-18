using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EveTrader.Core.Model;
using System.ComponentModel.Composition;

namespace EveTrader.Core.Updater.CCP
{
    [Export]
    public class EntityFactory
    {
        private readonly TraderModel iModel;

        [ImportingConstructor]
        public EntityFactory(TraderModel tm)
        {
            iModel = tm;
        }

        public Entities CreateEntity(long id, Accounts a)
        {
            Entities newEntity = new Entities() { ID = id, Account = a };
            iModel.Entity.AddObject(newEntity);
            iModel.SaveChanges();

            return newEntity;
        }
    }
}
