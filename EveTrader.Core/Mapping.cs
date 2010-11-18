using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EveTrader.Core.Services;
using EveTrader.Core.Model.Trader;
using System.ComponentModel.Composition;

namespace EveTrader.Core
{
    [Export(typeof(IMappingCreator))]
    public class Mapping : IMappingCreator
    {
        public void CreateMappings()
        {
            AutoMapper.Mapper.CreateMap<RefTypes, RefTypesDto>();
            AutoMapper.Mapper.CreateMap<RefTypesDto, RefTypes>();
        }
    }
}
