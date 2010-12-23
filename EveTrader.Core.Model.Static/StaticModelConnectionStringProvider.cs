using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel.Composition;
using System.Data.EntityClient;
using System.Data.SQLite;

namespace EveTrader.Core.Model.Static
{
    [Export("StaticModelConnectionString", typeof(IConnectionStringProvider))]
    public class StaticModelConnectionStringProvider : IConnectionStringProvider
    {
        private string metadata = @"res://*/StaticModel.csdl|res://*/StaticModel.ssdl|res://*/StaticModel.msl";
        private string source = "";


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

            return entityBuilder;
        }


        public void SetSource(string source)
        {
            this.source = source;
        }
    }
}
