using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EveTrader.Core.Network.Requests.Metrics
{
    public abstract class MetricsRequestBase<T> : RequestBase<T>
    {
        public MetricsRequestBase(MetricsRequestConstructor mrc, Func<string, TimeSpan, bool> stillCached, Action<string, DateTime, string> saveCache, Func<string, string> loadCache)
            : base(mrc, stillCached, saveCache, loadCache)
        {
        }


        protected override void OnError(string output)
        {
            throw new Exception("Error in metrics xml!");
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
