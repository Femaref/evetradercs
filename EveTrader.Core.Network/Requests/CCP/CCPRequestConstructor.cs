using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EveTrader.Core.Network.Requests.CCP
{
    public class CCPRequestConstructor : IRequestConstructor
    {
        private readonly ApiRequestPage iPage;
        private readonly ApiRequestTarget iTarget;
        private readonly IDictionary<string, string> iParameters;

        public CCPRequestConstructor(ApiRequestPage page, ApiRequestTarget target, IDictionary<string, string> parameters)
        {
            iPage = page;
            iTarget = target;
            iParameters = parameters;
        }


        public string GetRequestString()
        {
            throw new NotImplementedException();
        }

        public string GetRequestData()
        {
            throw new NotImplementedException();
        }

        public string RequestType
        {
            get { return "POST"; }
        }
    }
}
