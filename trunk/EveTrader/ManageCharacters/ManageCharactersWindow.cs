using System;
using System.Windows.Forms;

namespace EveTrader.ManageCharacters
{
    public partial class ManageCharactersWindow : Form
    {
        private EventHandler render;

        public ManageCharactersWindow()
        {
            InitializeComponent();
        }
        public void Render()
        {
            this.render(null, EventArgs.Empty);
        }

        private void ExistingCharacters_Click(object sender, EventArgs e)
        {
            this.existingCharactersTab.RenderCharactersList();
        }

        private void ManageCharactersWindow_Load(object sender, EventArgs e)
        {
            this.render += this.existingCharactersTab.RenderCharactersList;

            this.Render();
        }
    }
}
