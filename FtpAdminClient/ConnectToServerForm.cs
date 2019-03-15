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
                MessageBox.Show(this, "Please enter the admin. server name or IP address.", "Alert");
                serverName.Focus();
                isValidate = false;
            }
            else
            {
                if (String.IsNullOrEmpty(portNo.Text))
                {
                    MessageBox.Show(this, "Please enter the admin. server port no. (0-65535).", "Alert");
                    portNo.Focus();
                    isValidate = false;
                }
                else
                {
                    adminPortNo = Convert.ToInt32(portNo.Text);
                    adminUserName = userName.Text.Trim();
                    if (String.IsNullOrEmpty(adminUserName))
                    {
                        MessageBox.Show(this, "Please enter the admin. user name.", "Alert");
                        userName.Focus();
                        isValidate = false;
                    }
                    else
                    {
                        adminUserPassword = password.Text.Trim();
                        if (String.IsNullOrEmpty(adminUserPassword))
                        {
                            MessageBox.Show(this, "Please enter the admin. user password.", "Alert");
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
                int result=ftpAdminClient.addRemoteServer(adminServerName, adminPortNo, adminUserName, adminUserPassword);
                switch (result)
                {
                    case 0:
                            this.DialogResult = DialogResult.OK;
                            this.Close();
                            break;
                    case 1:
                            MessageBox.Show(this, "The specified server have been added", "Alert");
                            break;
                    case 2:
                            MessageBox.Show(this, "Invalid admin. server name or port no.", "Alert");
                            break;
                    case 3:
                            MessageBox.Show(this, "Invalid admin. user or password", "Alert");
                            break;
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
