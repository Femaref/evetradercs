using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Xml.Linq;
using System.Reflection;
using ClassExtenders;

namespace EveTrader.Updater
{
    public static class ApplicationScanner
    {
        public static XDocument Scan (string path, bool compress)
        {
            DirectoryInfo di = new DirectoryInfo(path);
            if (!di.Exists)
                throw new DirectoryNotFoundException("Couldn't find specified directory: " + path);

            XDocument xd = new XDocument();

            List<UpdateFile> files = new List<UpdateFile>();

            foreach (FileInfo fi in di.GetFiles())
            {
                UpdateFile uf = new UpdateFile();

                uf.ChangeDate = fi.LastWriteTimeUtc;

                byte[] content = File.ReadAllBytes(fi.FullName);
                uf.Checksum = content.GetMD5Hash();
                uf.Compressed = compress;
                uf.Name = fi.Name;

                uf.RelativePath = compress ? new Uri(string.Format("{0}.gzip", fi.Name), UriKind.Relative) : new Uri(fi.Name, UriKind.Relative);

                if (Path.GetExtension(fi.Name) == "dll")
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

                    uf.Version = a.GetAttribute<AssemblyFileVersionAttribute>().Version;
                }
                else
                {
                    uf.TargetArchitecture = Architecture.Any;
                    uf.Version = "0.0";
                }
            }

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
