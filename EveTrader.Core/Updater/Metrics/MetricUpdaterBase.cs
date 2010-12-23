using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EveTrader.Core.Model.Metric;

namespace EveTrader.Core.Updater.Metrics
{
    public abstract class MetricUpdaterBase
    {
        protected readonly MetricModel iModel;

        public MetricUpdaterBase(MetricModel mm)
        {
            iModel = mm;
        }


        public bool Update(
            long typeID,
            long regionID = 10000002,
            long minimumQuantity = 0,
            string developerKey = "")
        {
            return Update ( new long[] {typeID}, new long[] {regionID}, minimumQuantity, developerKey);
        }

        public bool Update(
            IEnumerable<long> typeIDs,
            IEnumerable<long> regionsIDs,
            long mininumQuantity = 0,
            string developerKey = ""
                )
        {
            try
            {
                return InnerUpdate(typeIDs, regionsIDs, mininumQuantity, developerKey);
            }
            catch (Exception ex)
            {
                throw new UpdaterFailedException(
    string.Format("Exception occured in {0}. See InnerException for details.",
        string.Format("{0}.{1}()", ex.TargetSite.DeclaringType.Name, ex.TargetSite.Name)),
    ex);
            }
        }

        protected abstract bool InnerUpdate(
                        IEnumerable<long> typeIDs,
            IEnumerable<long> regionsIDs,
            long mininumQuantity = 0,
            string developerKey = "");

    }
}
