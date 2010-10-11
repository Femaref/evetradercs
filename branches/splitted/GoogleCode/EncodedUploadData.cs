using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GoogleCode
{
    public class EncodedUploadData
    {
        public string ContentType { get; set; }
        public byte[] Data { get; set; }

        public EncodedUploadData(string contentType, byte[] data)
        {
            ContentType = contentType;
            Data = data;
        }
    }
}
