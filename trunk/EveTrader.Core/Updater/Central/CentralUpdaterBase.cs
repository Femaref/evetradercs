using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EveTrader.Core.Model.Central;

namespace EveTrader.Core.Updater.Central
{
    public abstract class CentralUpdaterBase
    {
        protected readonly CentralModel model;

        public CentralUpdaterBase(CentralModel cm)
        {
            model = cm;
        }

        public bool Update(long typeID, long regionID, long minimumQuantity = 0)
        {
            return Update(new long[] { typeID }, new long[] { regionID }, minimumQuantity);
        }

        public bool Update(IEnumerable<long> typeIDs, IEnumerable<long> regionIDs, long minimumQuantity = 0)
        {
            try
            {
                return InnerUpdate(typeIDs, regionIDs, minimumQuantity);
            }
            catch (Exception ex)
            {
                throw new UpdaterFailedException(
    string.Format("Exception occured in {0}. See InnerException for details.",
        string.Format("{0}.{1}()", ex.TargetSite.DeclaringType.Name, ex.TargetSite.Name)),
    ex);
            }
        }

        public abstract bool InnerUpdate(IEnumerable<long> typeIDs, IEnumerable<long> regionIDs, long minimumQuantity);
    }
}
