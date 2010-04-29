using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Diagnostics;
using System.Reflection;

namespace EveTrader.Core.Model
{
    public partial class TraderModel
    {
        public void WriteToLog(string text)
        {
            StackTrace st = new StackTrace();
            StackFrame sf = st.GetFrame(0);
            MethodBase mb = sf.GetMethod();

            this.ApplicationLog.AddObject(new Model.ApplicationLog() { Message = text, CallingClass = mb.DeclaringType.Name + "." + mb.Name, Date = DateTime.UtcNow });
            this.SaveChanges();
        }
    }
}
