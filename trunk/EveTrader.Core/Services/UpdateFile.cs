using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EveTrader.Core.Services
{
    /// <summary>
    /// Describes an updateable file
    /// </summary>
    public class UpdateFile
    {
        /// <summary>
        /// The Name of the file including extension
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Current version on the server
        /// </summary>
        public string Version { get; set; }

        /// <summary>
        /// Relative path on the server
        /// </summary>
        public Uri RelativePath { get; set; }

        /// <summary>
        /// MD5 checksum of the file
        /// </summary>
        public string Checksum { get; set; }
    }
}
