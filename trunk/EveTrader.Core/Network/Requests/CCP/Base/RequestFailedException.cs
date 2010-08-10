using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EveTrader.Core.Network.Requests.CCP
{
    public class RequestFailedException : Exception
    {
        public int ErrorCode { get; set; }

        public RequestFailedException(int errorCode, string message, Exception innerException = null)
            : base(message, innerException)
        {
            ErrorCode = errorCode;
        }
    }
}