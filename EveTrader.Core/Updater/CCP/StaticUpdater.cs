using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel.Composition;
using EveTrader.Core.Model.Trader;

namespace EveTrader.Core.Updater.CCP
{
    [Export]
    public class StaticUpdater : StaticUpdaterBase
    {
        private List<IStaticUpdater> iUpdaters = new List<IStaticUpdater>();
        private TraderLogService logger;

        [ImportingConstructor]
        public StaticUpdater([Import(RequiredCreationPolicy = CreationPolicy.Shared)] TraderModel tm,
            IRefTypesUpdater refTypesUpdater, TraderLogService logger)
            : base(tm)
        {
            iUpdaters.Add((IStaticUpdater)refTypesUpdater);
            this.logger = logger;
        }

        protected override bool InnerUpdate()
        {
            foreach (var updater in iUpdaters)
            {
                try
                {
                    updater.Update();
                }
                catch (UpdaterFailedException ex)
                {
                    logger.WriteToLog(ex.ToString(), ex.InnerException.TargetSite.DeclaringType.Name + "." + ex.InnerException.TargetSite.Name);
                }
            }

            return true;
        }
    }
}
