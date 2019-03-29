using System;

namespace FtpAdminClient
{
    partial class AddFtpForm
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
            this.addFTPServerButton = new System.Windows.Forms.Button();
            this.cancelButton = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.supportPassiveMode = new System.Windows.Forms.ComboBox();
            this.passiveModePortRangePanel = new System.Windows.Forms.Panel();
            this.passiveModePortRangePanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(52, 22);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(94, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "Server Description:";
            // 
            // serverDesc
            // 
            this.serverDesc.ForeColor = System.Drawing.SystemColors.GrayText;
            this.serverDesc.Location = new System.Drawing.Point(153, 22);
            this.serverDesc.Name = "serverDesc";
            this.serverDesc.Size = new System.Drawing.Size(271, 22);
            this.serverDesc.TabIndex = 1;
            this.serverDesc.Text = "New Server";
            this.serverDesc.GotFocus += new System.EventHandler(this.serverDesc_Enter);
            this.serverDesc.LostFocus += new System.EventHandler(this.serverDesc_Leave);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(60, 64);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(86, 12);
            this.label2.TabIndex = 2;
            this.label2.Text = "Binding Address:";
            // 
            // ipAddressList
            // 
            this.ipAddressList.FormattingEnabled = true;
            this.ipAddressList.Location = new System.Drawing.Point(153, 64);
            this.ipAddressList.Name = "ipAddressList";
            this.ipAddressList.Size = new System.Drawing.Size(271, 89);
            this.ipAddressList.TabIndex = 3;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(5, 163);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(141, 12);
            this.label3.TabIndex = 4;
            this.label3.Text = "Control Port No.(default 21):";
            // 
            // controlPort
            // 
            this.controlPort.Location = new System.Drawing.Point(153, 160);
            this.controlPort.Name = "controlPort";
            this.controlPort.Size = new System.Drawing.Size(100, 22);
            this.controlPort.TabIndex = 5;
            this.controlPort.Text = "21";
            // 
            // passiveModePortRangeLabel
            // 
            this.passiveModePortRangeLabel.AutoSize = true;
            this.passiveModePortRangeLabel.Location = new System.Drawing.Point(8, 6);
            this.passiveModePortRangeLabel.Name = "passiveModePortRangeLabel";
            this.passiveModePortRangeLabel.Size = new System.Drawing.Size(126, 12);
            this.passiveModePortRangeLabel.TabIndex = 8;
            this.passiveModePortRangeLabel.Text = "Passive Mode Port Range:";
            // 
            // passiveModePortRange
            // 
            this.passiveModePortRange.ForeColor = System.Drawing.SystemColors.GrayText;
            this.passiveModePortRange.Location = new System.Drawing.Point(141, 3);
            this.passiveModePortRange.Name = "passiveModePortRange";
            this.passiveModePortRange.Size = new System.Drawing.Size(271, 22);
            this.passiveModePortRange.TabIndex = 9;
            this.passiveModePortRange.Text = "e.g. 1000-1005,5000,6000";
            this.passiveModePortRange.GotFocus += new System.EventHandler(this.passiveModePortRange_Enter);
            this.passiveModePortRange.LostFocus += new System.EventHandler(this.passiveModePortRange_Leave);
            // 
            // addFTPServerButton
            // 
            this.addFTPServerButton.Location = new System.Drawing.Point(62, 291);
            this.addFTPServerButton.Name = "addFTPServerButton";
            this.addFTPServerButton.Size = new System.Drawing.Size(121, 23);
            this.addFTPServerButton.TabIndex = 11;
            this.addFTPServerButton.Text = "Add";
            this.addFTPServerButton.UseVisualStyleBackColor = true;
            this.addFTPServerButton.Click += new System.EventHandler(this.addFTPServerButton_Click);
            // 
            // cancelButton
            // 
            this.cancelButton.Location = new System.Drawing.Point(275, 291);
            this.cancelButton.Name = "cancelButton";
            this.cancelButton.Size = new System.Drawing.Size(119, 23);
            this.cancelButton.TabIndex = 12;
            this.cancelButton.Text = "Cancel";
            this.cancelButton.UseVisualStyleBackColor = true;
            this.cancelButton.Click += new System.EventHandler(this.cancelButton_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(33, 200);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(113, 12);
            this.label4.TabIndex = 6;
            this.label4.Text = "Support Passive Mode?";
            // 
            // supportPassiveMode
            // 
            this.supportPassiveMode.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.supportPassiveMode.FormattingEnabled = true;
            this.supportPassiveMode.Items.AddRange(new object[] {
            "Yes",
            "No"});
            this.supportPassiveMode.Location = new System.Drawing.Point(153, 197);
            this.supportPassiveMode.Name = "supportPassiveMode";
            this.supportPassiveMode.Size = new System.Drawing.Size(121, 20);
            this.supportPassiveMode.TabIndex = 7;
            this.supportPassiveMode.SelectedIndexChanged += new System.EventHandler(this.supportPassiveMode_SelectedIndexChanged);
            // 
            // passiveModePortRangePanel
            // 
            this.passiveModePortRangePanel.Controls.Add(this.passiveModePortRange);
            this.passiveModePortRangePanel.Controls.Add(this.passiveModePortRangeLabel);
            this.passiveModePortRangePanel.Location = new System.Drawing.Point(12, 228);
            this.passiveModePortRangePanel.Name = "passiveModePortRangePanel";
            this.passiveModePortRangePanel.Size = new System.Drawing.Size(412, 32);
            this.passiveModePortRangePanel.TabIndex = 10;
            this.passiveModePortRangePanel.Visible = false;
            // 
            // AddFtpForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(443, 340);
            this.Controls.Add(this.cancelButton);
            this.Controls.Add(this.addFTPServerButton);
            this.Controls.Add(this.passiveModePortRangePanel);
            this.Controls.Add(this.supportPassiveMode);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.controlPort);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.ipAddressList);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.serverDesc);
            this.Controls.Add(this.label1);
            this.Name = "AddFtpForm";
            this.Text = "Add FTP Server";
            this.Load += new System.EventHandler(this.AddFtpForm_Load);
            this.passiveModePortRangePanel.ResumeLayout(false);
            this.passiveModePortRangePanel.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox serverDesc;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.CheckedListBox ipAddressList;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox controlPort;
        private System.Windows.Forms.Label passiveModePortRangeLabel;
        private System.Windows.Forms.TextBox passiveModePortRange;
        private System.Windows.Forms.Button addFTPServerButton;
        private System.Windows.Forms.Button cancelButton;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox supportPassiveMode;
        private System.Windows.Forms.Panel passiveModePortRangePanel;
    }
}