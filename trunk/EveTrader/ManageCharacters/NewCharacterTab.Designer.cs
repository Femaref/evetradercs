namespace EveTrader.ManageCharacters
{
    partial class NewCharacterTab
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
            this.AccountInfoGroupBox = new System.Windows.Forms.GroupBox();
            this.ApiKeyTextBox = new System.Windows.Forms.TextBox();
            this.AccountIdTextBox = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.SuccessfullyAddedGroupBox = new System.Windows.Forms.GroupBox();
            this.CharactesLabel = new System.Windows.Forms.Label();
            this.AddCharactersButton = new System.Windows.Forms.Button();
            this.NewCharactersListGroupBox = new System.Windows.Forms.GroupBox();
            this.NewCharactersCheckedListBox = new System.Windows.Forms.CheckedListBox();
            this.AddMoreCharactersButton = new System.Windows.Forms.Button();
            this.LoadCharactersList = new System.Windows.Forms.Button();
            this.ErrorProvider = new System.Windows.Forms.ErrorProvider(this.components);
            this.AccountInfoGroupBox.SuspendLayout();
            this.SuccessfullyAddedGroupBox.SuspendLayout();
            this.NewCharactersListGroupBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ErrorProvider)).BeginInit();
            this.SuspendLayout();
            // 
            // AccountInfoGroupBox
            // 
            this.AccountInfoGroupBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.AccountInfoGroupBox.Controls.Add(this.ApiKeyTextBox);
            this.AccountInfoGroupBox.Controls.Add(this.AccountIdTextBox);
            this.AccountInfoGroupBox.Controls.Add(this.label2);
            this.AccountInfoGroupBox.Controls.Add(this.label1);
            this.AccountInfoGroupBox.Location = new System.Drawing.Point(10, 11);
            this.AccountInfoGroupBox.Name = "AccountInfoGroupBox";
            this.AccountInfoGroupBox.Padding = new System.Windows.Forms.Padding(8, 16, 8, 8);
            this.AccountInfoGroupBox.Size = new System.Drawing.Size(337, 102);
            this.AccountInfoGroupBox.TabIndex = 7;
            this.AccountInfoGroupBox.TabStop = false;
            this.AccountInfoGroupBox.Text = "Enter account information";
            // 
            // ApiKeyTextBox
            // 
            this.ApiKeyTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.ApiKeyTextBox.Location = new System.Drawing.Point(85, 54);
            this.ApiKeyTextBox.Name = "ApiKeyTextBox";
            this.ApiKeyTextBox.Size = new System.Drawing.Size(219, 20);
            this.ApiKeyTextBox.TabIndex = 3;
            // 
            // AccountIdTextBox
            // 
            this.AccountIdTextBox.Location = new System.Drawing.Point(85, 26);
            this.AccountIdTextBox.Name = "AccountIdTextBox";
            this.AccountIdTextBox.Size = new System.Drawing.Size(100, 20);
            this.AccountIdTextBox.TabIndex = 2;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(11, 57);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(66, 26);
            this.label2.TabIndex = 1;
            this.label2.Text = "Api Key \r\n(Full access)";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(11, 29);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(59, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "AccountBalance Id";
            // 
            // SuccessfullyAddedGroupBox
            // 
            this.SuccessfullyAddedGroupBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.SuccessfullyAddedGroupBox.Controls.Add(this.CharactesLabel);
            this.SuccessfullyAddedGroupBox.Location = new System.Drawing.Point(10, 119);
            this.SuccessfullyAddedGroupBox.Name = "SuccessfullyAddedGroupBox";
            this.SuccessfullyAddedGroupBox.Size = new System.Drawing.Size(337, 142);
            this.SuccessfullyAddedGroupBox.TabIndex = 9;
            this.SuccessfullyAddedGroupBox.TabStop = false;
            this.SuccessfullyAddedGroupBox.Text = "Successfully added following characters";
            this.SuccessfullyAddedGroupBox.Visible = false;
            // 
            // CharactesLabel
            // 
            this.CharactesLabel.AutoSize = true;
            this.CharactesLabel.Location = new System.Drawing.Point(11, 29);
            this.CharactesLabel.Name = "CharactesLabel";
            this.CharactesLabel.Size = new System.Drawing.Size(58, 13);
            this.CharactesLabel.TabIndex = 0;
            this.CharactesLabel.Text = "Characters";
            // 
            // AddCharactersButton
            // 
            this.AddCharactersButton.Location = new System.Drawing.Point(95, 267);
            this.AddCharactersButton.Name = "AddCharactersButton";
            this.AddCharactersButton.Size = new System.Drawing.Size(129, 23);
            this.AddCharactersButton.TabIndex = 8;
            this.AddCharactersButton.Text = "Add";
            this.AddCharactersButton.UseVisualStyleBackColor = true;
            this.AddCharactersButton.Visible = false;
            this.AddCharactersButton.Click += new System.EventHandler(this.AddCharactersButton_Click);
            // 
            // NewCharactersListGroupBox
            // 
            this.NewCharactersListGroupBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.NewCharactersListGroupBox.Controls.Add(this.NewCharactersCheckedListBox);
            this.NewCharactersListGroupBox.Location = new System.Drawing.Point(10, 119);
            this.NewCharactersListGroupBox.Name = "NewCharactersListGroupBox";
            this.NewCharactersListGroupBox.Size = new System.Drawing.Size(337, 142);
            this.NewCharactersListGroupBox.TabIndex = 10;
            this.NewCharactersListGroupBox.TabStop = false;
            this.NewCharactersListGroupBox.Text = "Select characters yuo whould like to add";
            this.NewCharactersListGroupBox.Visible = false;
            // 
            // NewCharactersCheckedListBox
            // 
            this.NewCharactersCheckedListBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.NewCharactersCheckedListBox.FormattingEnabled = true;
            this.NewCharactersCheckedListBox.Location = new System.Drawing.Point(14, 29);
            this.NewCharactersCheckedListBox.Name = "NewCharactersCheckedListBox";
            this.NewCharactersCheckedListBox.Size = new System.Drawing.Size(290, 94);
            this.NewCharactersCheckedListBox.TabIndex = 0;
            // 
            // AddMoreCharactersButton
            // 
            this.AddMoreCharactersButton.Location = new System.Drawing.Point(95, 267);
            this.AddMoreCharactersButton.Name = "AddMoreCharactersButton";
            this.AddMoreCharactersButton.Size = new System.Drawing.Size(129, 23);
            this.AddMoreCharactersButton.TabIndex = 11;
            this.AddMoreCharactersButton.Text = "Add more characters";
            this.AddMoreCharactersButton.UseVisualStyleBackColor = true;
            this.AddMoreCharactersButton.Visible = false;
            this.AddMoreCharactersButton.Click += new System.EventHandler(this.AddMoreCharactersButton_Click);
            // 
            // LoadCharactersList
            // 
            this.LoadCharactersList.Location = new System.Drawing.Point(95, 119);
            this.LoadCharactersList.Name = "LoadCharactersList";
            this.LoadCharactersList.Size = new System.Drawing.Size(129, 23);
            this.LoadCharactersList.TabIndex = 12;
            this.LoadCharactersList.Text = "Load characters list";
            this.LoadCharactersList.UseVisualStyleBackColor = true;
            this.LoadCharactersList.Click += new System.EventHandler(this.LoadCharactersList_Click);
            // 
            // ErrorProvider
            // 
            this.ErrorProvider.BlinkRate = 0;
            this.ErrorProvider.BlinkStyle = System.Windows.Forms.ErrorBlinkStyle.NeverBlink;
            this.ErrorProvider.ContainerControl = this;
            // 
            // NewCharacterTab
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.AccountInfoGroupBox);
            this.Controls.Add(this.AddMoreCharactersButton);
            this.Controls.Add(this.SuccessfullyAddedGroupBox);
            this.Controls.Add(this.NewCharactersListGroupBox);
            this.Controls.Add(this.LoadCharactersList);
            this.Controls.Add(this.AddCharactersButton);
            this.Name = "NewCharacterTab";
            this.Padding = new System.Windows.Forms.Padding(8);
            this.Size = new System.Drawing.Size(358, 323);
            this.AccountInfoGroupBox.ResumeLayout(false);
            this.AccountInfoGroupBox.PerformLayout();
            this.SuccessfullyAddedGroupBox.ResumeLayout(false);
            this.SuccessfullyAddedGroupBox.PerformLayout();
            this.NewCharactersListGroupBox.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.ErrorProvider)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox AccountInfoGroupBox;
        private System.Windows.Forms.TextBox ApiKeyTextBox;
        private System.Windows.Forms.TextBox AccountIdTextBox;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox SuccessfullyAddedGroupBox;
        private System.Windows.Forms.Label CharactesLabel;
        private System.Windows.Forms.Button AddCharactersButton;
        private System.Windows.Forms.GroupBox NewCharactersListGroupBox;
        private System.Windows.Forms.Button AddMoreCharactersButton;
        private System.Windows.Forms.Button LoadCharactersList;
        private System.Windows.Forms.ErrorProvider ErrorProvider;
        private System.Windows.Forms.CheckedListBox NewCharactersCheckedListBox;
    }
}
