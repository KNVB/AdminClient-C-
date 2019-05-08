using System;

namespace FtpAdminClient
{
    partial class ConnectToAdminServerForm
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
            this.serverName = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.portNo = new System.Windows.Forms.NumericUpDown();
            this.label3 = new System.Windows.Forms.Label();
            this.userName = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.password = new System.Windows.Forms.TextBox();
            this.loginButton = new System.Windows.Forms.Button();
            this.cancelButton = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.portNo)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(51, 24);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(0, 15);
            this.label1.TabIndex = 0;
            // 
            // serverName
            // 
            this.serverName.Location = new System.Drawing.Point(143, 14);
            this.serverName.Margin = new System.Windows.Forms.Padding(4);
            this.serverName.Name = "serverName";
            this.serverName.Size = new System.Drawing.Size(227, 25);
            this.serverName.TabIndex = 1;
            this.serverName.Text = "localhost";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(79, 60);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(0, 15);
            this.label2.TabIndex = 2;
            // 
            // portNo
            // 
            this.portNo.Location = new System.Drawing.Point(143, 54);
            this.portNo.Margin = new System.Windows.Forms.Padding(4);
            this.portNo.Maximum = new decimal(new int[] {
            65535,
            0,
            0,
            0});
            this.portNo.Name = "portNo";
            this.portNo.Size = new System.Drawing.Size(228, 25);
            this.portNo.TabIndex = 3;
            this.portNo.Value = new decimal(new int[] {
            4466,
            0,
            0,
            0});
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(63, 96);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(0, 15);
            this.label3.TabIndex = 4;
            // 
            // userName
            // 
            this.userName.Location = new System.Drawing.Point(143, 90);
            this.userName.Margin = new System.Windows.Forms.Padding(4);
            this.userName.Name = "userName";
            this.userName.Size = new System.Drawing.Size(227, 25);
            this.userName.TabIndex = 5;
            this.userName.Text = "admin";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(71, 135);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(0, 15);
            this.label4.TabIndex = 6;
            // 
            // password
            // 
            this.password.Location = new System.Drawing.Point(143, 130);
            this.password.Margin = new System.Windows.Forms.Padding(4);
            this.password.Name = "password";
            this.password.PasswordChar = '*';
            this.password.Size = new System.Drawing.Size(227, 25);
            this.password.TabIndex = 7;
            this.password.Text = "password";
            // 
            // loginButton
            // 
            this.loginButton.Location = new System.Drawing.Point(53, 200);
            this.loginButton.Margin = new System.Windows.Forms.Padding(4);
            this.loginButton.Name = "loginButton";
            this.loginButton.Size = new System.Drawing.Size(100, 29);
            this.loginButton.TabIndex = 8;
            this.loginButton.UseVisualStyleBackColor = true;
            this.loginButton.Click += new System.EventHandler(this.loginButton_Click);
            // 
            // cancelButton
            // 
            this.cancelButton.Location = new System.Drawing.Point(308, 200);
            this.cancelButton.Margin = new System.Windows.Forms.Padding(4);
            this.cancelButton.Name = "cancelButton";
            this.cancelButton.Size = new System.Drawing.Size(100, 29);
            this.cancelButton.TabIndex = 9;
            this.cancelButton.UseVisualStyleBackColor = true;
            this.cancelButton.Click += new System.EventHandler(this.cancelButton_Click);
            // 
            // ConnectToAdminServerForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(464, 276);
            this.Controls.Add(this.cancelButton);
            this.Controls.Add(this.loginButton);
            this.Controls.Add(this.password);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.userName);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.portNo);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.serverName);
            this.Controls.Add(this.label1);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "ConnectToAdminServerForm";
            this.Load += new System.EventHandler(this.ConnectToServerForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.portNo)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox serverName;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.NumericUpDown portNo;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox userName;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox password;
        private System.Windows.Forms.Button loginButton;
        private System.Windows.Forms.Button cancelButton;
    }
}