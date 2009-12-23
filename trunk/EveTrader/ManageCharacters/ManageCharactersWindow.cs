using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Core.ClassExtenders;
using Core.Updaters.DataRequest;
using Core.DomainModel;

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
