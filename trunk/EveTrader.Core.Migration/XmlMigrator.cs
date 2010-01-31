using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Xml.Linq;

namespace Core.Migration
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

            FileInfo fiBase = new FileInfo(this.iPathToXml);

            

            iWorkingDirectory = new FileInfo(Assembly.GetExecutingAssembly().Location).DirectoryName;

            Type migrationInterface = typeof (IXmlMigrationTarget);

            iMigrationTargets =
                new List<Type>(
                    from t in a.GetTypes().Where(tb => migrationInterface.IsAssignableFrom(tb))
                    let versionAttrib = t.GetCustomAttributes<TargetVersionAttribute>()
                    let fileAttrib = t.GetCustomAttributes<TargetFileAttribute>()
                    orderby versionAttrib.Single().FromVersion ascending
                    where versionAttrib.Count() == 1 && fileAttrib.Count() == 1 && fileAttrib.Single().Target == fiBase.Name
                    select t
                    );
        }
        public XmlMigrator(string pathToAssembly, string pathToXml)
            : this(Assembly.LoadFile(pathToAssembly), pathToXml)
        {
        }

        #region Overrides of MigratorBase

        public override bool MigrateUp()
        {
            XDocument root = XDocument.Load(this.iPathToXml);

            string rootNodeName = root.Root.Name.ToString();

            Version baseVersion = new Version(root.Element(rootNodeName).Element("Version").Value);

            Version min =
                iMigrationTargets.Min(t => t.GetCustomAttributes<TargetVersionAttribute>(false).Single().FromVersion);
            Version max =
                iMigrationTargets.Max(t => t.GetCustomAttributes<TargetVersionAttribute>(false).Single().ToVersion);

            if (baseVersion >= max)
                return true;
            if(baseVersion < min)
                return false;

            iMigrationTargets.RemoveAll(
                t => baseVersion > t.GetCustomAttributes<TargetVersionAttribute>(false).Single().FromVersion);

            Queue<Type> queue =
                new Queue<Type>(
                    iMigrationTargets.OrderBy(
                        t => t.GetCustomAttributes<TargetVersionAttribute>(false).Single().FromVersion));

            while (queue.Count > 0)
            {
                Type currentTypeItem = queue.Dequeue();
                Version currentVersion =
                    currentTypeItem.GetCustomAttributes<TargetVersionAttribute>(false).Single().FromVersion;
                Version toVersion =
                    currentTypeItem.GetCustomAttributes<TargetVersionAttribute>(false).Single().ToVersion;
                if (currentVersion == baseVersion)
                {
                    root.Save(Path.Combine(iWorkingDirectory, "backup_pre_" + currentTypeItem.Name + ".xml"));

                    IXmlMigrationTarget currentItem = (Activator.CreateInstance(currentTypeItem) as IXmlMigrationTarget);

                    if (!currentItem.Upgrade(root))
                    {
                        return false;
                    }
                    root.Save(Path.Combine(iWorkingDirectory, "backup_post_" + currentTypeItem.Name + ".xml"));

                    baseVersion = toVersion;
                    root.Element("EveTrader").Element("Version").Value = baseVersion.ToString();
                }
            }

            if(baseVersion == max)
            {
                root.Save(this.iPathToXml);
                DirectoryInfo di = new DirectoryInfo(this.iWorkingDirectory);
                FileInfo[] backups = di.GetFiles("backup*.xml");
                backups.ToList().ForEach(fi => fi.Delete());
                return true;
            }
            return false;
        }

        public override bool MigrateDown()
        {
            throw new NotImplementedException();
        }

        #endregion
    }
}