using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.EntityClient;
using System.ComponentModel.Composition;
using System.Data.SQLite;
using System.IO;

namespace EveTrader.Core.Model.Metric
{
    [Export("MetricModelConnectionString", typeof(IConnectionStringProvider))]
    public class MetricModelConnectionStringProvider : IConnectionStringProvider
    {
        private string metadata = @"res://*/MetricModel.csdl|res://*/MetricModel.ssdl|res://*/MetricModel.msl";
        private string source = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "EveTrader", "Metrics.db");


        public string GetConnectionString()
        {
            return CreateConnectionBuilder().ToString();
        }

        private EntityConnectionStringBuilder CreateConnectionBuilder()
        {
            SQLiteConnectionStringBuilder sqliteBuilder = new SQLiteConnectionStringBuilder();
            sqliteBuilder.DataSource = source;

            EntityConnectionStringBuilder entityBuilder = new EntityConnectionStringBuilder();
            entityBuilder.Provider = "System.Data.SQLite";
            entityBuilder.ProviderConnectionString = sqliteBuilder.ToString();
            entityBuilder.Metadata = metadata;

            FileInfo fi = new FileInfo(source);
            if (!fi.Exists || fi.Length == 0)
                MetricModel.CreateDatabase(source);

            return entityBuilder;
        }


        public void SetSource(string source)
        {
            this.source = source;
        }
    }
}
