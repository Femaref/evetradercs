using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;
using EveTrader.Helpers;
using EveTrader.Main.Dashboard;
using EveTrader.ReleaseNotes;

namespace EveTrader
{
    [XmlRoot("UISettings")]
    public class UISettings : XmlSettingsFile<UISettings>
    {
        protected override string fileName
        {
            get
            {
                return "UISettings.xml";
            }
        }

        public string LastBackupDirectory { get; set; }
        public DashboardSettings DashboardSettings { get; set; }
        public ReleaseNotesSettings ReleaseNotesSettings { get; set; }

        public UISettings()
        {
            this.DashboardSettings = new DashboardSettings();
            this.ReleaseNotesSettings = new ReleaseNotesSettings();
        }
    }
}
