using AdminServerObject;
using System.Windows.Forms;
using System;
using System.Drawing;

namespace FtpAdminClient
{
    public partial class EditFtpServerNetworkPropertiesForm : NetworkPropertiesForm
    {
        string serverId="";
        public EditFtpServerNetworkPropertiesForm() : base()
        {
            InitializeComponent();
        }
      
        internal EditFtpServerNetworkPropertiesForm(AdminServer adminServer, UIManager uiManager,string serverId) : base(adminServer, uiManager)
        {
            InitializeComponent();
            bool value;
            ItemObject listItem;
            this.serverId = serverId;
            ftpServerInfo = adminServer.getFTPServerInfo(this.serverId);
            if (ftpServerInfo == null)
                uiManager.popupAlertBox("Get FTP server Network Properties failure");
            else
            {
                serverDesc.Text = ftpServerInfo.description;
                controlPort.Text= Convert.ToString(ftpServerInfo.controlPort);
                serverDesc.ForeColor = Color.Black;
                if (ftpServerInfo.passiveModeEnabled)
                {
                    passiveModePortRange.Text = ftpServerInfo.passiveModePortRange;
                    passiveModePortRangeLabel.Visible = true;
                    passiveModePortRange.Visible = true;
                }
                else
                {
                    passiveModePortRangeLabel.Visible = false;
                    passiveModePortRange.Visible = false;
                }
                foreach (var item in supportPassiveMode.Items)
                {
                    listItem = (ItemObject)item;
                    value = Convert.ToBoolean(listItem.Value);
                    if (ftpServerInfo.passiveModeEnabled == value)
                    {
                        supportPassiveMode.SelectedItem = item;
                    }
                }
                for (int i = 0; i < ipAddressList.Items.Count; i++)
                {
                    listItem = (ItemObject)ipAddressList.Items[i];
                    if (ftpServerInfo.bindingAddresses.Contains(Convert.ToString(listItem.Value)))
                        ipAddressList.SetItemChecked(i, true);
                    else
                        ipAddressList.SetItemChecked(i, false);
                }
            }
        }
        private void saveFtpServerNetworkProperties(object sender, EventArgs e)
        {
            if (isAllInputValid())
            {
                Cursor.Current = Cursors.WaitCursor;
                ftpServerInfo = new FtpServerInfo();
                ftpServerInfo.serverId = this.serverId;
                ftpServerInfo.description = serverDesc.Text;
                ftpServerInfo.controlPort = controlPortNo;
                ftpServerInfo.bindingAddresses = bindingAddressList;
                if (supportPassiveMode.Text.Equals("No"))
                    ftpServerInfo.passiveModeEnabled = false;
                else
                {
                    ftpServerInfo.passiveModeEnabled = true;
                    ftpServerInfo.passiveModePortRange = passiveModePortRange.Text;
                }
                try
                {
                    ServerResponse response = adminServer.saveFtpServerNetworkProperties(ftpServerInfo);
                    switch (response.responseCode)
                    {
                        case 0:
                            uiManager.popupMessageBox(uiManager.getTheFtpServerNetworkPropertiesSaveSuccess());
                            this.DialogResult = DialogResult.OK;
                            this.Close();
                            break;
                        case 1:
                            uiManager.popupAlertBox(uiManager.getAddressOrPortNotAvailableMsg());
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
    }
}
