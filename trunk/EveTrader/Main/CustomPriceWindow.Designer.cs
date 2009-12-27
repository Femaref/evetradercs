namespace EveTrader.Main
{
    partial class CustomPriceWindow
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
            this.components = new System.ComponentModel.Container();
            this.MainGroupBox = new System.Windows.Forms.GroupBox();
            this.SellPriceTextBox = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.BuyPriceTextBox = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.Save = new System.Windows.Forms.Button();
            this.Cancel = new System.Windows.Forms.Button();
            this.SellPriceErrorProvider = new System.Windows.Forms.ErrorProvider(this.components);
            this.BuyPriceErrorProvider = new System.Windows.Forms.ErrorProvider(this.components);
            this.MainGroupBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.SellPriceErrorProvider)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.BuyPriceErrorProvider)).BeginInit();
            this.SuspendLayout();
            // 
            // MainGroupBox
            // 
            this.MainGroupBox.Controls.Add(this.SellPriceTextBox);
            this.MainGroupBox.Controls.Add(this.label1);
            this.MainGroupBox.Controls.Add(this.BuyPriceTextBox);
            this.MainGroupBox.Controls.Add(this.label2);
            this.MainGroupBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.MainGroupBox.Location = new System.Drawing.Point(15, 11);
            this.MainGroupBox.Name = "MainGroupBox";
            this.MainGroupBox.Size = new System.Drawing.Size(328, 92);
            this.MainGroupBox.TabIndex = 6;
            this.MainGroupBox.TabStop = false;
            this.MainGroupBox.Text = "Tungeston charge";
            // 
            // SellPriceTextBox
            // 
            this.SellPriceTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.SellPriceTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.SellPriceTextBox.Location = new System.Drawing.Point(112, 54);
            this.SellPriceTextBox.Name = "SellPriceTextBox";
            this.SellPriceTextBox.Size = new System.Drawing.Size(187, 20);
            this.SellPriceTextBox.TabIndex = 11;
            this.SellPriceTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.SellPriceTextBox.Validated += new System.EventHandler(this.SellPriceTextBox_Validated);
            this.SellPriceTextBox.Enter += new System.EventHandler(this.SellPriceTextBox_Enter);
            this.SellPriceTextBox.Validating += new System.ComponentModel.CancelEventHandler(this.SellPriceTextBox_Validating);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.Location = new System.Drawing.Point(17, 57);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(89, 13);
            this.label1.TabIndex = 10;
            this.label1.Text = "Custom sell price:";
            // 
            // BuyPriceTextBox
            // 
            this.BuyPriceTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.BuyPriceTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.BuyPriceTextBox.Location = new System.Drawing.Point(112, 28);
            this.BuyPriceTextBox.Name = "BuyPriceTextBox";
            this.BuyPriceTextBox.Size = new System.Drawing.Size(187, 20);
            this.BuyPriceTextBox.TabIndex = 7;
            this.BuyPriceTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.BuyPriceTextBox.Validated += new System.EventHandler(this.BuyPriceTextBox_Validated);
            this.BuyPriceTextBox.Enter += new System.EventHandler(this.BuyPriceTextBox_Enter);
            this.BuyPriceTextBox.Validating += new System.ComponentModel.CancelEventHandler(this.BuyPriceTextBox_Validating);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label2.Location = new System.Drawing.Point(15, 31);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(91, 13);
            this.label2.TabIndex = 6;
            this.label2.Text = "Custom buy price:";
            // 
            // Save
            // 
            this.Save.Location = new System.Drawing.Point(85, 120);
            this.Save.Name = "Save";
            this.Save.Size = new System.Drawing.Size(91, 23);
            this.Save.TabIndex = 7;
            this.Save.Text = "Save";
            this.Save.UseVisualStyleBackColor = true;
            this.Save.Click += new System.EventHandler(this.SaveButton_Click);
            // 
            // Cancel
            // 
            this.Cancel.Location = new System.Drawing.Point(182, 120);
            this.Cancel.Name = "Cancel";
            this.Cancel.Size = new System.Drawing.Size(91, 23);
            this.Cancel.TabIndex = 8;
            this.Cancel.Text = "Cancel";
            this.Cancel.UseVisualStyleBackColor = true;
            this.Cancel.Click += new System.EventHandler(this.CancelButton_Click);
            // 
            // SellPriceErrorProvider
            // 
            this.SellPriceErrorProvider.BlinkRate = 0;
            this.SellPriceErrorProvider.BlinkStyle = System.Windows.Forms.ErrorBlinkStyle.NeverBlink;
            this.SellPriceErrorProvider.ContainerControl = this;
            // 
            // BuyPriceErrorProvider
            // 
            this.BuyPriceErrorProvider.BlinkRate = 0;
            this.BuyPriceErrorProvider.BlinkStyle = System.Windows.Forms.ErrorBlinkStyle.NeverBlink;
            this.BuyPriceErrorProvider.ContainerControl = this;
            // 
            // CustomPriceWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(359, 155);
            this.Controls.Add(this.Cancel);
            this.Controls.Add(this.Save);
            this.Controls.Add(this.MainGroupBox);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "CustomPriceWindow";
            this.Padding = new System.Windows.Forms.Padding(0, 8, 0, 0);
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Set custom price";
            this.MainGroupBox.ResumeLayout(false);
            this.MainGroupBox.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.SellPriceErrorProvider)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.BuyPriceErrorProvider)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox MainGroupBox;
        private System.Windows.Forms.TextBox BuyPriceTextBox;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button Save;
        private System.Windows.Forms.Button Cancel;
        private System.Windows.Forms.ErrorProvider SellPriceErrorProvider;
        private System.Windows.Forms.TextBox SellPriceTextBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ErrorProvider BuyPriceErrorProvider;

    }
}