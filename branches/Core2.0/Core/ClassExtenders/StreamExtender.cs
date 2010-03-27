using System.IO;
using System.Xml;
using System.Xml.Linq;

namespace Core.ClassExtenders
{
    public static class StreamExtender
    {
        public static XDocument CreateXDocument(this Stream value)
        {
            XmlReader xmlReader = XmlReader.Create(value);
            XDocument xDocument = XDocument.Load(xmlReader);

            return xDocument;
        }
    }
}
