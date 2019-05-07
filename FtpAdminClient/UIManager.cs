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
        public void deleteFtpServer(DeleteFTPServerNode deleteFTPServerNode, TreeView treeView1)
        {
            DialogResult dialogResult = MessageBox.Show(getConfirmDelFTPServerMsg(), getConfirmLabel(), MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                AdminServer adminServer = deleteFTPServerNode.adminServer;
                //adminServer.removeFtpServer(deleteFTPServerNode.ftpServerId);
                treeView1.Nodes.Remove(deleteFTPServerNode.Parent);
            }
        }
        private void disconnectServer(string key)
        {
            DialogResult dialogResult = MessageBox.Show(getConfirmDisconnectFromAdminServerMsg(), getConfirmLabel(), MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                adminServerManager.disconnectServer(key);
                rootNode.Nodes.Remove(rootNode.Nodes.Find(key, true)[0]);
            }
        }        
        private string getMessageText(string key)
        {
            return uiObjFactory.getMessageText(key);
        }
        private string getLabelText(string key)
        {
            return (uiObjFactory.getLabel(key));
        }
        public RootNode getRootNode()
        {
            return rootNode;
        }
        public void popupAdminUserAdministrationForm(AdminServer adminServer)
        {
            AdminUserForm adminUserForm = new AdminUserForm(adminServer,this);
            adminUserForm.ShowDialog();

        }
        internal void popupAddFTPServerDiaglog(SplitContainer splitContainer, TreeView treeView, ListItem listItem)
        {
            FtpServerListNode ftpServerListNode = (FtpServerListNode)listItem.relatedNode;
            AddFtpForm addFtpForm = new AddFtpForm(ftpServerListNode.adminServer, this);
            DialogResult dialogresult =addFtpForm.ShowDialog();
            if (dialogresult.Equals(DialogResult.OK))
            {
                splitContainer.SelectNextControl((Control)splitContainer, true, true, true, true);
                ftpServerListNode.rebuildFtpServerTree(treeView);
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
            EditFtpServerNetworkPropertiesForm efsf = new EditFtpServerNetworkPropertiesForm(ftpServerNetworkPropertiesNode.adminServer, this, ftpServerNetworkPropertiesNode.serverId);
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
//-----------------------Get Message Text Start-----------------------------
        public string getAddFTPServerSuccessMsg()
        {
            return getMessageText("AddFTPServerSuccess");
        }
        public string getAddressOrPortNotAvailableMsg()
        {
            return getMessageText("AddressOrPortNotAvailable");
        }       
        public string getAdminServerAddedAlreadyMsg()
        {
            return getMessageText("AdminServerAddedAlready");
        }
        public string getConfirmDelFTPServerMsg()
        {
            return getMessageText("ConfirmDelFTPServer");
        }
        public string getConfirmDisconnectFromAdminServerMsg()
        {
            return getMessageText("ConfirmDisconnectFromAdminServer");
        }
        public string getInvalidAdminServerNameOrPortNoMsg()
        {
            return getMessageText("InvalidAdminServerNameOrPortNo");
        }
        public string getInvalidAdminUserNameOrPasswordMsg()
        {
            return getMessageText("InvalidAdminUserOrPassword");
        }
        public string getInvalidControlPortNoMsg()
        {
            return getMessageText("InvalidControlPortNo");
        }
        public string getInvalidPassivePortRangeMsg()
        {
            return getMessageText("InvalidPassivePortRange");
        }
         
        public string getMissingAdminPortNoMsg()
        {
            return getMessageText("MissingAdminPortNo");
        }
        public string getMissingAdminServerNameOrIPMsg()
        {
            return getMessageText("MissingAdminServerNameOrIP");
        }
        public string getMissingAdminUserNameMsg()
        {
            return getMessageText("MissingAdminUserName");
        }
        public string getMissingAdminUserPasswordMsg()
        {
            return getMessageText("MissingAdminUserPassword");
        }
        public string getMissingBindingAddressMsg()
        {
            return getMessageText("MissingBindingAddress");
        }
        public string getMissingFTPServerDescMsg()
        {
            return getMessageText("MissingFTPServerDesc");
        }
//-----------------------Get Message Text End-------------------------------
//-----------------------Get Label Start-------------------------------------
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
        public string getAdminUserFormLabel()
        {
            return getLabelText("AdminUserFormLabel");
        }        
        public string getAllIPAddressLabel()
        {
            return getLabelText("AllIPAddressLabel");
        }
        public string getCancelButtonLabel()
        {
            return getLabelText("CancelButtonLabel");
        }       
        public string getConfirmLabel()
        {
            return getLabelText("ConfirmLabel");
        }   
        public string getConnectLabel()
        {
            return getLabelText("ConnectLabel");
        }
        public string getConnectToAdminServerFormLabel()
        {
            return getLabelText("ConnectToAdminServerFormLabel");
        }
        public string getControlPortDefault21Label()
        {
            return getLabelText("ControlPortDefault21Label") + ":";
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
            return getLabelText("FtpServerDescLabel") + ":";
        }
        public string getFtpServerBindingAddressLabel()
        {
            return getLabelText("FtpServerBindingAddressLabel") + ":";
        }
        public string getNoAnswerLabel()
        {
            return getLabelText("NoAnswerLabel");
        }
        public string getPasswordLabel()
        {
            return getLabelText("PasswordLabel") + ":";
        }
        public string getPassiveModePortRangeLabel()
        {
            return getLabelText("PassiveModePortRangeLabel") + ":";
        }
        public string getPortNoLabel()
        {
            return getLabelText("PortNoLabel") + ":";
        }
        public string getSaveChangeButtonLabel()
        {
            return getLabelText("SaveChangeButtonLabel");
        }
        public string getServerNameLabel()
        {
            return getLabelText("ServerNameLabel") + ":";
        }
        public string getSoftwareName()
        {
            return getLabelText("SoftwareName");
        }
        public string getSupportPassiveModeLabel()
        {
            return getLabelText("SupportPassiveModeLabel") + ":";
        }
        public string getUserNameLabel()
        {
            return getLabelText("UserNameLabel") + ":";
        }
        public string getYesAnswerLabel()
        {
            return getLabelText("YesAnswerLabel");
        }
//-----------------------Get Label End-------------------------------------

    }
}
