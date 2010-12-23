using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AutoMapper;
using EveTrader.Core.Model.Trader;
using EveTrader.Core.Services;
using System.ComponentModel.Composition;

namespace EveTrader.Core
{
    [Export(typeof(IMappingCreator))]
    public class Mapping : IMappingCreator
    {
        private readonly IRefTypesLookup iRefTypesLookup;


        [ImportingConstructor]
        public Mapping(IRefTypesLookup rtl)
        {
            iRefTypesLookup = rtl;
        }

        public void CreateMappings()
        {
            Mapper.CreateMap<Journal, DisplayJournal>().AfterMap((j, dj) => dj.RefTypeName = iRefTypesLookup.Lookup(j.RefTypeID));
        }
    }
}
