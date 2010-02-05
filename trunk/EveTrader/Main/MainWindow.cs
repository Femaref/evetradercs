using System;
using System.Globalization;
using System.IO;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using Core.DomainModel;
using Core.Updaters;
using EveTrader.ReleaseNotes;

namespace EveTrader.Main
{
    public partial class MainWindow : Form
    {
        public static bool ReInitializeDashboardTab { get; set; }
        public static bool ReInitializeReportsTab { get; set; }

        public MainWindow()
        {
            InitializeComponent();

            CultureInfo enCulture = CultureInfo.GetCultureInfo("en-US");
            Thread.CurrentThread.CurrentCulture = enCulture;
            Thread.CurrentThread.CurrentUICulture = enCulture;
        }

        public string StatusText
        {
            get { return this.StatusToolStripLabel.Text; }
            set
            {
                this.StatusToolStripLabel.Text = value;
                this.StatusToolStripLabel.Invalidate();
            }
        }

        private void FromMain_Load(object sender, EventArgs e)
        {
            Settings.Instance.Load();
            UISettings.Instance.Load();
            this.Initialize();
            this.AuraTrayIcon.Visible = false;
            this.AppVersionToolStripLabel.Text = Application.ProductVersion;

            /*this.AuraTrayIcon.BalloonTipText = "Following items were sold:\n1\n2\n3\n\nFollwing items were bought:\n1\n2";
            this.AuraTrayIcon.BalloonTipIcon = ToolTipIcon.Info;
            this.AuraTrayIcon.ShowBalloonTip(1000000);*/
        }

        private void MainWindow_Shown(object sender, EventArgs e)
        {
            if (UISettings.Instance.ReleaseNotesSettings.IsVersionChanged)
            {
                ReleaseNotesWindow releaseNotesWindow = new ReleaseNotesWindow();
                releaseNotesWindow.ShowDialog();
            }
        }

        public void Initialize()
        {
            this.DashboardTab.Initialize();
            this.ReportsTab.Initialize();
            this.WalletTransactionsTab.Initialize();
            this.CharactersTab.Initialize();
            this.MarketOrdersTab.Initialize();
        }

        private void UpdateCharactersAndInitialize()
        {
            ICharacterUpdater updater = new CharacterUpdater();
            bool updated = false;

            foreach (Character character in Settings.Instance.Characters)
            {
                updated |= updater.UpdateCharacter(character);
            }

            Settings.Instance.Save();

            StringBuilder sb = new StringBuilder();
            sb.Append("Next possible update time: ");

            foreach (Character character in Settings.Instance.Characters)
            {
                sb.AppendFormat("{0} - {1:HH:mm}, ", character.Name, character.NextUpdateTime);
            }
            sb.Remove(sb.Length - 2, 2);
            this.StatusToolStripLabel.Text = sb.ToString();

            this.Initialize();
        }

        private void FromMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            Settings.Instance.Save();
            UISettings.Instance.Save();
        }

        private void manageCharactersToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ManageCharacters.ManageCharactersWindow manageCharacters = new ManageCharacters.ManageCharactersWindow();
            manageCharacters.ShowDialog();
            this.Initialize();
        }

        private void DashboardTab_Load(object sender, EventArgs e)
        {
        }

        private void InfoReloadingTimer_Elapsed(object sender, System.Timers.ElapsedEventArgs e)
        {
            this.UpdateCharactersAndInitialize();
        }

        private void forceUpdateToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.UpdateCharactersAndInitialize();
        }

        private void releaseNotesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ReleaseNotesWindow releaseNotesWindow = new ReleaseNotesWindow();
            releaseNotesWindow.ShowDialog();
        }

        private void backupToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string folderToSave = Directory.Exists(UISettings.Instance.LastBackupDirectory)
                                      ? UISettings.Instance.LastBackupDirectory
                                      : Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);

            this.BackupFileDialog.FileName =
                Path.Combine(
                    folderToSave,
                    string.Format("{0:yyyyMMdd-HHmm}-Eve-Trader-backup", DateTime.Now));

            DialogResult dialogResult = this.BackupFileDialog.ShowDialog(this);

            if (dialogResult == DialogResult.OK)
            {
                UISettings.Instance.LastBackupDirectory = Path.GetDirectoryName(this.BackupFileDialog.FileName);

                try
                {
                    Settings.Instance.Save(BackupFileDialog.FileName);

                    MessageBox.Show(
                        string.Format("Your data successfully saved to\n{0}", this.BackupFileDialog.FileName),
                        "Eve Trader",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(
                        string.Format("Unable to backup data to\n{0}", ex.Message),
                        "Eve Trader",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error);
                }
            }
        }

        private void restoreToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string folderToOpen = Directory.Exists(UISettings.Instance.LastBackupDirectory)
                                      ? UISettings.Instance.LastBackupDirectory
                                      : Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);

            this.RestoreFileDialog.InitialDirectory = folderToOpen;

            DialogResult dialogResult = this.RestoreFileDialog.ShowDialog(this);

            if (dialogResult == DialogResult.OK)
            {
                string backupFile = Path.Combine(
                    Path.GetDirectoryName(this.RestoreFileDialog.FileName),
                    string.Format("{0:yyyyMMdd-HHmm}-Eve-Trader-auto-backup.xml", DateTime.Now));

                try
                {
                    Settings.Instance.Save(backupFile);
                }
                catch (Exception ex)
                {
                    DialogResult warningBoxResult = MessageBox.Show(
                        string.Format("Unable to backup current data to\n{0}\n\nContinue?", ex.Message),
                        "Eve Trader",
                        MessageBoxButtons.YesNo,
                        MessageBoxIcon.Error);

                    if (warningBoxResult == DialogResult.No)
                    {
                        return;
                    }
                }

                try
                {
                    Settings.Instance.Load(this.RestoreFileDialog.FileName);

                    MessageBox.Show(
                        string.Format(
                            "Your data successfully restored from\n{0}\n\nPreviuos data were saved to:\n{1}\nin case you want to roll back changes.", 
                            this.RestoreFileDialog.FileName,
                            backupFile),
                        "Eve Trader",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Exclamation);

                    Settings.Instance.Save();
                    this.Initialize();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(
                        string.Format("Unable to restore data\n{0}", ex.Message),
                        "Eve Trader",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error);
                }
            }
        }

        private void tabDashboard_Click(object sender, EventArgs e)
        {
            if (MainWindow.ReInitializeDashboardTab)
            {
                MainWindow.ReInitializeDashboardTab = false;
                this.DashboardTab.Initialize();
            }
        }

        private void tabReports_Click(object sender, EventArgs e)
        {
            if (MainWindow.ReInitializeReportsTab)
            {
                MainWindow.ReInitializeReportsTab = false;
                this.ReportsTab.Initialize();
            }
        }

        private void tabsMain_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (tabsMain.SelectedTab.Name)
            {
                case "tabDashboard":
                    tabDashboard_Click(tabsMain.SelectedTab, EventArgs.Empty);
                    break;

                case "tabReports":
                    tabReports_Click(tabsMain.SelectedTab, EventArgs.Empty);
                    break;
            }
        }
    }
}