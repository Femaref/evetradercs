using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel.Composition;
using System.Data.EntityClient;
using System.IO;
using System.Data.SQLite;

namespace EveTrader.Core.Model.Metric
{
    [PartCreationPolicy(System.ComponentModel.Composition.CreationPolicy.Any)]
    [Export(typeof(MetricModel))]
    public partial class MetricModel
    {
        [ImportingConstructor]
        public MetricModel([Import("MetricsModelConnection")] EntityConnectionStringBuilder sb)
            : base(new EntityConnection(sb.ToString()), "TraderModel")
        {
            this.ContextOptions.LazyLoadingEnabled = true;
            OnContextCreated();
        }

     
        public bool StillCached(string requestString, TimeSpan cachingTimer)
        {
            var cache = this.Cache.Where(c => c.RequestString == requestString).FirstOrDefault();
            if (cache == null)
                return false;
            //RequestDate + cachingTimer has to be later than UtcNow for the document to still be cached
            return (cache.RequestDate + cachingTimer) > DateTime.UtcNow;
        }

        public void SaveCache(string requestString, DateTime requestDate, string data)
        {
            var cache = this.Cache.Where(c => c.RequestString == requestString).FirstOrDefault();
            if (cache == null)
            {
                cache = new Cache() { RequestString = requestString };
                this.Cache.AddObject(cache);
            }
            cache.RequestDate = requestDate;
            cache.Data = data;
            this.SaveChanges();
        }

        public string LoadCache(string requestString)
        {
            var cache = this.Cache.Where(c => c.RequestString == requestString).FirstOrDefault();
            return cache != null ? cache.Data : "";
        }

        public new static string CreateDatabase()
        {
            return CreateDatabase(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "EveTrader", "Metrics.db"));
        }
        public static string CreateDatabase(string path)
        {
            FileInfo fi = new FileInfo(path);

            if (!fi.Exists || fi.Length == 0)
            {
                string connection = string.Format("Data Source={0};Version=3;", path);
                string db_schema = Properties.Resources.metrictables;

                using (SQLiteConnection cn = new SQLiteConnection(connection))
                {
                    using (SQLiteCommand cmd = cn.CreateCommand())
                    {
                        cmd.CommandText = db_schema;
                        cmd.CommandType = System.Data.CommandType.Text;
                        cn.Open();
                        cmd.ExecuteNonQuery();
                    }
                }
            }
            return path;
        }
    }
}
