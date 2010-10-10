using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AutoMapper;
using EveTrader.Core.Model;

namespace EveTrader.Core
{
    internal static class Mapping
    {
        internal static void CreateMappings()
        {
            Mapper.CreateMap<Journal, DisplayJournal>();
        }
    }
}
