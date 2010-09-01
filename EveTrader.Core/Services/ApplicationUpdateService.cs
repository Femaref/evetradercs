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

        [ImportingConstructor]
        public ApplicationUpdateService(IApplicationUpdateInfo info)
        {
            this.iUpdateInfo = info;
            iBasePath = new Uri(info.BaseUri);
        }

        #region IApplicationUpdateService Members

        public IEnumerable<UpdateFile> CheckUpdate()
        {
            List<UpdateFile> output = new List<UpdateFile>();

            var assemblies = AppDomain.CurrentDomain.GetAssemblies();

            Uri binaryXmlPath;

            Uri.TryCreate(iBasePath, iUpdateInfo.BinaryUri, out binaryXmlPath);

            var ass = assemblies.Where(a => !a.IsDynamic && Path.GetFileName(a.Location) == "EveTrader.Wpf.exe").SingleOrDefault();

            var files = ParseXml(binaryXmlPath);

            foreach (UpdateFile uf in files)
            {
                Assembly currentAssembly = assemblies.Where(a => !a.IsDynamic && Path.GetFileName(a.Location) == uf.Name).SingleOrDefault();
                string version = currentAssembly.GetAttribute<AssemblyFileVersionAttribute>().Version;

                Version current = new Version(version);
                Version target = new Version(uf.Version);

                if (target > current)
                    output.Add(uf);
            }

            return output;
        }

        private IEnumerable<UpdateFile> ParseXml(Uri binaryXmlPath)
        {
            XElement root = XElement.Parse(DownloadXml(binaryXmlPath));

            return new List<UpdateFile>();
        }

        private string DownloadXml(Uri binaryXmlPath)
        {
            HttpWebRequest req = (HttpWebRequest)HttpWebRequest.Create(binaryXmlPath);
            req.Method = "GET";
            req.UserAgent = "EveTrader";
            req.MediaType = "text/xml";

            using (HttpWebResponse res = (HttpWebResponse)req.GetResponse())
            using (StreamReader reader = new StreamReader(res.GetResponseStream()))
            {
                    return reader.ReadToEnd();
            }
        }

        public void Update()
        {
        }

        #endregion
    }
}
