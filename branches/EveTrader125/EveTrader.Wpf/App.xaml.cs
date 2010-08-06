using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Windows;
using System.Reflection;
using EveTrader.Core.Controllers;
using System.ComponentModel.Composition;
using System.ComponentModel.Composition.Hosting;
using System.Waf.Applications;
using System.Windows.Threading;
using System.Diagnostics;
using System.Waf;
using EveTrader.Core.DataConverter;
using System.IO;
using EveTrader.Core.Model;
using System.Data.SQLite;
using System.Data.EntityClient;

namespace EveTrader.Wpf
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        ApplicationController controller;

        static App()
        {
#if (DEBUG)
            WafConfiguration.Debug = true;
#endif
        }

        protected override void OnStartup(StartupEventArgs e)
        {

#if (DEBUG != true)
            // Don't handle the exceptions in Debug mode because otherwise the Debugger wouldn't
            // jump into the code when an exception occurs.
            DispatcherUnhandledException += AppDispatcherUnhandledException;
            AppDomain.CurrentDomain.UnhandledException += AppDomainUnhandledException;
#endif
            FileInfo fi = new FileInfo(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "EveTrader", "EveTrader.db"));

            if (!fi.Exists || fi.Length == 0)
                TraderModel.CreateDatabase(fi.FullName);

            SQLiteConnectionStringBuilder traderModelSqliteBuilder = new SQLiteConnectionStringBuilder();
            traderModelSqliteBuilder.DataSource = fi.FullName;

            EntityConnectionStringBuilder traderModelEntityBuilder = new EntityConnectionStringBuilder();
            traderModelEntityBuilder.Provider = "System.Data.SQLite";
            traderModelEntityBuilder.ProviderConnectionString = traderModelSqliteBuilder.ToString();
            traderModelEntityBuilder.Metadata = @"res://*/Model.TraderModel.csdl|res://*/Model.TraderModel.ssdl|res://*/Model.TraderModel.msl";

            TraderModel tm = new TraderModel(traderModelEntityBuilder);
            tm.Prune();
            tm.MetadataWorkspace.LoadFromAssembly(typeof(TraderModel).Assembly);
            tm.Dispose();

            FileInfo si = new FileInfo(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "EveTrader", "static.db"));

            SQLiteConnectionStringBuilder staticModelSqliteBuilder = new SQLiteConnectionStringBuilder();
            staticModelSqliteBuilder.DataSource = si.FullName;

            EntityConnectionStringBuilder staticModelEntityBuilder = new EntityConnectionStringBuilder();
            staticModelEntityBuilder.Provider = "System.Data.SQLite";
            staticModelEntityBuilder.ProviderConnectionString = staticModelSqliteBuilder.ToString();
            staticModelEntityBuilder.Metadata = @"res://*/Model.StaticModel.csdl|res://*/Model.StaticModel.ssdl|res://*/Model.StaticModel.msl";


            base.OnStartup(e);
            Stopwatch sw = new Stopwatch();
            sw.Start();
            AggregateCatalog catalog = new AggregateCatalog();
            // Add the WpfApplicationFramework assembly to the catalog
            catalog.Catalogs.Add(new AssemblyCatalog(typeof(Controller).Assembly));
            // Add Frontend Assembly
            catalog.Catalogs.Add(new AssemblyCatalog(Assembly.GetExecutingAssembly()));
            // Add EveTrader.Core
            catalog.Catalogs.Add(new AssemblyCatalog(typeof(ApplicationController).Assembly));

            CompositionContainer container = new CompositionContainer(catalog);
            CompositionBatch batch = new CompositionBatch();


            batch.AddExportedValue(container);
            batch.AddExportedValue("TraderModelConnection", traderModelEntityBuilder);
            batch.AddExportedValue("StaticModelConnection", staticModelEntityBuilder);
            container.Compose(batch);
            
            controller = container.GetExportedValue<ApplicationController>();
            sw.Stop();
            Debug.WriteLine(sw.Elapsed.TotalSeconds);
            controller.Run();
        }

        protected override void OnExit(ExitEventArgs e)
        {
            controller.Shutdown();
            base.OnExit(e);
        }

        private void AppDispatcherUnhandledException(object sender, DispatcherUnhandledExceptionEventArgs e)
        {
            HandleException(e.Exception, false);
            e.Handled = true;
        }

        private static void AppDomainUnhandledException(object sender, UnhandledExceptionEventArgs e)
        {
            HandleException(e.ExceptionObject as Exception, e.IsTerminating);
        }

        private static void HandleException(Exception e, bool isTerminating)
        {
            if (e == null) { return; }

            Trace.TraceError(e.ToString());

            if (!isTerminating)
            {
                
            }
        }
    }
}