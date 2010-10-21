using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EveTrader.Core.Model.Trader;
using System.ComponentModel.Composition;
using EveTrader.Core.Collections;
using System.Threading;

namespace EveTrader.Core.Services
{
    [Export(typeof(ICachedPriceUpdaterService))]
    public class CachedPriceUpdaterService : ICachedPriceUpdaterService
    {
        private readonly TraderModel iModel;
        private readonly object iUpdater = new object();
        private readonly SyncQueue<long> iQueue;
        private bool iStop = false;

        [ImportingConstructor]
        public CachedPriceUpdaterService([Import(RequiredCreationPolicy = CreationPolicy.Shared)] TraderModel tm)
        {
            iModel = tm;
            iQueue = new SyncQueue<long>();

            ThreadStart ts = new ThreadStart(Worker);
            Thread worker = new Thread(ts);
            worker.Name = "CachedPriceUpdaterService Worker";

           // worker.Start();
        }


        #region ICachedPriceUpdaterService Members

        public void Update(long typeID)
        {
            iQueue.Enqueue(typeID);
        }

        private void Worker()
        {
            while (!iStop)
            {
                lock (iUpdater)
                {
                    long i = iQueue.Dequeue();

                    CachedPriceInfos cpi = null;
                    if (iModel.CachedPriceInfo.Count(c => c.TypeID == i) == 0)
                    {
                        cpi = new CachedPriceInfos() { TypeID = i };
                        iModel.CachedPriceInfo.AddObject(cpi);
                    }
                    else
                        cpi = iModel.CachedPriceInfo.First(c => c.TypeID == i);

                    var buyQuery = iModel.Transactions.Where(t => t.TypeID == i && t.TransactionType == (long)TransactionType.Buy).OrderByDescending(t => t.DateTime).Take(10);
                    cpi.BuyPrice = buyQuery.Count() > 0 ? buyQuery.Average(t => t.Price) : 0m;
                    var sellQuery = iModel.Transactions.Where(t => t.TypeID == i && t.TransactionType == (long)TransactionType.Sell).OrderByDescending(t => t.DateTime).Take(10);
                    cpi.SellPrice = sellQuery.Count() > 0 ? sellQuery.Average(t => t.Price) : 0m;

                    iModel.WriteToLog(string.Format("Updated average prices for typeID {0}", cpi.TypeID), "CachedPriceUpdaterService.Worker()");

                    iModel.SaveChanges();
                }
            }
        }

        public void Update(IEnumerable<long> typeIDs)
        {
            foreach (long i in typeIDs)
            {
                iQueue.Enqueue(i);
            }
        }

        #endregion
    }
}
