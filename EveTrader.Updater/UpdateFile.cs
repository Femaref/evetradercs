using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EveTrader.Updater
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

        /// <summary>
        /// If compressed is true, this contains the MD5 checksum of the gzipped archive
        /// </summary>
        public string ArchiveChecksum { get; set; }

        /// <summary>
        /// Specifies the target architecture of the file
        /// </summary>
        public Architecture TargetArchitecture { get; set; }

        /// <summary>
        /// Specifies if the files is gzipped
        /// </summary>
        public bool Compressed { get; set; }

        /// <summary>
        /// Gets or sets the time this file was changed
        /// </summary>
        public DateTime ChangeDate { get; set; }
    }
}
