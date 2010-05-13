using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;
using System.Xml.Linq;
using System.Net;
using System.IO;
using EveTrader.Core.ClassExtenders;

namespace EveTrader.Core.Net.Requests.CCP
{
    public abstract class ApiRequestBase<T>
    {
        protected Dictionary<string, string> iData = new Dictionary<string, string>();

        protected readonly ApiRequestTarget iTarget;
        protected readonly ApiRequestPage iPage;

        public XDocument CachedResponseXml = new XDocument();

        private XDocument GetRequestXml()
        {
            HttpWebRequest req = (HttpWebRequest)HttpWebRequest.Create(Identifier);

            req.UserAgent = "EveTrader/1.2.5";
            req.Method = "POST";
            Stream s = req.GetRequestStream();

            byte[] postData = Encoding.Default.GetBytes(this.Data);
            s.Write(postData, 0, this.Data.Length);
            s.Close();

            HttpWebResponse res = (HttpWebResponse)req.GetResponse();

            using (StreamReader reader = new StreamReader(res.GetResponseStream()))
            {
                string output = reader.ReadToEnd();
                CachedResponseXml =  XDocument.Parse(output);
                return CachedResponseXml;
            }
        }

        private const string BaseIdentifier = @"http://api.eve-online.com/{0}/{1}.xml.aspx";

        public ApiRequestTarget Target
        {
            get { return iTarget; }
        }
        public ApiRequestPage Page
        {
            get { return iPage; }
        }

        public Uri Identifier
        {
            get { return new Uri(string.Format(BaseIdentifier, Target.ToString(), Page.ToString())); }
        }

        public int ErrorCode
        {
            get
            {
                if (this.CachedResponseXml.Descendants().Where(x => x.Name == "error").Count() > 0)
                    return this.CachedResponseXml.Descendants("error").First().Attribute("code").Value.ToInt32();
                else
                    return 0;
            }
        }

        protected virtual string Data
        {
            get
            {
                return "";
            }
        }

        public T Request()
        {
            return this.Parse(this.GetRequestXml());
        }

        public abstract T Parse(XDocument doc);
    }
}
