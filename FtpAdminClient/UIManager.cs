using System;
using System.Collections.Generic;
using UIObject;
using AdminServerObject;
using System.Windows.Forms;
namespace FtpAdminClient
{
    public class UIManager
    {
        private RootNode rootNode;
        private AdminServerManager adminServerManager;
        private ImageList imageList1;
        private ListView listView1;
        private SplitContainer splitContainer;
        private TreeView treeView1;
        private UIConfig uiConfig = new UIConfig();
        public UIManager()
        {
            rootNode = uiConfig.RootNode;
        }
        public RootNode getRootNode()
        {
            return rootNode;
        }
        private void popupAlertBox(string message)
        {
            MessageBox.Show(message, "Alert", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
        public void popupConnectToServerDiaglog()
        {
            ConnectToServerForm ctsf = new ConnectToServerForm(this);
            DialogResult dialogresult = ctsf.ShowDialog();
            if (dialogresult.Equals(DialogResult.OK))
            {
                splitContainer.SelectNextControl((Control)splitContainer, true, true, true, true);
               // rebuildAdminServerList();
            }
        }
    }
}
