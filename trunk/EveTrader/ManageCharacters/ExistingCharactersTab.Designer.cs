namespace EveTrader.ManageCharacters
{
    partial class ExistingCharactersTab
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
            this.components = new System.ComponentModel.Container();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.CharactersToDeleteListBox = new System.Windows.Forms.ListBox();
            this.cmsCharacter = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.accountingLevelToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.setAcc0 = new System.Windows.Forms.ToolStripMenuItem();
            this.setAcc1 = new System.Windows.Forms.ToolStripMenuItem();
            this.setAcc2 = new System.Windows.Forms.ToolStripMenuItem();
            this.setAcc3 = new System.Windows.Forms.ToolStripMenuItem();
            this.setAcc4 = new System.Windows.Forms.ToolStripMenuItem();
            this.setAcc5 = new System.Windows.Forms.ToolStripMenuItem();
            this.DeleteButton = new System.Windows.Forms.Button();
            this.ErrorProvider = new System.Windows.Forms.ErrorProvider(this.components);
            this.ChangeApiKey = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.cmsCharacter.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ErrorProvider)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.CharactersToDeleteListBox);
            this.groupBox1.Location = new System.Drawing.Point(11, 11);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(8, 16, 8, 8);
            this.groupBox1.Size = new System.Drawing.Size(345, 188);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Select characters to delete";
            // 
            // CharactersToDeleteListBox
            // 
            this.CharactersToDeleteListBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.CharactersToDeleteListBox.ContextMenuStrip = this.cmsCharacter;
            this.CharactersToDeleteListBox.FormattingEnabled = true;
            this.CharactersToDeleteListBox.Location = new System.Drawing.Point(11, 32);
            this.CharactersToDeleteListBox.Name = "CharactersToDeleteListBox";
            this.CharactersToDeleteListBox.Size = new System.Drawing.Size(323, 147);
            this.CharactersToDeleteListBox.Sorted = true;
            this.CharactersToDeleteListBox.TabIndex = 0;
            // 
            // cmsCharacter
            // 
            this.cmsCharacter.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.accountingLevelToolStripMenuItem});
            this.cmsCharacter.Name = "cmsCharacter";
            this.cmsCharacter.Size = new System.Drawing.Size(167, 48);
            // 
            // accountingLevelToolStripMenuItem
            // 
            this.accountingLevelToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.setAcc0,
            this.setAcc1,
            this.setAcc2,
            this.setAcc3,
            this.setAcc4,
            this.setAcc5});
            this.accountingLevelToolStripMenuItem.Name = "accountingLevelToolStripMenuItem";
            this.accountingLevelToolStripMenuItem.Size = new System.Drawing.Size(166, 22);
            this.accountingLevelToolStripMenuItem.Text = "Accounting Level";
            // 
            // setAcc0
            // 
            this.setAcc0.Name = "setAcc0";
            this.setAcc0.Size = new System.Drawing.Size(152, 22);
            this.setAcc0.Text = "Set to 0";
            this.setAcc0.Click += new System.EventHandler(this.accountSet_Click);
            // 
            // setAcc1
            // 
            this.setAcc1.Name = "setAcc1";
            this.setAcc1.Size = new System.Drawing.Size(152, 22);
            this.setAcc1.Text = "Set to 1";
            this.setAcc1.Click += new System.EventHandler(this.accountSet_Click);
            // 
            // setAcc2
            // 
            this.setAcc2.Name = "setAcc2";
            this.setAcc2.Size = new System.Drawing.Size(152, 22);
            this.setAcc2.Text = "Set to 2";
            this.setAcc2.Click += new System.EventHandler(this.accountSet_Click);
            // 
            // setAcc3
            // 
            this.setAcc3.Name = "setAcc3";
            this.setAcc3.Size = new System.Drawing.Size(152, 22);
            this.setAcc3.Text = "Set to 3";
            this.setAcc3.Click += new System.EventHandler(this.accountSet_Click);
            // 
            // setAcc4
            // 
            this.setAcc4.Name = "setAcc4";
            this.setAcc4.Size = new System.Drawing.Size(152, 22);
            this.setAcc4.Text = "Set to 4";
            this.setAcc4.Click += new System.EventHandler(this.accountSet_Click);
            // 
            // setAcc5
            // 
            this.setAcc5.Name = "setAcc5";
            this.setAcc5.Size = new System.Drawing.Size(152, 22);
            this.setAcc5.Text = "Set to 5";
            this.setAcc5.Click += new System.EventHandler(this.accountSet_Click);
            // 
            // DeleteButton
            // 
            this.DeleteButton.Location = new System.Drawing.Point(227, 205);
            this.DeleteButton.Name = "DeleteButton";
            this.DeleteButton.Size = new System.Drawing.Size(129, 23);
            this.DeleteButton.TabIndex = 1;
            this.DeleteButton.Text = "Delete";
            this.DeleteButton.UseVisualStyleBackColor = true;
            this.DeleteButton.Click += new System.EventHandler(this.DeleteButton_Click);
            // 
            // ErrorProvider
            // 
            this.ErrorProvider.BlinkRate = 0;
            this.ErrorProvider.BlinkStyle = System.Windows.Forms.ErrorBlinkStyle.NeverBlink;
            this.ErrorProvider.ContainerControl = this;
            // 
            // ChangeApiKey
            // 
            this.ChangeApiKey.Location = new System.Drawing.Point(11, 205);
            this.ChangeApiKey.Name = "ChangeApiKey";
            this.ChangeApiKey.Size = new System.Drawing.Size(129, 23);
            this.ChangeApiKey.TabIndex = 2;
            this.ChangeApiKey.Text = "Change API Key";
            this.ChangeApiKey.UseVisualStyleBackColor = true;
            this.ChangeApiKey.Click += new System.EventHandler(this.ChangeApiKey_Click);
            // 
            // ExistingCharactersTab
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.ChangeApiKey);
            this.Controls.Add(this.DeleteButton);
            this.Controls.Add(this.groupBox1);
            this.Name = "ExistingCharactersTab";
            this.Padding = new System.Windows.Forms.Padding(8);
            this.Size = new System.Drawing.Size(367, 323);
            this.groupBox1.ResumeLayout(false);
            this.cmsCharacter.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.ErrorProvider)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button DeleteButton;
        private System.Windows.Forms.ErrorProvider ErrorProvider;
        private System.Windows.Forms.ListBox CharactersToDeleteListBox;
        private System.Windows.Forms.Button ChangeApiKey;
        private System.Windows.Forms.ContextMenuStrip cmsCharacter;
        private System.Windows.Forms.ToolStripMenuItem accountingLevelToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem setAcc0;
        private System.Windows.Forms.ToolStripMenuItem setAcc1;
        private System.Windows.Forms.ToolStripMenuItem setAcc2;
        private System.Windows.Forms.ToolStripMenuItem setAcc3;
        private System.Windows.Forms.ToolStripMenuItem setAcc4;
        private System.Windows.Forms.ToolStripMenuItem setAcc5;

    }
}
