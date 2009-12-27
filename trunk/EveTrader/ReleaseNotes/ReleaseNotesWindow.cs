using System;
using System.Windows.Forms;

namespace EveTrader.ReleaseNotes
{
    public partial class ReleaseNotesWindow : Form
    {
        public ReleaseNotesWindow()
        {
            InitializeComponent();
        }

        private void ReleaseNotesWindow_Load(object sender, EventArgs e)
        {           
            if (UISettings.Instance.ReleaseNotesSettings.IsVersionChanged)
            {
                this.TitleLabel.Text = string.Format(
                    ReleaseNotesWindowResources.ReleaseNotesTitle,
                    UISettings.Instance.ReleaseNotesSettings.ProductVersion);
            }
            else
            {
                this.TitleLabel.Text = string.Format(
                    ReleaseNotesWindowResources.UpdatedTitle,
                    UISettings.Instance.ReleaseNotesSettings.ProductVersion);
            }

            this.textBox1.Text = ReleaseNotesWindowResources.ReleaseNotesText;
            this.textBox1.SelectionStart = 0;
            this.textBox1.SelectionLength = 0;

            UISettings.Instance.ReleaseNotesSettings.PreviousProductVersion = UISettings.Instance.ReleaseNotesSettings.ProductVersion;
        }
    }
}
