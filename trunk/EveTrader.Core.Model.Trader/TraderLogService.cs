using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel.Composition;

namespace EveTrader.Core.Model.Trader
{
    [Export]
    public class TraderLogService
    {
        private readonly TraderModel model;

        [ImportingConstructor]
        public TraderLogService([Import(RequiredCreationPolicy = CreationPolicy.Shared)] TraderModel tm)
        {
            model = tm;
        }

        public string WriteToLog(string text, string callingMember)
        {
            var log = new ApplicationLog() { Message = text, CallingClass = callingMember, Date = DateTime.UtcNow };
            model.ApplicationLog.AddObject(log);
            model.SaveChanges();
            return string.Format("{0} from {1} at {2}", log.Message, log.CallingClass, log.Date);
        }
    }
}
