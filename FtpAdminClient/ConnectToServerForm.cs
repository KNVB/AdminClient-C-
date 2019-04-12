using System;
using System.Windows.Forms;

namespace FtpAdminClient
{
    public partial class ConnectToServerForm : Form
    {
        private int adminPortNo = -1;
        private string adminServerName = "";
        private string adminUserName = "", adminUserPassword = "";
        private UIManager uiManager;
        public ConnectToServerForm(UIManager uiManager)
        {
            InitializeComponent();
            this.uiManager = uiManager;
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
        private void loginButton_Click(object sender, EventArgs e)
        {
            adminServerName = serverName.Text.Trim();
            adminUserName = userName.Text.Trim();
            adminUserPassword = password.Text.Trim();
            /*     
                 int result=uiManager.addAdminServer(adminServerName, portNo.Text, adminUserName, adminUserPassword);
                 switch (result)
                 {
                     case 0:
                             this.DialogResult = DialogResult.OK;
                             this.Close();
                             break;
                     case -1:
                             serverName.Focus();
                             break;
                     case -2:
                             portNo.Focus();
                             break;
                     case -3:
                             userName.Focus();
                             break;
                     case -4:
                             password.Focus();
                             break;
                 }*/
        }
        private void password_KeyDown(object sender, KeyEventArgs e)
        {
           /* if (e.KeyCode == Keys.Enter)
            {
                loginButton_Click(this, new EventArgs());
            }*/
        }
    }
}
