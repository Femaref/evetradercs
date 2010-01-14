using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Core.DomainModel
{
    public class Alliance : IGenericObject<Alliance>
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Ticker { get; set;}
        public int ExecutorCorpID { get; set; }
        public int MemberCount { get; set; }
        public DateTime StartDate { get; set; }


        #region Implementation of IGenericObject<Alliance>

        public IEqualityComparer<Alliance> GetComparer()
        {
            return new AllianceComparer();
        }

        #endregion
    }
}
