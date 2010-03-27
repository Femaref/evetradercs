using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Core.DomainModel;

namespace Core.Network.EveApi.Entities
{
    public interface IStanding : IEntity
    {
        List<Standing> Standings { get; set; }
        DateTime NextStandingUpdateTime { get; set; }
    }
}
