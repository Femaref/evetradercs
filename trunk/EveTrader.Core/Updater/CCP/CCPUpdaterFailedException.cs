using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EveTrader.Core.Updater.CCP
{
    public class CCPUpdaterFailedException : UpdaterFailedException
    {
        public int ErrorCode { get; private set; }

        public CCPUpdaterFailedException(string message, Exception ex)
            : base(message, ex)
        {
        }
    }
}
