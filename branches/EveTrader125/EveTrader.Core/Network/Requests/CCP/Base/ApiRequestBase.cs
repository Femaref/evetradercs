﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;
using System.Xml.Linq;
using System.Net;
using System.IO;
using EveTrader.Core.ClassExtenders;

namespace EveTrader.Core.Network.Requests.CCP
{
    public abstract class ApiRequestBase<T>
    {
        protected Dictionary<string, string> iData = new Dictionary<string, string>();

        protected readonly ApiRequestTarget iTarget;

        public ApiRequestBase(ApiRequestTarget target, Func<string, TimeSpan, bool> stillCached, Action<string, DateTime, string> saveCache, Func<string, string> loadCache)
        {
            iTarget = target;
            iStillCached = stillCached;
            iSaveCache = saveCache;
            iLoadCache = loadCache;
        }

        public XDocument CachedResponseXml
        {
            get { return GetRequestXml(); }
        }

        private XDocument iCachedResponseXml = null;

        private XDocument GetRequestXml()
        {
            if (iCachedResponseXml != null)
                return iCachedResponseXml;

            if (iStillCached(this.Identifier.ToString() + "?" + this.Data, this.CachingTime))
                return XDocument.Parse(iLoadCache(this.Identifier.ToString() + "?" + this.Data));


            HttpWebRequest req = (HttpWebRequest)HttpWebRequest.Create(Identifier);

            req.UserAgent = "EveTrader/1.2.5";
            req.Method = "POST";
            req.ContentType = "application/x-www-form-urlencoded";


            byte[] postData = Encoding.Default.GetBytes(this.Data);
            req.ContentLength = postData.Length;

            Stream s = req.GetRequestStream();
            s.Write(postData, 0, postData.Length);
            s.Close();

            HttpWebResponse res = (HttpWebResponse)req.GetResponse();

            using (StreamReader reader = new StreamReader(res.GetResponseStream()))
            {
                string output = reader.ReadToEnd();
                iCachedResponseXml = XDocument.Parse(output);
                if (this.ErrorCode != 0)
                    throw new RequestFailedException(this.ErrorCode, this.ErrorMessage);
                this.iSaveCache(this.Identifier.ToString() + "?" + this.Data, this.CurrentTime, iCachedResponseXml.ToString());
                return iCachedResponseXml;
            }
        }

        private const string BaseIdentifier = @"http://api.eve-online.com/{0}/{1}.xml.aspx";
        private Func<string, TimeSpan, bool> iStillCached;
        private Action<string, DateTime, string> iSaveCache;
        private Func<string, string> iLoadCache;

        public ApiRequestTarget Target
        {
            get { return iTarget; }
        }
        public abstract ApiRequestPage Page { get; }

        public Uri Identifier
        {
            get
            {
                return new Uri(
                    string.Format(
                                BaseIdentifier,
                                Target.StringValue(),
                                Page.StringValue())
                    );
            }
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

        public string ErrorMessage
        {
            get
            {
                if (this.CachedResponseXml.Descendants().Where(x => x.Name == "error").Count() > 0)
                    return this.CachedResponseXml.Descendants().First(x=>x.Name == "error").Value;
                else
                    return "";
            }
        }


        public DateTime CurrentTime
        {
            get
            {
                return this.CachedResponseXml.Descendants("currentTime").First().Value.ToDateTime();
            }
        }

        public DateTime CachedUntil
        {
            get
            {
                return this.CachedResponseXml.Descendants("cachedUntil").First().Value.ToDateTime();
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

        protected abstract T Parse(XDocument document);

        public abstract TimeSpan CachingTime { get; }
    }
}
