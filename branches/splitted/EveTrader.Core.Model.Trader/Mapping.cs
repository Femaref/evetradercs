using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EveTrader.Core.Model.Trader
{
    //this should be auto generated together with the whole EveTrader.Core.Model.Trader.Dto project
    public static class Mapping
    {
        static Mapping()
        {
            AutoMapper.Mapper.CreateMap<RefTypes, RefTypesDto>();
            AutoMapper.Mapper.CreateMap<RefTypesDto, RefTypes>();
        }
    }
}
