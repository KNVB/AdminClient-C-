using AdminServerObject;
using System.Windows.Forms;
using System;

namespace FtpAdminClient
{
    public partial class EditFtpServerNetworkPropertiesForm : NetworkPropertiesForm
    {
        string serverId="";
        public EditFtpServerNetworkPropertiesForm() : base()
        {
            InitializeComponent();
        }
      
        public EditFtpServerNetworkPropertiesForm(AdminServer adminServer, UIManager uiManager,string serverId) : base(adminServer, uiManager)
        {
            InitializeComponent();
            string value;
            this.serverId = serverId;
            ftpServerInfo = adminServer.getFTPServerInfo(this.serverId);
            if (ftpServerInfo == null)
                uiManager.popupAlertBox("Get FTP server Network Properties failure");
            else
            {
                serverDesc.Text = ftpServerInfo.description;
                controlPort.Text= Convert.ToString(ftpServerInfo.controlPort);

                foreach(var item in supportPassiveMode.Items)
                {
                    value = Convert.ToString(item);
                    if (ftpServerInfo.passiveModeEnabled)
                    {
                        if (value.Equals("Yes"))
                            supportPassiveMode.SelectedItem = item;
                    }
                    else
                    {
                        if (value.Equals("No"))
                            supportPassiveMode.SelectedItem = item;
                    }
                }
                for (int i = 0; i < ipAddressList.Items.Count; i++)
                {
                    value = Convert.ToString(ipAddressList.Items[i]);
                    if (ftpServerInfo.bindingAddresses.Contains(value))
                        ipAddressList.SetItemChecked(i, true);
                    else
                        ipAddressList.SetItemChecked(i, false);
                }
                /*
                passiveModePortRange
                */
            }
        }
        private void saveFtpServerNetworkProperties(object sender, EventArgs e)
        {
            if (isAllInputValid())
            {
                Cursor.Current = Cursors.WaitCursor;
                ftpServerInfo = new FtpServerInfo();
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
                    ServerResponse response = adminServer.saveFtpServerNetworkProperties(ftpServerInfo, this.serverId);
                    switch (response.responseCode)
                    {
                        case 0:
                            uiManager.popupMessageBox("FTP Server network properties are saved successfully.");
                            this.DialogResult = DialogResult.OK;
                            this.Close();
                            break;
                        case 1:
                            uiManager.popupAlertBox("Some of the specified address and port combination is/are not available.");
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
