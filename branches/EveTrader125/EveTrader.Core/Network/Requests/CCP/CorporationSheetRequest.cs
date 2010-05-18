using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EveTrader.Core.Model;

namespace EveTrader.Core.Network.Requests.CCP
{
    public class CorporationSheetRequest : ApiEntityRequestBase<Corporations>
    {
        public CorporationSheetRequest(Accounts a, long characterID)
            : base(a, characterID, ApiRequestTarget.Corporation)
        {
        }
        public override ApiRequestPage Page
        {
            get { return ApiRequestPage.CorporationSheet; }
        }

        protected override Corporations Parse(System.Xml.Linq.XDocument document)
        {
            throw new NotImplementedException();
        }
    }
}
