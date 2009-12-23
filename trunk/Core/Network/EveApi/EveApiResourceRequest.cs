using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;
using System.Xml.Linq;
using Core.Network.EveApi;

namespace Core.Network.EveApi
{
    public abstract class EveApiResourceRequest : ResourceRequest
    {
        private const string requestUrlTemplate = "http://api.eve-online.com/{0}/{1}.xml.aspx";
        private XDocument cachedResponseXml;

        protected int AccountId { get; set; }
        protected string ApiKey { get; set; }

        protected abstract EveApiResourceType ResourceType { get; }

        protected override ResourceRequestMethod Method 
        { 
            get
            {
                return ResourceRequestMethod.Get;
            }
        }
        protected override IList<ResourceRequestParameter> Parameters
        {
            get
            {
                return new List<ResourceRequestParameter>
                {
                    new ResourceRequestParameter { Name = "version", Value = "2" },
                    new ResourceRequestParameter { Name = "userID",  Value = this.AccountId.ToString() },
                    new ResourceRequestParameter { Name = "apiKey",  Value = this.ApiKey }
                };
            }
        }

        protected virtual string RequestUrlTemplate
        {
            get
            {
                return requestUrlTemplate;
            }
        }
        protected XDocument ChachedResponseXml
        {
            get
            {
                return this.cachedResponseXml;
            }
        }

        protected EveApiResourceRequest(int accountId, string apiKey)
        {
            this.AccountId = accountId;
            this.ApiKey = apiKey;
        }

        protected XDocument GetResponseXml()
        {
            XmlReader xmlReader = XmlReader.Create(this.GetResponseStream());
            this.cachedResponseXml = XDocument.Load(xmlReader);
            return this.cachedResponseXml;
        }
    }
}
