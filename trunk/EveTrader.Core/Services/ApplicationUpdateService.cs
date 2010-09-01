using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel.Composition;
using System.IO;
using System.Net;
using System.Xml.Linq;
using System.Reflection;
using EveTrader.Core.ClassExtenders;

namespace EveTrader.Core.Services
{
    [Export(typeof(IApplicationUpdateService))]
    public class ApplicationUpdateService : IApplicationUpdateService
    {
        private IApplicationUpdateInfo iUpdateInfo;
        private Uri iBasePath;

        private List<UpdateFile> iFiles = new List<UpdateFile>();

        private object iUpdaterLock = new object();

        [ImportingConstructor]
        public ApplicationUpdateService(IApplicationUpdateInfo info)
        {
            this.iUpdateInfo = info;
            iBasePath = new Uri(info.BaseUri);
        }

        #region IApplicationUpdateService Members

        public IEnumerable<UpdateFile> CheckUpdate()
        {
            lock (iUpdaterLock)
            {
                iFiles.Clear();

                var assemblies = AppDomain.CurrentDomain.GetAssemblies();

                Uri binaryXmlPath;

                Uri.TryCreate(iBasePath, iUpdateInfo.BinaryUri, out binaryXmlPath);

                var files = ParseXml(binaryXmlPath);

                foreach (UpdateFile uf in files)
                {
                    Assembly currentAssembly = assemblies.Where(a => !a.IsDynamic && Path.GetFileName(a.Location) == uf.Name).SingleOrDefault();
                    string version = currentAssembly.GetAttribute<AssemblyFileVersionAttribute>().Version;

                    Version current = new Version(version);
                    Version target = new Version(uf.Version);

                    if (target > current)
                        iFiles.Add(uf);
                }

                return iFiles;
            }
        }

        private IEnumerable<UpdateFile> ParseXml(Uri binaryXmlPath)
        {
            XElement root = XElement.Parse(DownloadXml(binaryXmlPath));

            return new List<UpdateFile>();
        }

        private string DownloadXml(Uri xmlUri)
        {
            HttpWebRequest req = (HttpWebRequest)HttpWebRequest.Create(xmlUri);
            req.Method = "GET";
            req.UserAgent = "EveTrader";
            req.MediaType = "text/xml";

            using (HttpWebResponse res = (HttpWebResponse)req.GetResponse())
            using (StreamReader reader = new StreamReader(res.GetResponseStream()))
            {
                return reader.ReadToEnd();
            }
        }

        private byte[] DownloadBinary(Uri binaryUri)
        {
            HttpWebRequest req = (HttpWebRequest)HttpWebRequest.Create(binaryUri);
            req.Method = "GET";
            req.UserAgent = "EveTrader";
            req.MediaType = "text/xml";

            using (HttpWebResponse res = (HttpWebResponse)req.GetResponse())
            using (Stream s = res.GetResponseStream())
            {
                byte[] buffer = new byte[res.ContentLength];
                s.Read(buffer, 0, (int)res.ContentLength);
                return buffer;
            }
        }

        public void Update()
        {
            lock (iUpdaterLock)
            {
                DirectoryInfo tempPath = new DirectoryInfo(Path.Combine(Path.GetTempPath(), "EveTrader"));
                try
                {
                    if (!tempPath.Exists)
                        tempPath.Create();

                    foreach (UpdateFile uf in this.iFiles)
                    {
                        Uri binaryPath;
                        Uri.TryCreate(iBasePath, uf.RelativePath, out binaryPath);

                        byte[] data = DownloadBinary(binaryPath);

                        FileInfo filePath = new FileInfo(Path.Combine(tempPath.FullName, uf.Name));

                        using(FileStream fs = new FileStream(filePath.FullName, FileMode.Create))
                        using (BinaryWriter bw = new BinaryWriter(fs))
                        {
                            bw.Write(data);
                        }
                        string destPath = Path.Combine(this.iUpdateInfo.ApplicationPath, uf.Name);

                        filePath.MoveTo(destPath);
                    }
                }
                finally
                {
                    tempPath.Delete(true);
                }
            }
        }

        #endregion
    }
}
