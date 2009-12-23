using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Core.Network;
using Core.Network.EveApi;
using Core.ClassExtenders;

namespace Core.Network.EveApi
{
    public abstract class EveApiAccountResourceRequest : EveApiResourceRequest
    {
        protected override Uri Uri
        {
            get
            {
                return new Uri(
                    string.Format(
                        this.RequestUrlTemplate, 
                        EveApiResourceFrom.Account.StringValue(),
                        this.ResourceType.StringValue()));
            }
        }

        protected EveApiAccountResourceRequest(int accountId, string apiKey) : base (accountId, apiKey)
        {
        }
    }
}

