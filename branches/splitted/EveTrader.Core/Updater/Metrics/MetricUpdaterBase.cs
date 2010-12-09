using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EveTrader.Core.Model.Metric;

namespace EveTrader.Core.Updater.Metrics
{
    public abstract class MetricUpdaterBase
    {
        private readonly MetricModel iModel;

        public MetricUpdaterBase(MetricModel mm)
        {
            iModel = mm;
        }
        public bool Update()
        {
            try
            {
                return InnerUpdate();
            }
            catch (Exception ex)
            {
                throw new UpdaterFailedException(
    string.Format("Exception occured in {0}. See InnerException for details.",
        string.Format("{0}.{1}()", ex.TargetSite.DeclaringType.Name, ex.TargetSite.Name)),
    ex);
            }
        }

        protected abstract bool InnerUpdate(IEnumerable<long> types);

    }
}
