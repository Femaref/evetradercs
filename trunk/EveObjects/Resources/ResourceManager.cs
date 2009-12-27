using System.IO;
using System.IO.Compression;
using System.Xml.Linq;

namespace EveObjects.Resources
{
    internal class ResourceManager
    {
        private const string cacheFolderName = "Cache";

        public static XDocument Types
        {
            get
            {
                return GetXDocumentFromCache("EveTypes.xml", ResourceProvider.EveTypes);
            }
        }
        public static XDocument Stations
        {
            get
            {
                return GetXDocumentFromCache("EveStations.xml", ResourceProvider.EveStations);
            }
        }
        public static XDocument SolarSystems
        {
            get
            {
                return GetXDocumentFromCache("EveSolarSystems.xml", ResourceProvider.EveSolarSystems);
            }
        }
        public static XDocument SolarSystemJumps
        {
            get
            {
                return GetXDocumentFromCache("EveSolarSystemJumps.xml", ResourceProvider.EveSolarSystemJumps);
            }
        }
        public static XDocument Constellations
        {
            get
            {
                return GetXDocumentFromCache("EveConstellations.xml", ResourceProvider.EveConstellations);
            }
        }
        public static XDocument ConstellationJumps
        {
            get
            {
                return GetXDocumentFromCache("EveConstellationJumps.xml", ResourceProvider.EveConstellationJumps);
            }
        }
        public static XDocument Regions
        {
            get
            {
                return GetXDocumentFromCache("EveRegions.xml", ResourceProvider.EveRegions);
            }
        }
        public static XDocument RegionJumps
        {
            get
            {
                return GetXDocumentFromCache("EveRegionJumps.xml", ResourceProvider.EveRegionJumps);
            }
        }
        public static void ClearResourceCache()
        {
            RenewResourceCache("EveTypes.xml");
            RenewResourceCache("EveStations.xml");
            RenewResourceCache("EveSolarSystems.xml");
            RenewResourceCache("EveSolarSystemJumps.xml");
            RenewResourceCache("EveConstellations.xml");
            RenewResourceCache("EveConstellationJumps.xml");
            RenewResourceCache("EveRegions.xml");
        }

        private static XDocument GetXDocumentFromCache(string fileName, byte[] defalutData)
        {
            if (!Directory.Exists(cacheFolderName))
            {
                Directory.CreateDirectory(cacheFolderName);
            }

            string filePath = GetResourcePath(fileName);
            XDocument result;

            if (!File.Exists(filePath))
            {
                result = GetXDocumentFromResource(defalutData);
                result.Save(filePath);
            }
            else
            {
                result = GetXDocumentFromFile(filePath);
            }

            return result;
        }

        private static void RenewResourceCache(string resourceFileName)
        {
            string resourceFilePath = GetResourcePath(resourceFileName);

            if (File.Exists(resourceFilePath))
            {
                File.Delete(resourceFilePath);
            }
        }
        private static string GetResourcePath(string resourceFileName)
        {
            return Path.Combine(cacheFolderName, resourceFileName);
        }
        private static XDocument GetXDocumentFromFile(string fileName)
        {
            using (FileStream fileStream = new FileStream(fileName, FileMode.Open, FileAccess.Read))
            {
                StreamReader streamReader = new StreamReader(fileStream);
                XDocument xDocument = XDocument.Load(streamReader);
                return xDocument;
            }
        }
        private static XDocument GetXDocumentFromResource(byte[] resource)
        {
            Stream stream = GetStreamFromResource(resource);
            using (GZipStream gZipStream = new GZipStream(stream, CompressionMode.Decompress))
            {
                StreamReader streamReader = new StreamReader(gZipStream);
                XDocument xDocument = XDocument.Load(streamReader);
                return xDocument;
            }
        }
        private static Stream GetStreamFromResource(byte[] resource)
        {
            return new MemoryStream(resource);
        }
    }
}
