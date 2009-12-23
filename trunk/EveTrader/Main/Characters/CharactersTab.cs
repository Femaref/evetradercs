using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Net;
using System.Text;
using System.Windows.Forms;
using Core.ClassExtenders;
using Core.Updaters;
using Core.DomainModel;
using Settings=EveTrader.Settings;

namespace EveTrader.Main.Characters
{
    public partial class CharactersTab : UserControl
    {
        public CharactersTab()
        {
            InitializeComponent();
        }

        public void Initialize()
        {
            this.RenderCharactersList();
        }

        private void RenderCharactersList()
        {
            this.CharactersListView.Items.Clear();

            foreach (Character Character in Settings.Instance.Characters)
            {
                ListViewItem listViewItem = new ListViewItem(
                        new string[] {
                            Character.Name,
                            Character.Balance.FormatCurrency()
                        });

                listViewItem.UseItemStyleForSubItems = false;
                listViewItem.SubItems[1].ForeColor = Character.Balance > 0 ? Color.ForestGreen : Color.IndianRed;

                this.CharactersListView.Items.Add(listViewItem);
            }
        }

        private void UpdateButton_Click(object sender, EventArgs e)
        {
            CharacterInfoUpdater characterInfoUpdater = new CharacterInfoUpdater();

            foreach (Character character in Settings.Instance.Characters)
            {
                (this.ParentForm as MainWindow).StatusText = string.Format("Updating character {0}", character.Name);

                try
                {
                    characterInfoUpdater.UpdateCharacter(character);
                }
                catch (WebException webException)
                {
                    MessageBox.Show("Unable to connect to eve server", "Connection error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

                this.RenderCharactersList();

                (this.ParentForm as MainWindow).StatusText =
                    string.Format("All characters updated {0}", DateTime.Now.ToString("HH:mm"));
            }
        }
    }
}


