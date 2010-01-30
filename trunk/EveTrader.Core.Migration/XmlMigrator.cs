using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Xml.Linq;

namespace EveTrader.Core.Migration
{
    public class XmlMigrator : MigratorBase
    {
        private List<Type> iMigrationTargets;
        private string iPathToXml;
        private Type iMigrationInterface = typeof(IXmlMigrationTarget);
        private string iWorkingDirectory;

        public XmlMigrator(Assembly a, string pathToXml)
        {
            iPathToXml = pathToXml;

            iWorkingDirectory = new FileInfo(Assembly.GetExecutingAssembly().Location).DirectoryName;

            Type migrationInterface = typeof (IXmlMigrationTarget);

            iMigrationTargets =
                new List<Type>(
                    from t in a.GetTypes().Where(tb => migrationInterface.IsAssignableFrom(tb))
                    let attrib = t.GetCustomAttributes<TargetVersionAttribute>()
                    orderby attrib.Single().FromVersion ascending
                    where attrib.Count() == 1
                    select t
                    );
        }

        public XmlMigrator(string pathToAssembly, string pathToXml)
            : this(Assembly.LoadFile(pathToAssembly), pathToXml)
        {
        }


        #region Overrides of MigratorBase

        public override bool Migrate()
        {
            XDocument root = XDocument.Load(this.iPathToXml);

            Version baseVersion = new Version(root.Element("EveTrader").Element("Version").Value);

            Version min =
                iMigrationTargets.Min(t => t.GetCustomAttributes<TargetVersionAttribute>(false).Single().FromVersion);
            Version max =
                iMigrationTargets.Max(t => t.GetCustomAttributes<TargetVersionAttribute>(false).Single().ToVersion);

            if (baseVersion < min || baseVersion >= max)
                return false;

            iMigrationTargets.RemoveAll(
                t => baseVersion > t.GetCustomAttributes<TargetVersionAttribute>(false).Single().FromVersion);

            Queue<Type> queue =
                new Queue<Type>(
                    iMigrationTargets.OrderBy(
                        t => t.GetCustomAttributes<TargetVersionAttribute>(false).Single().FromVersion));

            while(queue.Count > 0)
            {
                Type currentTypeItem = queue.Dequeue();
                Version currentVersion =
                    currentTypeItem.GetCustomAttributes<TargetVersionAttribute>(false).Single().FromVersion;
                Version toVersion =
    currentTypeItem.GetCustomAttributes<TargetVersionAttribute>(false).Single().ToVersion;
                if (currentVersion == baseVersion)
                {
                    root.Save(Path.Combine(iWorkingDirectory,"backup_pre_" + currentTypeItem.Name + ".xml"));

                    IXmlMigrationTarget currentItem = (Activator.CreateInstance(currentTypeItem) as IXmlMigrationTarget);

                    if(!currentItem.Upgrade(root))
                    {
                        File.Copy(Path.Combine(iWorkingDirectory, "backup_pre_" + currentTypeItem.Name + ".xml"),
                                               this.iPathToXml);
                        return false;
                    }
                    root.Save(Path.Combine(iWorkingDirectory, "backup_post_" + currentTypeItem.Name + ".xml"));

                    baseVersion = toVersion;
                }
            }





            return true;
        }

        #endregion
    }
}
