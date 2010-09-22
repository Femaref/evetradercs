using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel.Composition;
using System.IO;
using System.Net;
using System.Xml.Linq;
using System.Reflection;
using ClassExtenders;
using EveTrader.Updater;

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
                    FileInfo currentFile = new FileInfo(currentAssembly.Location);

                    if (currentAssembly == null)
                    {
                        iFiles.Add(uf);
                        continue;
                    }

                    string version = currentAssembly.GetAttribute<AssemblyFileVersionAttribute>().Version;

                    Version current = new Version(version);
                    Version target = new Version(uf.Version);

                    if (target > current || currentFile.LastWriteTimeUtc > uf.ChangeDate)
                        iFiles.Add(uf);
                }

                return iFiles;
            }
        }

        private IEnumerable<UpdateFile> ParseXml(Uri binaryXmlPath)
        {
            XElement root = XElement.Parse(DownloadXml(binaryXmlPath));

            return root.Elements().Select(x => new UpdateFile
                {
                     Name = x.Attribute("name").Value,
                     Checksum = x.Attribute("checksum").Value,
                     Compressed = bool.Parse(x.Attribute("compressed").Value),
                     RelativePath = new Uri(x.Attribute("relativeUri").Value, UriKind.Relative),
                     TargetArchitecture = (Architecture)Enum.Parse(typeof(Architecture), x.Attribute("targetArchitecture").Value),
                     Version = x.Attribute("version").Value
                });
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
            req.MediaType = "application/octet-stream";

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

                        byte[] payload = DownloadBinary(binaryPath);
                        int tries = 0;
                        while(uf.Checksum != payload.GetMD5Hash())
                        {
                            if (tries >= 5)
                                throw new Exception("Checksum failed for file " + uf.Name); //TODO: better exception

                            payload = DownloadBinary(binaryPath);

                            tries++;
                        }

                        byte[] data = null;
                        if (uf.Compressed)
                            data = Gzip.Decompress(DownloadBinary(binaryPath));
                        else
                            data = DownloadBinary(binaryPath);

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
