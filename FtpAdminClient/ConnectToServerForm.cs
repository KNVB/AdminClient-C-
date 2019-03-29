using ObjectLibrary;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace FtpAdminClient
{
    public partial class ConnectToServerForm : Form
    {
        private FtpAdminClient ftpAdminClient;
        private int adminPortNo = -1;
        private string adminServerName = "";
        private string adminUserName = "", adminUserPassword = "";
        public ConnectToServerForm(FtpAdminClient ftpAdminClient)
        {
            InitializeComponent();
            this.ftpAdminClient = ftpAdminClient;
           /* adminServer = null;
            this.adminServerList = adminServerList;*/
        }
        private void ConnectToServerForm_Load(object sender, EventArgs e)
        {
            loginButton_Click(this, new EventArgs());
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
                Ui_Utility.popupAlertBox("Please enter the admin. server name or IP address.");
                serverName.Focus();
                isValidate = false;
            }
            else
            {
                if (String.IsNullOrEmpty(portNo.Text))
                {
                    Ui_Utility.popupAlertBox("Please enter the admin. server port no. (0-65535).");
                    portNo.Focus();
                    isValidate = false;
                }
                else
                {
                    adminPortNo = Convert.ToInt32(portNo.Text);
                    adminUserName = userName.Text.Trim();
                    if (String.IsNullOrEmpty(adminUserName))
                    {
                        Ui_Utility.popupAlertBox("Please enter the admin. user name.");
                        userName.Focus();
                        isValidate = false;
                    }
                    else
                    {
                        adminUserPassword = password.Text.Trim();
                        if (String.IsNullOrEmpty(adminUserPassword))
                        {
                            Ui_Utility.popupAlertBox("Please enter the admin. user password.");
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
            if (isAllInputValid())
            {
                Cursor.Current = Cursors.WaitCursor;
                try
                {
                    int result = ftpAdminClient.addRemoteServer(adminServerName, adminPortNo, adminUserName, adminUserPassword);
                    switch (result)
                    {
                        case 0:
                            this.DialogResult = DialogResult.OK;
                            this.Close();
                            break;
                        case 1:
                            MessageBox.Show("The specified server have been added", "Alert", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            break;
                        case 2:
                            MessageBox.Show( "Invalid admin. server name or port no.", "Alert", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            break;
                        case 3:
                            MessageBox.Show("Invalid admin. user or password", "Alert", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            break;
                    }
                }
                catch (Exception err)
                {
                    MessageBox.Show(this, err.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                Cursor.Current = Cursors.Default;
            }
        }
        private void password_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                loginButton_Click(this, new EventArgs());
            }
        }
    }
}
