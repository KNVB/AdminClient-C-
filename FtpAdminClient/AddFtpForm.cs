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
        public AddFtpForm(AdminServer adminServer, UIManager uiManager):base(adminServer, uiManager)
        {
            InitializeComponent();
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
                if (supportPassiveMode.Text.Equals("No"))
                    ftpServerInfo.passiveModeEnabled = false;
                else
                {
                    ftpServerInfo.passiveModeEnabled = true;
                    ftpServerInfo.passiveModePortRange = passiveModePortRange.Text;
                }
                try
                {
                    ServerResponse response = adminServer.addFtpServer(ftpServerInfo);
                    switch (response.responseCode)
                    {
                        case 0:
                            uiManager.popupMessageBox("Server is added successfully.");
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
