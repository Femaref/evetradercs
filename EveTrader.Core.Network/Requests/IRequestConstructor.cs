using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EveTrader.Core.Network.Requests
{
    public interface IRequestConstructor
    {
        string GetRequestString();
        string GetRequestData();
        string RequestType { get; }
    }
}
