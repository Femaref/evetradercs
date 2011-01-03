using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ClassExtenders;

namespace EveTrader.Core.Network.Requests.Central
{
    public class CentralRequestConstructor : IRequestConstructor<CentralRequestConstructor>
    {
        private CentralRequestPage page;
        private List<Tuple<string, string>> arguments;
        private const string BaseUri = "http://api.eve-central.com/api/{0}";


        public CentralRequestConstructor(CentralRequestPage page)
        {
            this.page = page;

            arguments = new List<Tuple<string, string>>();
        }

        public CentralRequestConstructor AddData(string key, string value)
        {
            arguments.Add(new Tuple<string, string>(key, value));

            return this;
        }

        public CentralRequestConstructor AddData(IEnumerable<Tuple<string, string>> data)
        {
            foreach (var d in data)
            {
                this.AddData(d.Item1, d.Item2);
            }

            return this;
        }

        public string GetRequestString()
        {
            return string.Format(BaseUri, page.StringValue());
        }

        public string GetRequestData()
        {
            return arguments.Aggregate("", (output, current) => output += string.Format("{0}={1}&", current.Item1, current.Item2));
        }

        public string RequestType
        {
            get { return "GET"; }
        }
    }
}
