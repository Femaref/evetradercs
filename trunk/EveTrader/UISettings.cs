using System;
using System.Xml.Serialization;
using EveTrader.Helpers;
using EveTrader.Main.Dashboard;
using EveTrader.Main.Reports;
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

        protected override void BeforeSave()
        {
            return;
        }

        protected override void AfterSave()
        {
            return;
        }

        protected override void BeforeLoad()
        {
            return;
        }

        protected override void AfterLoad()
        {
            return;
        }

        public string LastBackupDirectory { get; set; }
        public DashboardSettings DashboardSettings { get; set; }
        public ReleaseNotesSettings ReleaseNotesSettings { get; set; }
        public ReportSettings ReportSettings { get; set; }

        public UISettings()
        {
            this.DashboardSettings = new DashboardSettings();
            this.ReleaseNotesSettings = new ReleaseNotesSettings();
            this.ReportSettings = new ReportSettings();
        }
    }
}
