namespace FtpAdminClient
{
    partial class NetworkPropertiesForm
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
            this.label1 = new System.Windows.Forms.Label();
            this.serverDesc = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.ipAddressList = new System.Windows.Forms.CheckedListBox();
            this.label3 = new System.Windows.Forms.Label();
            this.controlPort = new System.Windows.Forms.TextBox();
            this.passiveModePortRangeLabel = new System.Windows.Forms.Label();
            this.passiveModePortRange = new System.Windows.Forms.TextBox();
            this.actionButton = new System.Windows.Forms.Button();
            this.cancelButton = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.supportPassiveMode = new System.Windows.Forms.ComboBox();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Dock = System.Windows.Forms.DockStyle.Right;
            this.label1.Location = new System.Drawing.Point(126, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(10, 28);
            this.label1.TabIndex = 0;
            this.label1.Text = "a";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // serverDesc
            // 
            this.serverDesc.Dock = System.Windows.Forms.DockStyle.Left;
            this.serverDesc.ForeColor = System.Drawing.SystemColors.GrayText;
            this.serverDesc.Location = new System.Drawing.Point(142, 3);
            this.serverDesc.Name = "serverDesc";
            this.serverDesc.Size = new System.Drawing.Size(240, 22);
            this.serverDesc.TabIndex = 1;
            this.serverDesc.Text = "New Server";
            this.serverDesc.GotFocus += new System.EventHandler(this.serverDesc_Enter);
            this.serverDesc.LostFocus += new System.EventHandler(this.serverDesc_Leave);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Dock = System.Windows.Forms.DockStyle.Right;
            this.label2.Location = new System.Drawing.Point(126, 28);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(10, 129);
            this.label2.TabIndex = 2;
            this.label2.Text = "a";
            // 
            // ipAddressList
            // 
            this.ipAddressList.FormattingEnabled = true;
            this.ipAddressList.Location = new System.Drawing.Point(142, 31);
            this.ipAddressList.Name = "ipAddressList";
            this.ipAddressList.Size = new System.Drawing.Size(240, 123);
            this.ipAddressList.TabIndex = 3;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Dock = System.Windows.Forms.DockStyle.Right;
            this.label3.Location = new System.Drawing.Point(126, 157);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(10, 26);
            this.label3.TabIndex = 4;
            this.label3.Text = "a";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // controlPort
            // 
            this.controlPort.Dock = System.Windows.Forms.DockStyle.Left;
            this.controlPort.Location = new System.Drawing.Point(142, 160);
            this.controlPort.Name = "controlPort";
            this.controlPort.Size = new System.Drawing.Size(100, 22);
            this.controlPort.TabIndex = 5;
            this.controlPort.Text = "21";
            // 
            // passiveModePortRangeLabel
            // 
            this.passiveModePortRangeLabel.AutoSize = true;
            this.passiveModePortRangeLabel.Dock = System.Windows.Forms.DockStyle.Right;
            this.passiveModePortRangeLabel.Location = new System.Drawing.Point(126, 208);
            this.passiveModePortRangeLabel.Name = "passiveModePortRangeLabel";
            this.passiveModePortRangeLabel.Size = new System.Drawing.Size(10, 29);
            this.passiveModePortRangeLabel.TabIndex = 8;
            this.passiveModePortRangeLabel.Text = "a";
            this.passiveModePortRangeLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.passiveModePortRangeLabel.Visible = false;
            // 
            // passiveModePortRange
            // 
            this.passiveModePortRange.Dock = System.Windows.Forms.DockStyle.Left;
            this.passiveModePortRange.ForeColor = System.Drawing.SystemColors.GrayText;
            this.passiveModePortRange.Location = new System.Drawing.Point(142, 211);
            this.passiveModePortRange.Name = "passiveModePortRange";
            this.passiveModePortRange.Size = new System.Drawing.Size(240, 22);
            this.passiveModePortRange.TabIndex = 9;
            this.passiveModePortRange.Text = "e.g. 1000-1005,5000,6000";
            this.passiveModePortRange.Visible = false;
            this.passiveModePortRange.GotFocus += new System.EventHandler(this.passiveModePortRange_Enter);
            this.passiveModePortRange.LostFocus += new System.EventHandler(this.passiveModePortRange_Leave);
            // 
            // actionButton
            // 
            this.actionButton.Location = new System.Drawing.Point(62, 291);
            this.actionButton.Name = "actionButton";
            this.actionButton.Size = new System.Drawing.Size(121, 23);
            this.actionButton.TabIndex = 11;
            this.actionButton.UseVisualStyleBackColor = true;
            // 
            // cancelButton
            // 
            this.cancelButton.Location = new System.Drawing.Point(285, 291);
            this.cancelButton.Name = "cancelButton";
            this.cancelButton.Size = new System.Drawing.Size(119, 23);
            this.cancelButton.TabIndex = 12;
            this.cancelButton.UseVisualStyleBackColor = true;
            this.cancelButton.Click += new System.EventHandler(this.cancelButton_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Dock = System.Windows.Forms.DockStyle.Right;
            this.label4.Location = new System.Drawing.Point(126, 183);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(10, 25);
            this.label4.TabIndex = 6;
            this.label4.Text = "a";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // supportPassiveMode
            // 
            this.supportPassiveMode.Dock = System.Windows.Forms.DockStyle.Left;
            this.supportPassiveMode.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.supportPassiveMode.FormattingEnabled = true;
            this.supportPassiveMode.Location = new System.Drawing.Point(142, 186);
            this.supportPassiveMode.Name = "supportPassiveMode";
            this.supportPassiveMode.Size = new System.Drawing.Size(121, 20);
            this.supportPassiveMode.TabIndex = 7;
            this.supportPassiveMode.SelectedIndexChanged += new System.EventHandler(this.supportPassiveMode_SelectedIndexChanged);
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 29.0795F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 70.9205F));
            this.tableLayoutPanel1.Controls.Add(this.passiveModePortRangeLabel, 0, 4);
            this.tableLayoutPanel1.Controls.Add(this.label1, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.serverDesc, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.passiveModePortRange, 1, 4);
            this.tableLayoutPanel1.Controls.Add(this.supportPassiveMode, 1, 3);
            this.tableLayoutPanel1.Controls.Add(this.label2, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.label4, 0, 3);
            this.tableLayoutPanel1.Controls.Add(this.controlPort, 1, 2);
            this.tableLayoutPanel1.Controls.Add(this.label3, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.ipAddressList, 1, 1);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(18, 22);
            this.tableLayoutPanel1.Margin = new System.Windows.Forms.Padding(0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 5;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 17.83439F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 82.1656F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 26F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 28F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(478, 237);
            this.tableLayoutPanel1.TabIndex = 13;
            // 
            // NetworkPropertiesForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(520, 333);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Controls.Add(this.cancelButton);
            this.Controls.Add(this.actionButton);
            this.Name = "NetworkPropertiesForm";
            this.Load += new System.EventHandler(this.NetworkPropertiesForm_Load);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        
        internal System.Windows.Forms.TextBox serverDesc;
        internal System.Windows.Forms.CheckedListBox ipAddressList;
        internal System.Windows.Forms.TextBox controlPort;
        internal System.Windows.Forms.TextBox passiveModePortRange;
        internal System.Windows.Forms.Button actionButton;
        internal System.Windows.Forms.ComboBox supportPassiveMode;
        internal System.Windows.Forms.Label passiveModePortRangeLabel;

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
       
        private System.Windows.Forms.Button cancelButton;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
    }
}