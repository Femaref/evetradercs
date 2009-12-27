using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Xml.Serialization;

namespace EveTrader.Helpers
{
    abstract public class XmlSettingsFile<T> : Singleton<T> where T:new()
    {
        protected  abstract string fileName { get; }

        private string folder
        {
            get
            {
                return Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), @"EveTrader");
            }
        }
        private string filePath
        {
            get
            {
                return Path.Combine(folder, this.fileName);
            }
        }

        public void Save()
        {
            
            if (!Directory.Exists(this.folder))
            {
                Directory.CreateDirectory(folder);
            }

            this.Save(filePath);
        }
        public void Save(string saveToFile)
        {
            BeforeSave();
            string backup = File.ReadAllText(saveToFile);
            try
            {
                using (FileStream fileStream = new FileStream(saveToFile, FileMode.Create, FileAccess.Write))
                {
                    XmlSerializer xmlSerializer = new XmlSerializer(typeof (T));
                    xmlSerializer.Serialize(fileStream, Instance);
                }
            }
            catch (Exception)
            {
                File.WriteAllText(saveToFile, backup);
                throw;
            }
            AfterSave();
        }

        protected abstract void BeforeSave();
        protected abstract void AfterSave();

        public void Load()
        {            
            try
            {
                this.Load(filePath);
            }
            catch
            {
                Instance = new T();
            }
        }
        public void Load(string loadFromFile)
        {
            BeforeLoad();
            using (FileStream fileStream = new FileStream(loadFromFile, FileMode.Open, FileAccess.Read))
            {
                XmlSerializer xmlSerializer = new XmlSerializer(typeof(T));
                Instance = (T) xmlSerializer.Deserialize(fileStream);
            }
            AfterLoad();
        }

        protected abstract void BeforeLoad();
        protected abstract void AfterLoad();
    }
}
