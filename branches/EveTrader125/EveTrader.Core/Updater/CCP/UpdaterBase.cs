using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EveTrader.Core.Model;

namespace EveTrader.Core.Updater.CCP
{
    public abstract class UpdaterBase<T> where T : Entities
    {
        protected readonly TraderModel iModel;

        public UpdaterBase(TraderModel tm)
        {
            iModel = tm;
        }

        public bool Update(T entity)
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

        protected abstract bool InnerUpdate(T entity);
    }
}
