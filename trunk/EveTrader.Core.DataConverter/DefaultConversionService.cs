using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using EveTrader.Core.Services;
using System.ComponentModel.Composition;
using EveTrader.Core.DataConverter;

namespace EveTrader.Core.DataConverter.Services
{
    [Export(typeof(IConversionService))]
    public class DefaultConversionService : IConversionService
    {
        private FileInfo path = new FileInfo(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "EveTrader", "settings.xml"));
        private XmlToSqlite xts;

        public DefaultConversionService()
        {
            if(path.Exists && path.Length > 0)
                xts = new XmlToSqlite(path.FullName);
        }

        public bool ConversionNecessary()
        {
            return (path.Exists && path.Length > 0);
        }

        public bool Convert()
        {
            try
            {
                if (xts == null)
                    throw new Exception("no file to convert");

                DirectoryInfo appData = new DirectoryInfo(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "EveTrader"));

                string fileTime = DateTime.Now.ToFileTime().ToString();
                string backupPath = string.Format("backup_{0}", fileTime);

                if (!Directory.Exists(Path.Combine(appData.FullName, backupPath)))
                    appData.CreateSubdirectory(backupPath);

                File.Copy(path.FullName, Path.Combine(appData.FullName, backupPath, "settings.xml"));

                return xts.Convert();
            }
            finally
            {
                path.Delete();
            }
        }

        public event EventHandler<ValueIncreasedEventArgs> CurrentObjectIncreased
        {
            add { xts.CurrentObjectIncreased += value; }
            remove { xts.CurrentObjectIncreased -= value; }
        }
        public event EventHandler<ValueIncreasedEventArgs> ObjectsIncreased
        {
            add { xts.ObjectsIncreased += value; }
            remove { xts.ObjectsIncreased -= value; }
        }
        public event EventHandler OperationFinished
        {
            add { xts.OperationFinished += value; }
            remove { xts.OperationFinished -= value; }
        }
    }
}