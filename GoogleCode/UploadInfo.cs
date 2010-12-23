using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net;

namespace GoogleCode
{
    public class UploadInfo
    {
        public HttpStatusCode Status { get; set; }
        public string Description { get; set; }
        public string Location { get; set; }

        public UploadInfo(HttpStatusCode status, string description, string location)
        {
            Status = status;
            Description = description;
            Location = location;
        }
    }
}
