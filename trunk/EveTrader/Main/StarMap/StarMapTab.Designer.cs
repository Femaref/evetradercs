using System.Windows.Forms;

namespace EveTrader.Main.StarMap
{
    partial class StarMapTab
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
            System.Windows.Forms.ColumnHeader Sign;
            System.Windows.Forms.ColumnHeader SystemName;
            System.Windows.Forms.ColumnHeader Security;
            System.Windows.Forms.ColumnHeader Dummy;
            this.label4 = new System.Windows.Forms.Label();
            this.FromTextBox = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.ToTextBox = new System.Windows.Forms.TextBox();
            this.SuggestionMenuStrip = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.toolStripMenuItem2 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem3 = new System.Windows.Forms.ToolStripMenuItem();
            this.FindRouteButton = new System.Windows.Forms.Button();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.splitContainer2 = new System.Windows.Forms.SplitContainer();
            this.RouteJumpsCountLabel = new System.Windows.Forms.Label();
            this.RouteListView = new System.Windows.Forms.ListView();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label2 = new System.Windows.Forms.Label();
            Sign = new System.Windows.Forms.ColumnHeader();
            SystemName = new System.Windows.Forms.ColumnHeader();
            Security = new System.Windows.Forms.ColumnHeader();
            Dummy = new System.Windows.Forms.ColumnHeader();
            this.SuggestionMenuStrip.SuspendLayout();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.splitContainer2.Panel1.SuspendLayout();
            this.splitContainer2.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // Sign
            // 
            Sign.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            Sign.Width = 20;
            // 
            // SystemName
            // 
            SystemName.Width = 120;
            // 
            // Security
            // 
            Security.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            Security.Width = 36;
            // 
            // Dummy
            // 
            Dummy.Width = 0;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(24, 13);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(30, 13);
            this.label4.TabIndex = 19;
            this.label4.Text = "From";
            // 
            // FromTextBox
            // 
            this.FromTextBox.Location = new System.Drawing.Point(60, 11);
            this.FromTextBox.Name = "FromTextBox";
            this.FromTextBox.Size = new System.Drawing.Size(209, 20);
            this.FromTextBox.TabIndex = 20;
            this.FromTextBox.Text = "Rens";
            this.FromTextBox.KeyUp += new System.Windows.Forms.KeyEventHandler(this.TextBox_Suggest);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(288, 14);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(20, 13);
            this.label1.TabIndex = 21;
            this.label1.Text = "To";
            // 
            // ToTextBox
            // 
            this.ToTextBox.Location = new System.Drawing.Point(314, 11);
            this.ToTextBox.Name = "ToTextBox";
            this.ToTextBox.Size = new System.Drawing.Size(209, 20);
            this.ToTextBox.TabIndex = 22;
            this.ToTextBox.Text = "Jita";
            this.ToTextBox.KeyUp += new System.Windows.Forms.KeyEventHandler(this.TextBox_Suggest);
            // 
            // SuggestionMenuStrip
            // 
            this.SuggestionMenuStrip.AccessibleRole = System.Windows.Forms.AccessibleRole.ListItem;
            this.SuggestionMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItem2,
            this.toolStripMenuItem3});
            this.SuggestionMenuStrip.Name = "SuggestionMenuStrip";
            this.SuggestionMenuStrip.ShowImageMargin = false;
            this.SuggestionMenuStrip.Size = new System.Drawing.Size(67, 48);
            // 
            // toolStripMenuItem2
            // 
            this.toolStripMenuItem2.Name = "toolStripMenuItem2";
            this.toolStripMenuItem2.Size = new System.Drawing.Size(66, 22);
            this.toolStripMenuItem2.Text = "1";
            // 
            // toolStripMenuItem3
            // 
            this.toolStripMenuItem3.Name = "toolStripMenuItem3";
            this.toolStripMenuItem3.Size = new System.Drawing.Size(66, 22);
            this.toolStripMenuItem3.Text = "2";
            // 
            // FindRouteButton
            // 
            this.FindRouteButton.Location = new System.Drawing.Point(545, 8);
            this.FindRouteButton.Name = "FindRouteButton";
            this.FindRouteButton.Size = new System.Drawing.Size(75, 23);
            this.FindRouteButton.TabIndex = 25;
            this.FindRouteButton.Text = "Find route";
            this.FindRouteButton.UseVisualStyleBackColor = true;
            this.FindRouteButton.Click += new System.EventHandler(this.FindRouteButton_Click);
            // 
            // splitContainer1
            // 
            this.splitContainer1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.splitContainer1.Location = new System.Drawing.Point(0, 40);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.splitContainer2);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.panel1);
            this.splitContainer1.Size = new System.Drawing.Size(855, 478);
            this.splitContainer1.SplitterDistance = 267;
            this.splitContainer1.TabIndex = 27;
            // 
            // splitContainer2
            // 
            this.splitContainer2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer2.Location = new System.Drawing.Point(0, 0);
            this.splitContainer2.Name = "splitContainer2";
            this.splitContainer2.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer2.Panel1
            // 
            this.splitContainer2.Panel1.Controls.Add(this.RouteJumpsCountLabel);
            this.splitContainer2.Panel1.Controls.Add(this.RouteListView);
            this.splitContainer2.Panel2Collapsed = true;
            this.splitContainer2.Size = new System.Drawing.Size(267, 478);
            this.splitContainer2.SplitterDistance = 320;
            this.splitContainer2.TabIndex = 0;
            // 
            // RouteJumpsCountLabel
            // 
            this.RouteJumpsCountLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.RouteJumpsCountLabel.AutoSize = true;
            this.RouteJumpsCountLabel.Location = new System.Drawing.Point(3, 455);
            this.RouteJumpsCountLabel.Name = "RouteJumpsCountLabel";
            this.RouteJumpsCountLabel.Size = new System.Drawing.Size(0, 13);
            this.RouteJumpsCountLabel.TabIndex = 28;
            // 
            // RouteListView
            // 
            this.RouteListView.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.RouteListView.CausesValidation = false;
            this.RouteListView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            Dummy,
            Sign,
            Security,
            SystemName});
            this.RouteListView.FullRowSelect = true;
            this.RouteListView.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.None;
            this.RouteListView.Location = new System.Drawing.Point(0, 0);
            this.RouteListView.MultiSelect = false;
            this.RouteListView.Name = "RouteListView";
            this.RouteListView.Size = new System.Drawing.Size(267, 452);
            this.RouteListView.TabIndex = 27;
            this.RouteListView.UseCompatibleStateImageBehavior = false;
            this.RouteListView.View = System.Windows.Forms.View.Details;
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(223)))), ((int)(((byte)(219)))), ((int)(((byte)(210)))));
            this.panel1.Controls.Add(this.label2);
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Margin = new System.Windows.Forms.Padding(0, 0, 3, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(581, 452);
            this.panel1.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label2.ForeColor = System.Drawing.SystemColors.Control;
            this.label2.Location = new System.Drawing.Point(128, 223);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(408, 31);
            this.label2.TabIndex = 1;
            this.label2.Text = "Star map here (not implemented)";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // StarMapTab
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.splitContainer1);
            this.Controls.Add(this.ToTextBox);
            this.Controls.Add(this.FromTextBox);
            this.Controls.Add(this.FindRouteButton);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label4);
            this.Name = "StarMapTab";
            this.Size = new System.Drawing.Size(855, 518);
            this.SuggestionMenuStrip.ResumeLayout(false);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.ResumeLayout(false);
            this.splitContainer2.Panel1.ResumeLayout(false);
            this.splitContainer2.Panel1.PerformLayout();
            this.splitContainer2.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox FromTextBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox ToTextBox;
        private System.Windows.Forms.ContextMenuStrip SuggestionMenuStrip;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem2;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem3;
        private System.Windows.Forms.Button FindRouteButton;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.SplitContainer splitContainer2;
        private System.Windows.Forms.ListView RouteListView;
        private Label RouteJumpsCountLabel;
        private Panel panel1;
        private Label label2;
    }
}
