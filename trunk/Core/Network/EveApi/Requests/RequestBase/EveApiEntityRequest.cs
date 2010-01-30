using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Core.ClassExtenders;
using Core.DomainModel;
using Core.Network;
using Core.Network.EveApi;

namespace Core.Network.EveApi
{
    public abstract class EveApiEntityRequest<TOutput> : EveApiResourceRequest
    {
        private int iCharacterID;
        private EveApiResourceFrom iFrom;

        protected override IList<ResourceRequestParameter> Parameters
        {
            get
            {
                IList<ResourceRequestParameter> parameters = base.Parameters;
                parameters.Add(new ResourceRequestParameter { Name = "characterId", Value = this.iCharacterID.ToString() });

                return parameters;
            }
        }


        public EveApiEntityRequest(IAccount account)
            : this(account.ApiData, account.RequestFrom)
        {
        }
        public EveApiEntityRequest(Account account, EveApiResourceFrom from) : base(account.UserID, account.ApiKey)
        {
            this.iCharacterID = account.CharacterID;
            this.iFrom = from;
        }

        protected override Uri Uri
        {
            get
            {
                return new Uri(
                    string.Format(
                    this.RequestUrlTemplate,
                    iFrom.StringValue(),
                    this.ResourceType.StringValue()));
            }
        }

        public abstract TOutput Request();
    }
}
