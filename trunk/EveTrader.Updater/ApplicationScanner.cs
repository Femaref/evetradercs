using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Xml.Linq;
using System.Reflection;
using ClassExtenders;
using MoreLinq;

namespace EveTrader.Updater
{
    public static class ApplicationScanner
    {
        public static IEnumerable<UpdateFile> Scan (string path, bool compress, Dictionary<string, string> customVersion, params string[] extensionFilter)
        {
            DirectoryInfo di = new DirectoryInfo(path);
            if (!di.Exists)
                throw new DirectoryNotFoundException("Couldn't find specified directory: " + path);

            for (int i = 0; i < extensionFilter.Length; i++)
            {
                if (extensionFilter[i][0] != '.')
                    extensionFilter[i] = "." + extensionFilter[i];
            }

            List<UpdateFile> files = new List<UpdateFile>();

            foreach (FileInfo fi in di.GetFiles())
            {
                if (!extensionFilter.Contains(fi.Extension))
                    continue;

                UpdateFile uf = new UpdateFile();

                uf.ChangeDate = fi.LastWriteTimeUtc;

                byte[] content = File.ReadAllBytes(fi.FullName);
                uf.Compressed = compress;
                uf.Name = fi.Name;
                uf.Checksum = compress ? "0" : content.GetMD5Hash();

                uf.RelativePath = compress ? new Uri(string.Format("{0}.gzip", fi.Name), UriKind.Relative) : new Uri(fi.Name, UriKind.Relative);

                if (Path.GetExtension(fi.Name) == ".dll")
                {
                    Assembly a = Assembly.ReflectionOnlyLoadFrom(fi.FullName);

                    PortableExecutableKinds pek;
                    ImageFileMachine ifm;

                    a.ManifestModule.GetPEKind(out pek, out ifm);
                    try
                    {
                        uf.TargetArchitecture = DetermineArchitecture(pek);
                    }
                    catch (Exception ex)
                    {
                        throw new BadImageFormatException("Assembly " + fi.Name + " is invalid", ex);
                    }

                    if (uf.TargetArchitecture != Architecture.Any)
                    {
                        var data = a.GetCustomAttributesData();
                        var custom = data.FirstOrDefault(d => d.ToString().Contains("AssemblyFileVersionAttribute"));
                        uf.Version = (string)custom.ConstructorArguments.First().Value;
                    }
                    else
                    {
                        a = Assembly.LoadFrom(fi.FullName);
                        uf.Version = a.GetAttribute<AssemblyFileVersionAttribute>().Version;
                    }
                }
                else
                {
                    uf.TargetArchitecture = Architecture.Any;
                    uf.Version = customVersion.ContainsKey(uf.Name) ?  customVersion[uf.Name] : "0.0";
                }

                files.Add(uf);
            }



            return files;
        }

        public static XDocument CreateVersionInfo (IEnumerable<UpdateFile> files)
        {
            XDocument xd = new XDocument(new XDeclaration("1.0", "utf-8", "no"));

            XElement xe = new XElement("UpdateFiles", files.Select(
                uf => 
                    new XElement("UpdateFile", 
                        new XAttribute("name", uf.Name), 
                        new XAttribute("version", uf.Version))));

            xd.Add(xe);

            return xd;
        }

        public static XDocument CreateServerInfo(IEnumerable<UpdateFile> files)
        {
            XDocument xd = new XDocument(new XDeclaration("1.0", "utf-8", "no"));

            XElement root = new XElement("UpdateFiles");

            foreach (UpdateFile uf in files)
            {
                XElement xe = new XElement("UpdateFile");
                foreach (PropertyInfo pi in typeof(UpdateFile).GetProperties())
                {
                    xe.Add(new XAttribute(pi.Name, pi.GetValue(uf, null)));
                }
                root.Add(xe);
            }
            xd.Add(root);
            return xd;
        }

        private static Architecture DetermineArchitecture(PortableExecutableKinds pek)
        {
            if (pek == PortableExecutableKinds.ILOnly)
                return Architecture.Any;
            else if (pek == PortableExecutableKinds.Required32Bit)
                return Architecture.x86;
            else if (pek == PortableExecutableKinds.PE32Plus)
                return Architecture.x64;
            else
                throw new Exception("Assembly is invalid");
        }
    }
}
