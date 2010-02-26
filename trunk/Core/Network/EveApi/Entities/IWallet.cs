﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Core.DomainModel;

namespace Core.Updaters
{
    public interface IWallet : IMarketOrder, IEntity
    {
        List<Wallet> Wallets { get; set; }
        new void BeforeUpdate();
        new void AfterUpdate();
    }
}
