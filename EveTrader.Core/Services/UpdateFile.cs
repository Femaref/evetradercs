using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EveTrader.Core.Services
{
    public class UpdateFile
    {
        public string Name { get; set; }
        public string Version { get; set; }
        public Uri RelativePath { get; set; }
    }
}
