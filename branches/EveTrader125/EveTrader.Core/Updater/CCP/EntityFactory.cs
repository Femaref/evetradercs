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

        public Characters CreateCharacter(long id, Accounts a)
        {
            if (iModel.Entity.OfType<Corporations>().Count(c => c.ID == 0) == 0)
            {
                iModel.Entity.AddObject(new Corporations() {ID = 0, Name = "Placeholder corporation", Npc = true, Ticker = "" });
                iModel.SaveChanges();
            }

            var check = iModel.Entity.OfType<Characters>().Where(s => s.ID == id);
            if (check.Count() == 1)
                return check.First();

            Characters newEntity = new Characters() { ID = id, Account = a, Name = "", Race = "", Bloodline ="", Gender = "", Balance = 0m,  Corporation = iModel.Entity.OfType<Corporations>().Where(c => c.ID == 0).First()};
            iModel.Entity.AddObject(newEntity);
            iModel.SaveChanges();

            return newEntity;
        }

        public Corporations CreateCorporation(long corporationID, Accounts a)
        {
            var check = iModel.Entity.OfType<Corporations>().Where(s => s.ID == corporationID);
            if (check.Count() == 1)
                return check.First();

            Corporations newEntity = new Corporations() { ID = corporationID, Account = a, Name = "", Ticker = "", Npc = false};
            iModel.Entity.AddObject(newEntity);
            iModel.SaveChanges();

            return newEntity;
        }
    }
}
