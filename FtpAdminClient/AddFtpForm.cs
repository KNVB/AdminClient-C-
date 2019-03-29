using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using ObjectLibrary;
using System.Windows.Forms;

namespace FtpAdminClient
{
    public partial class AddFtpForm : Form
    {
        AdminServer adminServer;
        List<string> bindingAddressList =new List<string>();
        public AddFtpForm(AdminServer adminServer)
        {
            InitializeComponent();
            this.adminServer = adminServer;
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
            isAllInputValid();
        }
        private bool isAllInputValid()
        {
            bool result = true;
            int controlPortNo=-1;
            List<string> bindingAddressList = new List<string>();
            if (String.IsNullOrEmpty(serverDesc.Text) || (serverDesc.ForeColor == Color.Gray))
            {
                Utility.popupAlertBox("Please enter the FTP server description.");
                serverDesc.Focus();
                result = false;
            }
            else
            {
                if (!isBindingAddressSelected())
                {
                    Utility.popupAlertBox("Please select at least one binding address.");
                    ipAddressList.Focus();
                    result = false;
                }
                else
                {
                    controlPortNo = getControlPortNo();
                    if (controlPortNo == -1)
                    {
                        Utility.popupAlertBox("Please enter an valid control port no.(0-65535).");
                        controlPort.Focus();
                        result = false;
                    }
                    else
                    {
                        if (supportPassiveMode.Text.Equals("Yes"))
                        {
                            if (!isValidPassiveModePortRange())
                            {
                                result = false;
                                Utility.popupAlertBox("Please enter an valid port range  for passive mode");
                                supportPassiveMode.Focus();
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
        private bool isValidPassiveModePortRange()
        {
            int portNo;
            bool result=true;
            if (String.IsNullOrEmpty(passiveModePortRange.Text))
                result = false;
            else
            {
                if ((passiveModePortRange.Text.IndexOf(",") == -1) && (passiveModePortRange.Text.IndexOf("-") == -1))
                {
                    portNo = Utility.isValidTCPPortNo(passiveModePortRange.Text);
                    if (portNo==-1)
                        result = false;
                }
                else
                {
                    string[] ports = passiveModePortRange.Text.Split(',');
                    foreach (string port in ports)
                    {
                        if (Utility.isValidTCPPortNo(port) == -1)
                        {
                            result = false;
                            break;
                        }
                    }
                    if (result == true)
                    {
                        ports = passiveModePortRange.Text.Split('-');
                        foreach (string port in ports)
                        {
                            if (Utility.isValidTCPPortNo(port) == -1)
                            {
                                result = false;
                                break;
                            }
                        }
                    }
                }

            }
            return result;
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
