using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Core.DomainModel;

namespace Core.Network.EveApi.Entities
{
    public interface IWallet : IMarketOrder, IEntity, IGenericObject
    {
        List<Wallet> Wallets { get; set; }
        new void BeforeUpdate();
        new void AfterUpdate();
    }
}