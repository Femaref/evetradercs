using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Core.Network.EveApi.Requests;
using Core.ClassExtenders;
using Core.DomainModel;
using Core.Updaters.DataRequest;
using Settings=EveTrader.Settings;

namespace EveTrader.ManageCharacters
{
    public partial class NewCharacterTab : UserControl
    {
        private IList<Character> characters;

        public NewCharacterTab()
        {
            InitializeComponent();
        }

        private void AddCharactersButton_Click(object sender, EventArgs e)
        {
            this.ErrorProvider.Clear();

            if (this.NewCharactersCheckedListBox.CheckedIndices.Count > 0)
            {
                CharacterComparer characterComaperer = new CharacterComparer();
                IEnumerable<Character> selectedCharacters = this.NewCharactersCheckedListBox.CheckedItems.Cast<Character>();
                IEnumerable<Character> newCharacters = selectedCharacters.Except(Settings.Instance.Characters, characterComaperer);
                Settings.Instance.Characters = Settings.Instance.Characters.Union(selectedCharacters, characterComaperer).ToList();

                this.SuccessfullyAddedGroupBox.Visible = true;
                this.NewCharactersListGroupBox.Visible = false;

                if (newCharacters.Count() == 0)
                {
                    this.CharactesLabel.Text = "Selected character(s) aleady added.";
                }
                else
                {
                    this.CharactesLabel.Text = "";
                    foreach (Character character in newCharacters)
                    {
                        this.CharactesLabel.Text += character.Name + "\n";
                    }

                    (this.ParentForm as ManageCharactersWindow).Render();
                }

                this.AddMoreCharactersButton.Visible = true;
            }
            else
            {
                this.ErrorProvider.SetError(this.NewCharactersCheckedListBox, "Select at least one character");
                MessageBox.Show("Select at least one character");
            }
        }

        private void LoadCharactersList_Click(object sender, EventArgs e)
        {
            int accountId = 0;
            bool isValid = true;

            this.ErrorProvider.Clear();

            if (this.AccountIdTextBox.Text.IsEmpty())
            {
                this.ErrorProvider.SetError(this.AccountIdTextBox, "Account Id requered");
                isValid = false;
            }
            else if (!int.TryParse(this.AccountIdTextBox.Text, out accountId))
            {
                this.ErrorProvider.SetError(this.AccountIdTextBox, "Account Id must be a number");
                isValid = false;
            }

            if (this.ApiKeyTextBox.Text.IsEmpty())
            {
                this.ErrorProvider.SetError(this.ApiKeyTextBox, "Api Key requered");
                isValid = false;
            }

            if (isValid)
            {
                CharactersListRequest charactersListRequest = new CharactersListRequest(accountId, this.ApiKeyTextBox.Text);

                try
                {
                    characters = charactersListRequest.Request().ToList();

                    this.NewCharactersListGroupBox.Visible = true;
                    this.AddCharactersButton.Visible = true;

                    this.NewCharactersCheckedListBox.Items.Clear();

                    foreach (Character character in characters)
                    {
                        this.NewCharactersCheckedListBox.Items.Add(character);
                    }
                    
                    this.AddCharactersButton.Enabled = this.NewCharactersCheckedListBox.Items.Count > 0;
                }
                catch
                {
                    MessageBox.Show("Unable to load characters list.\nCheck internet connection and your fields data");
                }
            }
        }

        private void AddMoreCharactersButton_Click(object sender, EventArgs e)
        {
            this.AddMoreCharactersButton.Visible = false;
            this.NewCharactersListGroupBox.Visible = false;
            this.AddCharactersButton.Visible = false;
            this.SuccessfullyAddedGroupBox.Visible = false;
        }
    }
}
