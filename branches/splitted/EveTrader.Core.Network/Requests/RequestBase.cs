using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Text;
using System.Xml.Linq;

namespace EveTrader.Core.Network.Requests
{
    /// <summary>
    /// Provides infrastructure to query generic apis
    /// </summary>
    /// <typeparam name="TOutput">Specifies the output</typeparam>
    public abstract class RequestBase<TOutput>
    {
        private XDocument iCachedResponseXml = null;
        protected readonly IRequestConstructor iRequestConstructor;
        private Func<string, TimeSpan, bool> iStillCached;
        private Action<string, DateTime, string> iSaveCache;

        protected RequestBase(IRequestConstructor rc, Func<string, TimeSpan, bool> stillCached, Action<string, DateTime, string> saveCache, Func<string, string> loadCache)
        {
            iRequestConstructor = rc;
            iStillCached = stillCached;
            iSaveCache = saveCache;
            iLoadCache = loadCache;
        }

        public XDocument CachedResponseXml
        {
            get { return GetRequestXml(); }
        }

        public bool UpdateAvailable
        {
            get
            {
                return !StillCached;
            }
        }

        protected bool StillCached
        {
            get
            {
                return iStillCached(this.Identifier.ToString() + "?" + iRequestConstructor.GetRequestData(), this.CachingTime);
            }
        }

        private XDocument GetRequestXml()
        {
            if (iCachedResponseXml != null)
                return iCachedResponseXml;

            if (this.StillCached)
                return XDocument.Parse(this.LoadCache());

            string output = RequestData();
            if (!this.ContainsError(output))
            {
                iCachedResponseXml = XDocument.Parse(output);
                this.SaveCache(iCachedResponseXml.ToString());
                return iCachedResponseXml;
            }
            else
            {
                this.OnError(output);
                throw new Exception("Error encountered, no specific exception specified!");
            }

        }

        protected abstract void OnError(string output);
        protected abstract void SaveCache(string content);
        protected abstract bool ContainsError(string output);

        private string RequestData()
        {
            HttpWebRequest req = null;

            if (iRequestConstructor.RequestType == "POST")
            {
                req = (HttpWebRequest)HttpWebRequest.Create(Identifier);

                req.UserAgent = "EveTrader/1.2.5";
                req.Method = "POST";
                req.ContentType = "application/x-www-form-urlencoded";

                byte[] postData = Encoding.Default.GetBytes(this.iRequestConstructor.GetRequestData());
                req.ContentLength = postData.Length;

                Stream s = req.GetRequestStream();
                s.Write(postData, 0, postData.Length);
                s.Close();
            }
            else
            {
                req = (HttpWebRequest)HttpWebRequest.Create(new Uri(Identifier + "?" + iRequestConstructor.GetRequestData()));
                req.UserAgent = "EveTrader/1.2.5";
            }

            HttpWebResponse res = (HttpWebResponse)req.GetResponse();

            using (StreamReader reader = new StreamReader(res.GetResponseStream()))
            {
                return reader.ReadToEnd();
            }
        }

        protected void SaveCache(DateTime time, string data)
        {
            this.iSaveCache(this.Identifier.ToString() + "?" + iRequestConstructor.GetRequestData(), time, data);
        }

        private Func<string, string> iLoadCache;

        private string LoadCache()
        {
            return iLoadCache(this.Identifier.ToString() + "?" + iRequestConstructor.GetRequestData());
        }

        public Uri Identifier
        {
            get
            {
                return new Uri(iRequestConstructor.GetRequestString());
            }
        }

        public TOutput Request()
        {
            return this.Parse(this.GetRequestXml());
        }

        protected abstract TOutput Parse(XDocument document);

        public abstract TimeSpan CachingTime { get; }
    }
}
