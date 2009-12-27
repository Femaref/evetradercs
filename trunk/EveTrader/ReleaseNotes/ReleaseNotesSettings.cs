using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace EveTrader.ReleaseNotes
{
    public class ReleaseNotesSettings
    {
        public string ProductVersion
        {
            get
            {
                return Application.ProductVersion;
            }
        }
        public string PreviousProductVersion { get; set; }
        public bool IsVersionChanged
        {
            get
            {
                return this.GetMajorMinorVersion(this.ProductVersion) != this.GetMajorMinorVersion(this.PreviousProductVersion);
            }
        }

        public ReleaseNotesSettings()
        {
            this.PreviousProductVersion = string.Empty;
        }

        private string GetMajorMinorVersion(string version)
        {
            return Regex.Match(version, @"\d+.\d").Value;
        }
    }
}
