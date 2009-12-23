namespace EveTrader.ManageCharacters
{
    partial class ManageCharactersWindow
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.ExistingCharacters = new System.Windows.Forms.TabPage();
            this.existingCharactersTab = new EveTrader.ManageCharacters.ExistingCharactersTab();
            this.NewCharacterTab = new System.Windows.Forms.TabPage();
            this.newCharacterTab1 = new EveTrader.ManageCharacters.NewCharacterTab();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.ExistingCharacters.SuspendLayout();
            this.NewCharacterTab.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.SuspendLayout();
            // 
            // ExistingCharacters
            // 
            this.ExistingCharacters.Controls.Add(this.existingCharactersTab);
            this.ExistingCharacters.Location = new System.Drawing.Point(4, 22);
            this.ExistingCharacters.Name = "ExistingCharacters";
            this.ExistingCharacters.Padding = new System.Windows.Forms.Padding(3);
            this.ExistingCharacters.Size = new System.Drawing.Size(362, 305);
            this.ExistingCharacters.TabIndex = 1;
            this.ExistingCharacters.Text = "Existing characters";
            this.ExistingCharacters.UseVisualStyleBackColor = true;
            this.ExistingCharacters.Click += new System.EventHandler(this.ExistingCharacters_Click);
            // 
            // existingCharactersTab
            // 
            this.existingCharactersTab.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.existingCharactersTab.Location = new System.Drawing.Point(0, 0);
            this.existingCharactersTab.Name = "existingCharactersTab";
            this.existingCharactersTab.Padding = new System.Windows.Forms.Padding(8);
            this.existingCharactersTab.Size = new System.Drawing.Size(362, 305);
            this.existingCharactersTab.TabIndex = 0;
            // 
            // NewCharacterTab
            // 
            this.NewCharacterTab.Controls.Add(this.newCharacterTab1);
            this.NewCharacterTab.Location = new System.Drawing.Point(4, 22);
            this.NewCharacterTab.Name = "NewCharacterTab";
            this.NewCharacterTab.Padding = new System.Windows.Forms.Padding(3);
            this.NewCharacterTab.Size = new System.Drawing.Size(362, 305);
            this.NewCharacterTab.TabIndex = 0;
            this.NewCharacterTab.Text = "New character";
            this.NewCharacterTab.UseVisualStyleBackColor = true;
            // 
            // newCharacterTab1
            // 
            this.newCharacterTab1.Location = new System.Drawing.Point(0, 0);
            this.newCharacterTab1.Name = "newCharacterTab1";
            this.newCharacterTab1.Padding = new System.Windows.Forms.Padding(8);
            this.newCharacterTab1.Size = new System.Drawing.Size(360, 303);
            this.newCharacterTab1.TabIndex = 0;
            // 
            // tabControl1
            // 
            this.tabControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.tabControl1.Controls.Add(this.NewCharacterTab);
            this.tabControl1.Controls.Add(this.ExistingCharacters);
            this.tabControl1.Location = new System.Drawing.Point(12, 12);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(370, 331);
            this.tabControl1.TabIndex = 0;
            // 
            // ManageCharactersWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(394, 355);
            this.Controls.Add(this.tabControl1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(400, 380);
            this.Name = "ManageCharactersWindow";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Manage Characters";
            this.Load += new System.EventHandler(this.ManageCharactersWindow_Load);
            this.ExistingCharacters.ResumeLayout(false);
            this.NewCharacterTab.ResumeLayout(false);
            this.tabControl1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabPage ExistingCharacters;
        private System.Windows.Forms.TabPage NewCharacterTab;
        private System.Windows.Forms.TabControl tabControl1;
        private NewCharacterTab newCharacterTab1;
        private ExistingCharactersTab existingCharactersTab;

    }
}