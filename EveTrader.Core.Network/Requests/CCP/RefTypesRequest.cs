using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EveTrader.Core.Model.Trader;

namespace EveTrader.Core.Network.Requests.CCP
{
    public class RefTypesRequest : ApiRequestBase<IEnumerable<RefTypesDto>>
    {
        public RefTypesRequest(Func<string, TimeSpan, bool> stillCached, Action<string, DateTime, string> saveCache, Func<string, string> loadCache)
            : base(ApiRequestTarget.Eve, stillCached, saveCache, loadCache)
        {
        }


        public override ApiRequestPage Page
        {
            get { return ApiRequestPage.RefTypes; }
        }

        protected override IEnumerable<RefTypesDto> Parse(System.Xml.Linq.XDocument document)
        {
            if (document.ToString().Contains("error code="))
                throw new ArgumentException(string.Format("Api error encountered: {0}", this.ErrorCode));

            var root = document.Element("eveapi").Element("result").Element("rowset").Elements();

            return root.Select(r => new RefTypesDto()
            {
                ID = long.Parse(r.Attribute("refTypeID").Value),
                Name = r.Attribute("refTypeName").Value
            });
        }

        public override TimeSpan CachingTime
        {
            get { return new TimeSpan(1, 0, 0, 0); }
        }
    }
}
