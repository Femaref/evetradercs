using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.IO.Compression;

namespace EveTrader.Updater
{
    public static class Gzip
    {
        public static byte[] Compress(byte[] input)
        {

            using (MemoryStream outputStream = new MemoryStream())
            using (GZipStream zipStream = new GZipStream(outputStream, CompressionMode.Compress))
            {
                zipStream.Write(input, 0, input.Length);

                outputStream.Position = 0;

                byte[] output = new byte[outputStream.Length];

                outputStream.Read(output, 0, output.Length);

                return output;
            }
        }

        public static byte[] Decompress(byte[] input)
        {
            using (MemoryStream inStream = new MemoryStream(input))
            using (GZipStream zipStream = new GZipStream(inStream, CompressionMode.Decompress))
            using(MemoryStream outStream = new MemoryStream())
            {
                int i;
                byte[] tempBytes = new byte[4096];
                while ((i = zipStream.Read(tempBytes, 0, tempBytes.Length)) != 0)
                {
                    outStream.Write(tempBytes, 0, i);
                }

                outStream.Position = 0;

                byte[] buffer = new byte[outStream.Length];
                outStream.Read(buffer, 0, buffer.Length);

                return buffer;
            }
        }
    }
}
