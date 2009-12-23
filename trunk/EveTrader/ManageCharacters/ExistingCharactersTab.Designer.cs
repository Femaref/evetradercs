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
            this.DeleteButton = new System.Windows.Forms.Button();
            this.ErrorProvider = new System.Windows.Forms.ErrorProvider(this.components);
            this.CharactersToDeleteListBox = new System.Windows.Forms.ListBox();
            this.ChangeApiKey = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
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
            // CharactersToDeleteListBox
            // 
            this.CharactersToDeleteListBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.CharactersToDeleteListBox.FormattingEnabled = true;
            this.CharactersToDeleteListBox.Location = new System.Drawing.Point(11, 32);
            this.CharactersToDeleteListBox.Name = "CharactersToDeleteListBox";
            this.CharactersToDeleteListBox.Size = new System.Drawing.Size(323, 147);
            this.CharactersToDeleteListBox.Sorted = true;
            this.CharactersToDeleteListBox.TabIndex = 0;
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
            ((System.ComponentModel.ISupportInitialize)(this.ErrorProvider)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button DeleteButton;
        private System.Windows.Forms.ErrorProvider ErrorProvider;
        private System.Windows.Forms.ListBox CharactersToDeleteListBox;
        private System.Windows.Forms.Button ChangeApiKey;

    }
}
