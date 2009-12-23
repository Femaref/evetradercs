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
using EveObjects;

namespace EveTrader.Main.StarMap
{
    public partial class StarMapTab : UserControl
    {
        public StarMapTab()
        {
            InitializeComponent();
        }

        private void SuggestionMenuStrip_ItemClick(object sender, EventArgs e)
        {
            ToolStripMenuItem menuItem = (ToolStripMenuItem) sender;
            TextBox textBox = (TextBox) menuItem.Tag;

            textBox.Text = menuItem.Text;
        }
        private void TextBox_Suggest(object sender, EventArgs e)
        {
            TextBox textBox = (TextBox) sender;

            if (textBox.Text.Length < 3)
            {
                this.SuggestionMenuStrip.Hide();
                return;
            }

            this.SuggestionMenuStrip.Items.Clear();
            IList<SolarSystem> suggestions = Resources.Instance.EveObjects.SolarSystems.GetSolarSystemsByNamePart(textBox.Text).OrderBy ( item => item.Name ).ToList();

            if (suggestions.Count == 0)
            {
                this.SuggestionMenuStrip.Hide();
                return;
            }

            foreach(SolarSystem solarSystem in suggestions)
            {
                ToolStripMenuItem item = new ToolStripMenuItem();
                item.Text = solarSystem.Name;
                item.Click += SuggestionMenuStrip_ItemClick;
                item.Tag = textBox;

                this.SuggestionMenuStrip.Items.Add(item);
            }

            this.SuggestionMenuStrip.Width = textBox.Width;
            this.SuggestionMenuStrip.Show(textBox, 0, textBox.Height);
            
            textBox.Focus();
        }
        private void TextBox_Suggest(object sender, KeyEventArgs e)
        {
            this.TextBox_Suggest(sender, EventArgs.Empty);
        }

        private void FindRouteButton_Click(object sender, EventArgs e)
        {
            try
            {
                SolarSystem fromSolarSystem =
                    Resources.Instance.EveObjects.SolarSystems.GetSolarSystemByName(this.FromTextBox.Text);
                SolarSystem toSolarSystem =
                    Resources.Instance.EveObjects.SolarSystems.GetSolarSystemByName(this.ToTextBox.Text);

                IList<SolarSystem> route =
                    Resources.Instance.EveObjects.Autopilot.GetRoute(fromSolarSystem, toSolarSystem);

                this.RouteListView.Items.Clear();

                Dictionary<double, Color> colorTable = new Dictionary<double, Color>();
                colorTable.Add(0.0, Color.Red);
                colorTable.Add(0.1, Color.Red);
                colorTable.Add(0.2, Color.Red);
                colorTable.Add(0.3, Color.OrangeRed);
                colorTable.Add(0.4, Color.DarkOrange);
                colorTable.Add(0.5, Color.Gold);
                colorTable.Add(0.6, Color.LawnGreen);
                colorTable.Add(0.7, Color.LawnGreen);
                colorTable.Add(0.8, Color.Lime);
                colorTable.Add(0.9, Color.Aquamarine);
                colorTable.Add(1.0, Color.Aquamarine);

                this.RouteJumpsCountLabel.Text = string.Format("{0} Jumps", route.Count);
                Font boldFont = new Font(this.RouteListView.Font, FontStyle.Bold);

                foreach (SolarSystem system in route)
                {
                    ListViewItem item = new ListViewItem(
                        new string[]
                            {
                                "",
                                system.Security < 0.5 ? "●" : "•",
                                system.Security.ToString("0.0"),
                                system.Name
                            });

                    this.RouteListView.Items.Add(item);
                    item.UseItemStyleForSubItems = false;
                    item.SubItems[1].BackColor = Color.Black;
                    item.SubItems[1].ForeColor = colorTable[system.Security < 0 ? 0 : Math.Round(system.Security, 1)];
                    if (system.Security < 0.5) item.SubItems[2].Font = boldFont;
                }
            }
            catch
            {
                MessageBox.Show("Can't find route, check input data");
            }
        }
    }
}
