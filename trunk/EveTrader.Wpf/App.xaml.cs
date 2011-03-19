using System;
using System.ComponentModel.Composition;
using System.ComponentModel.Composition.Hosting;
using System.Data.EntityClient;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Waf.Applications;
using System.Windows;
using System.Windows.Threading;
using EveTrader.Core.Controllers;
using EveTrader.Core.Model;
using EveTrader.Core.Model.Metric;
using EveTrader.Core.Model.Trader;
using EveTrader.Core.Services;

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
            System.Waf.WafConfiguration.Debug = true;
#endif
        }

        protected override void OnStartup(StartupEventArgs e)
        {
            
#if (!DEBUG)
            // Don't handle the exceptions in Debug mode because otherwise the Debugger wouldn't
            // jump into the code when an exception occurs.
            DispatcherUnhandledException += AppDispatcherUnhandledException;
            AppDomain.CurrentDomain.UnhandledException += AppDomainUnhandledException;
#endif
            string commandLine = e.Args.FirstOrDefault();
            string optional = "";
            if (commandLine != null)
            {
                FileInfo parsedCommandLine = new FileInfo(commandLine);

                if (parsedCommandLine.Exists && parsedCommandLine.Extension == ".db")
                    optional = parsedCommandLine.FullName;
            }

            
            DirectoryInfo appData = new DirectoryInfo(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "EveTrader")); // custom files root
            FileInfo databaseInfo = new FileInfo(optional == "" ? Path.Combine(appData.FullName, "EveTrader.db") : optional); // standard/custom path to db
            FileInfo metricsInfo = new FileInfo(Path.Combine(appData.FullName, "Metrics.db")); // path to metrics price data
            FileInfo settingsInfo = new FileInfo(Path.Combine(appData.FullName, "settings.xml")); // path to old data
            FileInfo staticDatabase = new FileInfo(Path.Combine(appData.FullName, "static.db")); //path to static data
            FileInfo staticDatabaseRessource = new FileInfo("static.db"); // path to current load of static data
            

            if (!appData.Exists)
                appData.Create();

            //copy over static.db
            if (!staticDatabase.Exists)
                File.Copy(staticDatabaseRessource.FullName, staticDatabase.FullName);

            base.OnStartup(e);



            Stopwatch sw = new Stopwatch();
            sw.Start();

            AggregateCatalog catalog = new AggregateCatalog();
            // Add the WpfApplicationFramework assembly to the catalog
            catalog.Catalogs.Add(new AssemblyCatalog(typeof(Controller).Assembly));


            //EveTrader.Wpf.exe
            catalog.Catalogs.Add(new AssemblyCatalog(Assembly.GetExecutingAssembly()));


            //add all EveTrader.*.dll
            DirectoryCatalog dc = new DirectoryCatalog(System.AppDomain.CurrentDomain.BaseDirectory, "EveTrader.*.dll");

            catalog.Catalogs.Add(dc);

            CompositionContainer container = new CompositionContainer(catalog);
            CompositionBatch batch = new CompositionBatch();


            batch.AddExportedValue(container);

            //set actual paths to the database files
            container.GetExportedValue<IConnectionStringProvider>("TraderModelConnectionString").SetSource(databaseInfo.FullName);
            container.GetExportedValue<IConnectionStringProvider>("StaticModelConnectionString").SetSource(staticDatabase.FullName);
            container.GetExportedValue<IConnectionStringProvider>("MetricModelConnectionString").SetSource(metricsInfo.FullName);

            container.Compose(batch);

            var mappings = container.GetExportedValues<IMappingCreator>();

            foreach (IMappingCreator mc in mappings)
            {
                mc.CreateMappings();
            }
            container.GetExportedValue<TraderModel>().Prune();
            try
            {
                controller = container.GetExportedValue<ApplicationController>();

                sw.Stop();
                Debug.WriteLine(sw.Elapsed.TotalSeconds);
                controller.Run();
            }
            catch (Exception exc)
            {
                HandleException(exc, false);

                this.Shutdown();
            }
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

            DirectoryInfo myDoc = new DirectoryInfo(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "EveTrader"));

            if (!myDoc.Exists)
                myDoc.Create();

            string filePath = Path.Combine(myDoc.FullName, string.Format("{0}.log", DateTime.UtcNow.ToFileTimeUtc()));
            File.WriteAllText(filePath, e.ToString());

            if (!isTerminating)
            {
                //ExceptionDisplay ed = new ExceptionDisplay();
                //ed.Current = e;
                //ed.ShowDialog();
            }
        }
    }
}