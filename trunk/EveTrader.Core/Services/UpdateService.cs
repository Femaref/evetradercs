using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel.Composition;
using EveTrader.Core.Updater.CCP;
using EveTrader.Core.Model;
using System.Threading;


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
            iTimer.Change(Timeout.Infinite, Timeout.Infinite);

            iBigUpdate = true;

            foreach (Entities e in iModel.Entity)
                this.Update(e);

            iBigUpdate = false;
            RaiseUpdated(iModel.Entity);

            ActivateTimer();
        }

        public void Update(Entities e)
        {
            if (e is Characters)
                iCharacterUpdater.Update(e as Characters);
            if (e is Corporations)
                iCorporationUpdater.Update(e as Corporations);

            RaiseUpdated(e);
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


        public event EventHandler<EntitiesUpdatedEventArgs> Updated;


        private void RaiseUpdated(IEnumerable<Entities> updated)
        {
            if (iBigUpdate)
                return;

            var handler = Updated;
            if (handler != null)
            {
                handler(this, new EntitiesUpdatedEventArgs(updated));
                //Action a = () => handler(this, new EntitiesUpdatedEventArgs(updated));
                //Thread t = new Thread(new ThreadStart(a));
                //t.Start();
            }
            
               
        }

        private void RaiseUpdated(Entities updated)
        {
            RaiseUpdated(new Entities[] { updated });
        }
    }
}
