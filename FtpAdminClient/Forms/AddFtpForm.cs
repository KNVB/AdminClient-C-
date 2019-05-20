using System;
using AdminServerObject;
using System.Windows.Forms;
namespace FtpAdminClient
{
    public partial class AddFtpForm : NetworkPropertiesForm
    {
        public AddFtpForm():base()
        {
            InitializeComponent();
        }
        internal AddFtpForm(AdminServer adminServer, UIManager uiManager):base(adminServer, uiManager)
        {
            InitializeComponent();
            ipAddressList.SetItemChecked(0, true);
        }
        private void addFTPServerButton_Click(object sender, EventArgs e)
        {
            if (isAllInputValid())
            {
                Cursor.Current = Cursors.WaitCursor;
                ftpServerInfo = new FtpServerInfo();
                ftpServerInfo.description = serverDesc.Text;
                ftpServerInfo.controlPort = controlPortNo;
                ftpServerInfo.bindingAddresses = bindingAddressList;
                if (supportPassiveMode.Text.Equals(uiManager.getNoAnswerLabel()))
                    ftpServerInfo.passiveModeEnabled = false;
                else
                {
                    ftpServerInfo.passiveModeEnabled = true;
                    ftpServerInfo.passiveModePortRange = uiManager.passivePortRangeToList(passiveModePortRange.Text);
                }
                try
                {
                    ServerResponse response = adminServer.addFtpServer(ftpServerInfo);
                    switch (response.responseCode)
                    {
                        case 0:
                            uiManager.popupMessageBox(uiManager.getAddFTPServerSuccessMsg());
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
