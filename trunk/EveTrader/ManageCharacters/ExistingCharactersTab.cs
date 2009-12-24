using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Core.DomainModel;
using EveTrader.Helpers;
using Settings=EveTrader.Settings;

namespace EveTrader.ManageCharacters
{
    public partial class ExistingCharactersTab : UserControl
    {
        public ExistingCharactersTab()
        {
            InitializeComponent();
        }

        private Character GetSelectedCharacter()
        {
            return (Character) this.CharactersToDeleteListBox.SelectedItem;
        }
        private bool CheckCharacterIsSelected()
        {
            this.ErrorProvider.Clear();
            
            if (this.GetSelectedCharacter() == null)
            {
                MessageBox.Show("Select character first");
                this.ErrorProvider.SetError(this.CharactersToDeleteListBox, "Select character first");
                return false;
            }
            else
            {
                return true;
            }
        }

        private void ChangeApiKey_Click(object sender, EventArgs e)
        {
            if (!this.CheckCharacterIsSelected())
            {
                return;
            }

            Character character = this.GetSelectedCharacter();

            InputBoxResult result = InputBox.Show(string.Format("Enter new API key for {0}", character.Name), "Change API key");

            if (result.OK && !string.IsNullOrEmpty(result.Text))
            {
                character.ApiKey = result.Text;
                character.NextMarketOrdersUpdateTime = DateTime.Now;
                character.NextWalletJournalUpdateTime = DateTime.Now;
                character.NextWalletTransactionsUpdateTime = DateTime.Now;
                
                Settings.Instance.Save();

                MessageBox.Show(
                    string.Format(
                        "API key for {0} successfully changed", 
                        character.Name),
                    "API key successfully changed");
                
                this.RenderCharactersList();
            }
        }
        private void DeleteButton_Click(object sender, EventArgs e)
        {
            if (!this.CheckCharacterIsSelected())
            {
                return;
            }

            Character character = this.GetSelectedCharacter();
            
            DialogResult result = MessageBox.Show(
                string.Format(
                    "{0} will be deleted, proceed?", 
                    character.Name), 
                "Confirm delete", 
                MessageBoxButtons.YesNo, 
                MessageBoxIcon.Stop);

            if (result == DialogResult.Yes)
            {
                Settings.Instance.Characters.Remove(character);
                Settings.Instance.Save();
                this.RenderCharactersList();
            }
        }

        public void RenderCharactersList()
        {
            this.CharactersToDeleteListBox.Items.Clear();

            foreach(Character character in Settings.Instance.Characters)
            {
                this.CharactersToDeleteListBox.Items.Add(character);
            }
        }

        public void RenderCharactersList(object sender, EventArgs e)
        {
            this.RenderCharactersList();
        }

        private void accountSet_Click(object sender, EventArgs e)
        {
            if (!this.CheckCharacterIsSelected())
                return;

            Character c = this.GetSelectedCharacter();

            switch ((sender as ToolStripMenuItem).Name)
            {
                case "setAcc0":
                    c.AccountingLevel = 0;
                    break;
                case "setAcc1":
                    c.AccountingLevel = 1;
                    break;
                case "setAcc2":
                    c.AccountingLevel = 2;
                    break;
                case "setAcc3":
                    c.AccountingLevel = 3;
                    break;
                case "setAcc4":
                    c.AccountingLevel = 4;
                    break;
                case "setAcc5":
                    c.AccountingLevel = 5;
                    break;
            }
        }


    }
}
