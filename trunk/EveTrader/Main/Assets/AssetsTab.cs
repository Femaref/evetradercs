using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Core;
using Core.DomainModel;

namespace EveTrader.Main.Assets
{
    public partial class AssetsTab : UserControl
    {
        private Character selectedCharacter
        {
            get
            {
                return this.CharactersComboBox.SelectedItem as Character;
            }
        }

        public AssetsTab()
        {
            InitializeComponent();
        }

        public void Initialize()
        {
            CharactersComboBox.Items.Clear();

            foreach (Character character in Settings.Instance.Characters)
            {
                CharactersComboBox.Items.Add(character);
            }

            if (CharactersComboBox.Items.Count > 0)
            {
                CharactersComboBox.SelectedIndex = 0;
                this.RenderAssets();
            }
        }

        private void RenderAssets()
        {
            /*if (selectedCharacter == null)
            {
                return;
            }

            this.RenderAssets();
             * */
        }

        private void RenderAssets(IEnumerable<Asset> assets)
        {
            /*foreach (Asset asset in assets)
            {
                ListViewItem listViewItem = new ListViewItem(
                    new string[]
                        {
                            marketOrder.OrderState.StringValue(),
                            Resources.Instance.EveObjects.Stations.GetStationById(asset.LocationId).Name,
                        });
            }
             * */
        }
    }
}
