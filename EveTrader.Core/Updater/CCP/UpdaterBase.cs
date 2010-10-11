using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EveTrader.Core.Model.Trader;

namespace EveTrader.Core.Updater.CCP
{
    public abstract class UpdaterBase<T> where T : Entities
    {
        protected readonly TraderModel iModel;

        public UpdaterBase(TraderModel tm)
        {
            iModel = tm;
        }

        public bool Update<U>(U entity) where U : T
        {
            try
            {
                return InnerUpdate(entity);
            }
            catch (Exception ex)
            {
                throw new UpdaterFailedException(
    string.Format("Exception occured in {0}. See InnerException for details.",
        string.Format("{0}.{1}()", ex.TargetSite.DeclaringType.Name, ex.TargetSite.Name)),
    ex);
            }
        }

        protected abstract bool InnerUpdate<U>(U entity) where U : T;
    }
}
