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
        private UIObjFactory uiObjFactory = new UIObjFactory();
        public UIManager(AdminServerManager adminServerManager)
        {
            rootNode = uiObjFactory.getRootNode();
            this.adminServerManager = adminServerManager;
        }
        private void disconnectServer(string key)
        {
            adminServerManager.disconnectServer(key);
            rootNode.Nodes.Remove(rootNode.Nodes.Find(key, true)[0]);
        }
        public string getAddLabel()
        {
            return getLabelText("AddLabel");
        }
        public string getAddFtpServerFormLabel()
        {
            return getLabelText("AddFtpServerFormLabel");
        }
        public string getAdminServerLabel()
        {
            return getLabelText("AdminServerLabel");
        }
        public string getCancelButtonLabel()
        {
            return getLabelText("CancelButtonLabel");
        }
        public string getConnectLabel()
        {
            return getLabelText("ConnectLabel");
        }
        public string getConnectToAdminServerFormLabel()
        {
            return getLabelText("ConnectToAdminServerFormLabel");
        }
        public string getDeconnectFromAdminServerLabel()
        { 
             return getLabelText("DeconnectFromAdminServerLabel");
        }
        public string getEditFtpServerNetworkPropertiesFormLabel()
        {
            return getLabelText("EditFtpServerNetworkPropertiesFormLabel");
        }
        public string getExitLabel()
        {
            return getLabelText("ExitLabel");
        }
        public string getFtpServerDescLabel()
        {
            return getLabelText("FtpServerDescLabel");
        }
        public string getFtpServerBindingAddressLabel()
        {
            return getLabelText("FtpServerBindingAddressLabel");
        }
        private string getLabelText(string key)
        {
            return (uiObjFactory.getLabel(key));
        }
        public string getNoAnswerLabel()
        {
            return getLabelText("NoAnswerLabel");
        }
        public string getPasswordLabel()
        {
            return getLabelText("PasswordLabel");
        }
        public string getPassiveModePortRangeLabel()
        {
            return getLabelText("PassiveModePortRangeLabel");
        }
        public string getPortNoLabel()
        {
            return getLabelText("PortNoLabel");
        }
        public RootNode getRootNode()
        {
            return rootNode;
        }
        public string getSaveChangeButtonLabel()
        {
            return getLabelText("SaveChangeButtonLabel");
        }
        public string getServerNameLabel()
        {
            return getLabelText("ServerNameLabel");
        }
        public string getSoftwareName()
        {
            return getLabelText("SoftwareName");
        }
        public string getSupportPassiveModeLabel()
        {
            return getLabelText("SupportPassiveModeLabel");
        }
        public string getUserNameLabel()
        {
            return getLabelText("UserNameLabel");
        }
        public string getYesAnswerLabel()
        {
            return getLabelText("YesAnswerLabel");
        }
        public void popupAdminUserAdministrationForm(string fullPath)
        {
            string serverKey = fullPath;
            int index = serverKey.IndexOf("\\");
            serverKey = serverKey.Substring(index + 1);
            index = serverKey.IndexOf("\\");
            serverKey = serverKey.Substring(0, index);
            //MessageBox.Show(serverKey);

            AdminUserForm adminUserForm = new AdminUserForm(serverKey);
            adminUserForm.ShowDialog();

        }
        internal void popupAddFTPServerDiaglog(SplitContainer splitContainer, TreeView treeView, ImageList imageList,AdminServer adminServer)
        {
            AddFtpForm addFtpForm = new AddFtpForm(adminServer, this);
            DialogResult dialogresult =addFtpForm.ShowDialog();
            if (dialogresult.Equals(DialogResult.OK))
            {
                splitContainer.SelectNextControl((Control)splitContainer, true, true, true, true);
                rebuildAdminServerTree(treeView, imageList);
            }
        }

        public void popupAlertBox(string message)
        {
            MessageBox.Show(message, "Alert", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
        
        public void popupConnectToAdminServerDiaglog(SplitContainer splitContainer, TreeView treeView, ImageList imageList)
        {
            ConnectToAdminServerForm ctsf = new ConnectToAdminServerForm(this, adminServerManager);
            DialogResult dialogresult = ctsf.ShowDialog();
            if (dialogresult.Equals(DialogResult.OK))
            {
                splitContainer.SelectNextControl((Control)splitContainer, true, true, true, true);
                rebuildAdminServerTree(treeView, imageList);
            }
        }

        internal void popupEditFtpServerNetworkPropertiesForm(FtpServerNetworkPropertiesNode ftpServerNetworkPropertiesNode)
        {
            EditFtpServerNetworkPropertiesForm efsf = new EditFtpServerNetworkPropertiesForm( ftpServerNetworkPropertiesNode.adminServer, this, ftpServerNetworkPropertiesNode.serverId);
            DialogResult dialogresult = efsf.ShowDialog();
        }
        public void popupMessageBox(string message)
        {
            MessageBox.Show(message, "Message", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
        }
        private void rebuildAdminServerTree(TreeView treeView1, ImageList imageList1)
        {
            AdminServerNode adminServerNode;
            rootNode.Nodes.Clear();
            foreach (string key in adminServerManager.adminServerList.Keys)
            {
                adminServerNode = uiObjFactory.getAdminServerNode(adminServerManager.adminServerList[key]);
                ToolStripMenuItem disconnect = new ToolStripMenuItem();
                disconnect.Text = getDeconnectFromAdminServerLabel();
                disconnect.Click += new EventHandler((sender, e) => disconnectServer(key));
                disconnect.Image = imageList1.Images[5];
                adminServerNode.ContextMenuStrip.Items.Add(disconnect);

                rootNode.Nodes.Add(adminServerNode);
                if (key == adminServerManager.lastServerKey)
                {
                    treeView1.SelectedNode = adminServerNode;
                    adminServerNode.Expand();
                }
            }
        }
        private void rebuildFtpServerTree(TreeView treeView1, ImageList imageList1, string fullPath)
        {

        }
    }
}
