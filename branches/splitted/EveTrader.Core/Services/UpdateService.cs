using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel.Composition;
using EveTrader.Core.Updater.CCP;
using EveTrader.Core.Model.Trader;
using System.Threading;
using EveTrader.Core.Model;


namespace EveTrader.Core.Services
{
    [Export(typeof(IUpdateService))]
    public class UpdateService : IUpdateService
    {
        private readonly CharacterUpdater iCharacterUpdater;
        private readonly CorporationUpdater iCorporationUpdater;
        private readonly TraderModel iModel;
        private readonly ISettingsProvider iSettings;
        private Timer iTimer;
        private bool iBigUpdate = false;

        private readonly object iUpdaterLock = new object();

        [ImportingConstructor]
        public UpdateService(CharacterUpdater characterUpdater, CorporationUpdater corporationUpdater, TraderModel tm, ISettingsProvider settings)
        {
            iCharacterUpdater = characterUpdater;
            iCorporationUpdater = corporationUpdater;
            iModel = tm;
            iSettings = settings;

            iTimer = new Timer(new TimerCallback(o => Update()), null, Timeout.Infinite, Timeout.Infinite);
            ActivateTimer();
        }

        private void ActivateTimer()
        {
            if (iSettings.AutoUpdate)
                iTimer.Change(0, 60 * 60 * 1000);
            else
                iTimer.Change(Timeout.Infinite, Timeout.Infinite);
        }

        public void Update()
        {
            ThreadStart ts = new ThreadStart(ThreadedUpdate);
            Thread t = new Thread(ts);
            t.Name = "CCP Api Updater";
            t.Start();
        }

        private void ThreadedUpdate()
        {
            lock (iUpdaterLock)
            {
                RaiseUpdateStarted();
                iTimer.Change(Timeout.Infinite, Timeout.Infinite);

                iBigUpdate = true;
                var toBeUpdated = iModel.Entity.OfType<Characters>()
                    .Union(iModel.Entity.OfType<Corporations>().Where(c => !c.Npc).Cast<Entities>()).ToList();
                foreach (var e in toBeUpdated)
                    this.Update(e);

                iBigUpdate = false;
                RaiseUpdateCompleted(toBeUpdated);

                ActivateTimer();
            }
        }

        public void Update(Entities e)
        {
            lock (iUpdaterLock)
            {
                if (e is Characters)
                    iCharacterUpdater.Update(e as Characters);
                if (e is Corporations)
                    iCorporationUpdater.Update(e as Corporations);

                RaiseUpdateCompleted(e);
            }
        }

        public bool AutoUpdate
        {
            get
            {
                return iSettings.AutoUpdate;
            }
            set
            {
                iSettings.AutoUpdate = value;
                ActivateTimer();
            }
        }


        public event EventHandler<EntitiesUpdatedEventArgs> UpdateCompleted;


        private void RaiseUpdateCompleted(IEnumerable<Entities> updated)
        {
            if (iBigUpdate)
                return;

            var handler = UpdateCompleted;
            if (handler != null)
            {
                handler(this, new EntitiesUpdatedEventArgs(updated));
                //Action a = () => handler(this, new EntitiesUpdatedEventArgs(updated));
                //Thread t = new Thread(new ThreadStart(a));
                //t.Name = "Entities Updated Event";
                //t.Start();
            }
            
               
        }

        private void RaiseUpdateCompleted(Entities updated)
        {
            RaiseUpdateCompleted(new Entities[] { updated });
        }

        private void RaiseUpdateStarted()
        {
            var handler = UpdateStarted;
            if (handler != null)
                handler(this, EventArgs.Empty);
        }

        public event EventHandler UpdateStarted;
    }
}
