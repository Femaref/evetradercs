using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Diagnostics;
using System.Reflection;
using System.ComponentModel.Composition;

namespace EveTrader.Core.Model
{
    [Export(typeof(TraderModel))]
    public partial class TraderModel
    {
        public string WriteToLog(string text, string callingMember)
        {
            StackTrace st = new StackTrace();
            StackFrame sf = st.GetFrame(0);
            MethodBase mb = sf.GetMethod();

            var log = new Model.ApplicationLog() { Message = text, CallingClass = callingMember, Date = DateTime.UtcNow };
            this.ApplicationLog.AddObject(log);
            this.SaveChanges();
            return string.Format("{0} from {1} at {2}", log.Message, log.CallingClass, log.Date);
        }
    }
}
