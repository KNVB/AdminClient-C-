using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using AdminServerObject;
using System.Windows.Forms;

namespace FtpAdminClient
{
    public partial class AddFtpForm : Form
    {
        private AdminServer adminServer;
        public FtpServerInfo ftpServerInfo=null;
        private int controlPortNo = -1;
        private List<string> bindingAddressList =new List<string>();
        private UIManager uiManager;
        public AddFtpForm(AdminServer adminServer, UIManager uiManager)
        {
            InitializeComponent();
            this.adminServer = adminServer;
            this.uiManager = uiManager;
        }

        private void AddFtpForm_Load(object sender, EventArgs e)
        {
            List<string> ipList = adminServer.getIPAddressList();
            ipAddressList.Items.Add("*(All IP address)");
            ipAddressList.SetItemChecked(0, true);
            foreach (var ip in ipList)
            {
                ipAddressList.Items.Add(ip);
            }
            supportPassiveMode.SelectedIndex = 1; //default not support passive mode
        }
        private void addFTPServerButton_Click(object sender, EventArgs e)
        {
            if (isAllInputValid())
            {
                ftpServerInfo = new FtpServerInfo();
                ftpServerInfo.description = serverDesc.Text;
                ftpServerInfo.controlPort= controlPortNo;
                ftpServerInfo.bindingAddresses = bindingAddressList;
                if (supportPassiveMode.Text.Equals("No"))
                    ftpServerInfo.passiveModeEnabled = false;
                else
                {
                    ftpServerInfo.passiveModeEnabled = true;
                    ftpServerInfo.passiveModePortRange = passiveModePortRange.Text;
                }
                adminServer.addFtpServer(ftpServerInfo);
                this.Close();
            }
        }
        private bool isAllInputValid()
        {
            bool result = true;
            List<string> bindingAddressList = new List<string>();
            if (String.IsNullOrEmpty(serverDesc.Text) || (serverDesc.ForeColor == Color.Gray))
            {
                uiManager.popupAlertBox("Please enter the FTP server description.");
                serverDesc.Focus();
                result = false;
            }
            else
            {
                if (!isBindingAddressSelected())
                {
                    uiManager.popupAlertBox("Please select at least one binding address.");
                    ipAddressList.Focus();
                    result = false;
                }
                else
                {
                    controlPortNo = getControlPortNo();
                    if (controlPortNo == -1)
                    {
                        uiManager.popupAlertBox("Please enter an valid control port no.(0-65535).");
                        controlPort.Focus();
                        result = false;
                    }
                    else
                    {
                        if (supportPassiveMode.Text.Equals("Yes"))
                        {
                            if (!Utility.isValidPassiveModePortRange(passiveModePortRange.Text))
                            {
                                result = false;
                                uiManager.popupAlertBox("Please enter an valid TCP port range for passive mode");
                                passiveModePortRange.Focus();
                            }
                        }
                    }    
                }
            }
            return result;
        }
        private void cancelButton_Click(object sender, EventArgs e)
        {
            this.Close();
            this.Dispose();
        }
        private int getControlPortNo()
        {
            return Utility.isValidTCPPortNo(controlPort.Text);
        }
        private bool isBindingAddressSelected()
        {
            bindingAddressList.Clear();
            for (int i = 0; i < ipAddressList.Items.Count; i++)
            {
                if (ipAddressList.GetItemChecked(i))
                    bindingAddressList.Add(ipAddressList.Items[i].ToString());
            }
            return (bindingAddressList.Count > 0);
        }
        
        private void passiveModePortRange_Enter(object sender, EventArgs e)
        {
            if (passiveModePortRange.Text == "e.g. 1000-1005,5000,6000")
            {
                passiveModePortRange.Text = "";
                passiveModePortRange.ForeColor = Color.Black;
            }
        }
        private void passiveModePortRange_Leave(object sender, EventArgs e)
        {
            if (passiveModePortRange.Text == "")
            {
                passiveModePortRange.Text = "e.g. 1000-1005,5000,6000";
                passiveModePortRange.ForeColor = Color.Gray;
            }
        }
        private void serverDesc_Enter(object sender, EventArgs e)
        {
            if (serverDesc.Text == "New Server")
            {
                serverDesc.Text = "";
                serverDesc.ForeColor = Color.Black;
            }
        }
        private void serverDesc_Leave(object sender, EventArgs e)
        {
            if (serverDesc.Text == "")
            {
                serverDesc.Text = "New Server";
                serverDesc.ForeColor = Color.Gray;
            }
        }

        private void supportPassiveMode_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (supportPassiveMode.Text.Equals("Yes"))
                passiveModePortRangePanel.Visible = true;
            else
                passiveModePortRangePanel.Visible = false;
        }
    }
}
