using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel.Composition;
using EveTrader.Core.Updater.CCP;
using EveTrader.Core.Model;
using System.Threading;


namespace EveTrader.Core.Controllers
{
    [Export]
    public class UpdateService
    {
        private readonly CharacterUpdater iCharacterUpdater;
        private readonly CorporationUpdater iCorporationUpdater;
        private readonly TraderModel iModel;
        private readonly ISettingsProvider iSettings;
        private Timer iTimer;

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

            foreach (Characters c in iModel.Entity.OfType<Characters>())
                iCharacterUpdater.Update(c);
            foreach (Corporations c in iModel.Entity.OfType<Corporations>())
                iCorporationUpdater.Update(c);

            ActivateTimer();
        }

        public void Update(Entities e)
        {
            if (e is Characters)
                iCharacterUpdater.Update(e as Characters);
            if (e is Corporations)
                iCorporationUpdater.Update(e as Corporations);
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
    }
}
