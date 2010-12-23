using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ClassExtenders;

namespace EveTrader.Core.Network.Requests.Metrics
{
    public class MetricsRequestConstructor : IRequestConstructor<MetricsRequestConstructor>
    {
        private readonly MetricsPage iPage;
        private readonly Dictionary<string, string> iData = new Dictionary<string, string>();

        private const string BaseUri = "http://www.eve-metrics.com/api/{0}.xml";

        public MetricsRequestConstructor(MetricsPage mp, string developerKey = "")
        {
            iPage = mp;
            iData.Add("key", developerKey);
        }

        public MetricsRequestConstructor AddData(string key, string value)
        {
            if (!iData.ContainsKey(key))
                iData.Add(key, value);

            return this;
        }

        public string GetRequestString()
        {
            return string.Format(BaseUri, iPage.StringValue());
        }

        public string GetRequestData()
        {
            return iData.Aggregate("", (s, kvp) => s + string.Format("{0}={1}&", kvp.Key, kvp.Value));
        }

        public string RequestType
        {
            get { return "GET"; }
        }
    }
}
