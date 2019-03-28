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
        public AddFtpForm(AdminServer adminServer)
        {
            InitializeComponent();
            this.adminServer = adminServer;
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

        private void AddFtpForm_Load(object sender, EventArgs e)
        {
            List<string> ipList = adminServer.getIPAddressList();
            ipAddressList.Items.Clear();
            foreach(var ip in ipList)
            {
                ipAddressList.Items.Add(ip);
            }
        }
        private void supportPassiveMode_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (supportPassiveMode.Text.Equals("Yes"))
                passiveModePortRangePanel.Visible = true;
            else
                passiveModePortRangePanel.Visible = false;
        }

        private void cancelButton_Click(object sender, EventArgs e)
        {
            this.Close();
            this.Dispose();
        }

        private void addFTPServerButton_Click(object sender, EventArgs e)
        {

        }
    }
}
