using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EveTrader.Core.Network.Requests.Central
{
    public abstract class CentralRequestBase<T> : RequestBase<T>
    {

        public CentralRequestBase(CentralRequestConstructor rc,
            Func<string, TimeSpan, bool> stillCached,
            Action<string, DateTime, string> saveCache,
            Func<string, string> loadCache)
            : base(rc, stillCached, saveCache, loadCache)
        {
        }


        protected override void OnError(string output)
        {
            throw new Exception("Error in a request to eve central!");
        }

        protected override void SaveCache(string content)
        {
            this.SaveCache(DateTime.UtcNow, content);
        }

        protected override bool ContainsError(string output)
        {
            return false;
        }
    }
}
