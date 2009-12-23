namespace EveTrader.Main.Assets
{
    partial class AssetsTab
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.AssetsList = new System.Windows.Forms.ListView();
            this.region = new System.Windows.Forms.ColumnHeader();
            this.station = new System.Windows.Forms.ColumnHeader();
            this.name = new System.Windows.Forms.ColumnHeader();
            this.quantity = new System.Windows.Forms.ColumnHeader();
            this.CharactersComboBox = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // AssetsList
            // 
            this.AssetsList.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.AssetsList.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.region,
            this.name,
            this.quantity,
            this.station});
            this.AssetsList.FullRowSelect = true;
            this.AssetsList.Location = new System.Drawing.Point(0, 40);
            this.AssetsList.Name = "AssetsList";
            this.AssetsList.Size = new System.Drawing.Size(871, 401);
            this.AssetsList.TabIndex = 0;
            this.AssetsList.UseCompatibleStateImageBehavior = false;
            this.AssetsList.View = System.Windows.Forms.View.Details;
            // 
            // region
            // 
            this.region.Text = "Region";
            this.region.Width = 100;
            // 
            // station
            // 
            this.station.Text = "Station";
            this.station.Width = 260;
            // 
            // name
            // 
            this.name.Text = "Name";
            this.name.Width = 210;
            // 
            // quantity
            // 
            this.quantity.Text = "Quantity";
            this.quantity.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // CharactersComboBox
            // 
            this.CharactersComboBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.CharactersComboBox.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.CharactersComboBox.DisplayMember = "Name";
            this.CharactersComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CharactersComboBox.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.CharactersComboBox.FormattingEnabled = true;
            this.CharactersComboBox.Location = new System.Drawing.Point(658, 11);
            this.CharactersComboBox.Name = "CharactersComboBox";
            this.CharactersComboBox.Size = new System.Drawing.Size(202, 21);
            this.CharactersComboBox.TabIndex = 8;
            this.CharactersComboBox.ValueMember = "Name";
            // 
            // AssetsTab
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.CharactersComboBox);
            this.Controls.Add(this.AssetsList);
            this.Name = "AssetsTab";
            this.Padding = new System.Windows.Forms.Padding(8);
            this.Size = new System.Drawing.Size(871, 441);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListView AssetsList;
        private System.Windows.Forms.ColumnHeader name;
        private System.Windows.Forms.ColumnHeader quantity;
        private System.Windows.Forms.ColumnHeader region;
        private System.Windows.Forms.ColumnHeader station;
        private System.Windows.Forms.ComboBox CharactersComboBox;
    }
}
