using System;
using System.Collections.Generic;
using System.Drawing;
using AdminServerObject;
using System.Windows.Forms;
using UIObject;

namespace FtpAdminClient
{
    public partial class NetworkPropertiesForm : Form
    {
        internal AdminServer adminServer;
        internal FtpServerInfo ftpServerInfo = null;
        internal int controlPortNo = -1;
        internal List<string> bindingAddressList = new List<string>();
        internal UIManager uiManager;
        public NetworkPropertiesForm()
        {
            InitializeComponent();
        }
        public NetworkPropertiesForm(AdminServer adminServer, UIManager uiManager)
        {
            this.adminServer = adminServer;
            this.uiManager = uiManager;
            InitializeComponent();
            
            label1.Text = uiManager.getFtpServerDescLabel();
            label2.Text = uiManager.getFtpServerBindingAddressLabel();
            label3.Text = uiManager.getControlPortDefault21Label();
            label4.Text = uiManager.getSupportPassiveModeLabel();
            passiveModePortRangeLabel.Text = uiManager.getPassiveModePortRangeLabel();

            List<string> ipList = adminServer.getIPAddressList();
            ItemObject listItem = new ItemObject();
            listItem.Text= "("+ uiManager.getAllIPAddressLabel() + ")";
            listItem.Value = "*";
            ipAddressList.Items.Add(listItem);
            foreach (var ip in ipList)
            {
                listItem = new ItemObject();
                listItem.Text = (string)ip;
                listItem.Value = listItem.Text;
                ipAddressList.Items.Add(listItem);
            }
            listItem = new ItemObject();
            listItem.Text = uiManager.getNoAnswerLabel();
            listItem.Value = false;
            supportPassiveMode.Items.Insert(0, listItem);
            listItem = new ItemObject();
            listItem.Text = uiManager.getYesAnswerLabel();
            listItem.Value = true;
            supportPassiveMode.Items.Insert(1, listItem);
            supportPassiveMode.SelectedIndex = 0; //default not support passive mode
            cancelButton.Text = uiManager.getCancelButtonLabel();
            
        }
        private void NetworkPropertiesForm_Load(object sender, EventArgs e)
        {
            
        }
        internal bool isAllInputValid()
        {
            bool result = true;
            List<string> bindingAddressList = new List<string>();
            if (String.IsNullOrEmpty(serverDesc.Text) || (serverDesc.ForeColor == SystemColors.GrayText))
            {
                uiManager.popupAlertBox(uiManager.getMissingFTPServerDescMsg());
                serverDesc.Focus();
                result = false;
            }
            else
            {
                if (!isBindingAddressSelected())
                {
                    uiManager.popupAlertBox(uiManager.getMissingBindingAddressMsg());
                    ipAddressList.Focus();
                    result = false;
                }
                else
                {
                    controlPortNo = getControlPortNo();
                    if (controlPortNo == -1)
                    {
                        uiManager.popupAlertBox(uiManager.getInvalidControlPortNoMsg());
                        controlPort.Focus();
                        result = false;
                    }
                    else
                    {
                        ItemObject listItem =(ItemObject)supportPassiveMode.SelectedItem;
                        if (Convert.ToBoolean(listItem.Value))
                        {
                            if (!Utility.isValidPassiveModePortRange(passiveModePortRange.Text))
                            {
                                result = false;
                                uiManager.popupAlertBox(uiManager.getInvalidPassivePortRangeMsg());
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
            ItemObject item;
            for (int i = 0; i < ipAddressList.Items.Count; i++)
            {
                if (ipAddressList.GetItemChecked(i))
                {
                    item =(ItemObject)ipAddressList.Items[i];
                    bindingAddressList.Add(Convert.ToString(item.Value));
                }
                    
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
                serverDesc.ForeColor = SystemColors.GrayText;
            }
        }

        private void supportPassiveMode_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (supportPassiveMode.Text.Equals(uiManager.getYesAnswerLabel()))
            {
                passiveModePortRange.Visible = true;
                passiveModePortRangeLabel.Visible = true;

            }
            else
            {
                passiveModePortRange.Visible = false;
                passiveModePortRangeLabel.Visible = false;
            }
        }
    }
}
