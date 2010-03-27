using System.Collections.Generic;
using System.Linq;
using System.Xml;
using System.Xml.Linq;
using Core.ClassExtenders;

namespace Core.Network.EveApi
{
    public abstract class EveApiResourceRequest : ResourceRequest
    {
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

        private const string iRequestUrlTemplate = "http://api.eve-online.com/{0}/{1}.xml.aspx";
        private XDocument iCachedResponseXml;

        protected int iAccountId { get; set; }
        protected string iApiKey { get; set; }

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
                    new ResourceRequestParameter { Name = "userID",  Value = this.iAccountId.ToString() },
                    new ResourceRequestParameter { Name = "apiKey",  Value = this.iApiKey }
                };
            }
        }

        protected virtual string RequestUrlTemplate
        {
            get
            {
                return iRequestUrlTemplate;
            }
        }
        protected XDocument CachedResponseXml
        {
            get
            {
                return this.iCachedResponseXml;
            }
        }

        protected EveApiResourceRequest(int accountId, string apiKey)
        {
            this.iAccountId = accountId;
            this.iApiKey = apiKey;
        }

        protected XDocument GetResponseXml()
        {
            XmlReader xmlReader = XmlReader.Create(this.GetResponseStream());
            this.iCachedResponseXml = XDocument.Load(xmlReader);
            return this.iCachedResponseXml;
        }
    }
}
