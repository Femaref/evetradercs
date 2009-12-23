using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;
using System.IO;
using Core.DomainModel;
using EveTrader.Helpers;
using EveTrader.Main.Dashboard;
using EveTrader.ReleaseNotes;
using EveTrader.Main.Dashboard;
using EveTrader.ReleaseNotes;

namespace EveTrader
{
    [XmlRoot("EveTrader")]
    public class Settings : XmlSettingsFile<Settings>
    {
        protected override string fileName
        {
            get
            {
                return "settings.xml";
            }
        }

        public List<Character> Characters { get; set; }
        public UserData UserData { get; set; }

        public Settings()
        {
            this.Characters = new List<Character>();
            this.UserData = new UserData();
        }
    }
}