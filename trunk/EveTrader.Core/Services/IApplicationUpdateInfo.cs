﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EveTrader.Core.Services
{
    public interface IApplicationUpdateInfo
    {
        string BaseUri { get; }
        string BinaryUri { get; }
        string StaticUri { get; }
    }
}
