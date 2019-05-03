﻿using AdminServerObject;
using System;
using System.Windows.Forms;

namespace FtpAdminClient
{
    public partial class ConnectToServerForm : Form
    {
        private int adminPortNo = -1;
        private string adminServerName = "";
        private string adminUserName = "", adminUserPassword = "";
        private AdminServerManager adminServerManager;
        private UIManager uiManager;
        public ConnectToServerForm(UIManager uiManager, AdminServerManager adminServerManager)
        {
            InitializeComponent();
            this.uiManager = uiManager;
            this.adminServerManager = adminServerManager;
        }
        private void ConnectToServerForm_Load(object sender, EventArgs e)
        {
            //loginButton_Click(this, new EventArgs());
        }
        private void cancelButton_Click(object sender, EventArgs e)
        {
            this.Close();
            this.Dispose();
            this.DialogResult = DialogResult.No;
        }
        private bool isAllInputValid()
        {
            bool isValidate = true;
            adminServerName = serverName.Text.Trim();
            if (String.IsNullOrEmpty(adminServerName))
            {
                uiManager.popupAlertBox("Please enter the admin. server name or IP address.");
                serverName.Focus();
                isValidate = false;
            }
            else
            {
                if (String.IsNullOrEmpty(portNo.Text))
                {
                    uiManager.popupAlertBox("Please enter the admin. server port no. (0-65535).");
                    portNo.Focus();
                    isValidate = false;
                }
                else
                {
                    adminPortNo = Convert.ToInt32(portNo.Text);
                    adminUserName = userName.Text.Trim();
                    if (String.IsNullOrEmpty(adminUserName))
                    {
                        uiManager.popupAlertBox("Please enter the admin. user name.");
                        userName.Focus();
                        isValidate = false;
                    }
                    else
                    {
                        adminUserPassword = password.Text.Trim();
                        if (String.IsNullOrEmpty(adminUserPassword))
                        {
                            uiManager.popupAlertBox("Please enter the admin. user password.");
                            password.Focus();
                            isValidate = false;
                        }
                    }
                }
            }
            return isValidate;
        }
        private void loginButton_Click(object sender, EventArgs e)
        {
            adminServerName = serverName.Text.Trim();
            adminUserName = userName.Text.Trim();
            adminUserPassword = password.Text.Trim();

            if (isAllInputValid())
            {
                Cursor.Current = Cursors.WaitCursor;
                try
                {
                    int result =adminServerManager.addAdminServer(adminServerName, adminPortNo, adminUserName, adminUserPassword);
                    switch (result)
                    {
                        case 0:
                            this.DialogResult = DialogResult.OK;
                            this.Close();
                            break;
                        case 1:
                            uiManager.popupAlertBox("The specified server have been added");
                            break;
                        case 2:
                            uiManager.popupAlertBox("Invalid admin. server name or port no.");
                            break;
                        case 3:
                            uiManager.popupAlertBox("Invalid admin. user or password");
                            break;
                    }
                }
                catch (Exception err)
                {
                    uiManager.popupAlertBox(err.Message);
                }
                Cursor.Current = Cursors.Default;
            }
        }      

        private void enterKeyHandler(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                loginButton_Click(this, new EventArgs());
            }
        }
    }
}
