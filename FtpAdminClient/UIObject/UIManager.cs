using AdminServerObject;
using System.Collections.Generic;
using System.Windows.Forms;

namespace FtpAdminClient
{
    public class UIManager
    {
        private AdminServerManager adminServerManager;
        private ListView listView;
        private ImageList imageList;
        private RootNode rootNode;
        private SplitContainer splitContainer;
        private TreeView treeView;
        private UIObjFactory uiObjFactory = null;
        public UIManager(TreeView treeView, ListView listView, SplitContainer splitContainer, ImageList imageList, AdminServerManager adminServerManager)
        {
            this.adminServerManager = adminServerManager;
            this.treeView = treeView;
            this.listView = listView;
            this.imageList = imageList;
            this.splitContainer = splitContainer;
            uiObjFactory = new UIObjFactory(this);
            rootNode = uiObjFactory.getRootNode();
        }
        /*
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
        */
        private void disconnectServer(string key)
        {
            DialogResult dialogResult = MessageBox.Show(getConfirmDisconnectFromAdminServerMsg(), getConfirmLabel(), MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                adminServerManager.disconnectServer(key);
                rootNode.Nodes.Remove(rootNode.Nodes.Find(key, true)[0]);
            }
        }
        public string getMessageText(string key)
        {
            return uiObjFactory.getMessageText(key);
        }
        public string getLabelText(string key)
        {
            return (uiObjFactory.getLabel(key));
        }
        internal RootNode getRootNode()
        {
            return rootNode;
        }
        internal void popupAdminUserAdministrationForm(AdminServer adminServer)
        {
            AdminUserForm adminUserForm = new AdminUserForm(adminServer, this);
            adminUserForm.ShowDialog();

        }

        public void popupAlertBox(string message)
        {
            MessageBox.Show(message, "Alert", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        public void popupConnectToAdminServerDiaglog()
        {
            ConnectToAdminServerForm ctsf = new ConnectToAdminServerForm(this, adminServerManager);
            DialogResult dialogresult = ctsf.ShowDialog();
            if (dialogresult.Equals(DialogResult.OK))
            {
                refreshRootNode();
            }
        }
        public void popupMessageBox(string message)
        {
            MessageBox.Show(message, "Message", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
        }
        internal void refreshFtpServerListNode(FtpServerListNode ftpServerListNode)
        {
            ftpServerListNode.Nodes.Clear();
            foreach (FtpServerInfo fI in ftpServerListNode.ftpServerList.Values)
            {
                FtpServerNode ftpServerNode = new FtpServerNode(ftpServerListNode.token["ftpServerNode"], ftpServerListNode.adminServer, this, fI.description, fI.serverId);
                foreach (string key in ftpServerNode.toolStripItemList.Keys)
                {
                    ToolStripMenuItem tSI = ftpServerNode.toolStripItemList[key].ToObject<ToolStripMenuItem>();
                    tSI.Click += (sender, e) => MessageBox.Show(fI.serverId);
                    ftpServerNode.ContextMenuStrip.Items.Add(tSI);
                }
                ftpServerNode.ContextMenuStrip.ImageList = imageList;
                ftpServerListNode.Nodes.Add(ftpServerNode);
            }
        }
        internal void refreshRootNode()
        {
            splitContainer.SelectNextControl((Control)splitContainer, true, true, true, true);
            treeView.BeginUpdate();
            rootNode.Nodes.Clear();
            foreach (string key in adminServerManager.adminServerList.Keys)
            {
                AdminServer adminServer = adminServerManager.adminServerList[key];
                AdminServerNode adminServerNode = uiObjFactory.getAdminServerNode(adminServer, this);
                adminServerNode.Text = key;
                adminServerNode.Name = key;
                foreach (string id in adminServerNode.toolStripItemList.Keys)
                {
                    ToolStripMenuItem tSI = adminServerNode.toolStripItemList[id].ToObject<ToolStripMenuItem>();
                    tSI.Click += (sender, e) => MessageBox.Show(adminServer.serverName + ":" + adminServer.portNo);
                    adminServerNode.ContextMenuStrip.Items.Add(tSI);
                }

                adminServerNode.ContextMenuStrip.ImageList = imageList;
                rootNode.Nodes.Add(adminServerNode);
                if (key == adminServerManager.lastServerKey)
                {
                    treeView.SelectedNode = adminServerNode;
                    adminServerNode.doSelect();
                    adminServerNode.Expand();
                }
            }
            treeView.EndUpdate();
        }
        internal void selectNode(Node n)
        {
            treeView.SelectedNode = n;
        }
        internal void updateListView(List<string> colunmNameList, List<ListItem> ItemList)
        {
            splitContainer.SelectNextControl((Control)splitContainer, true, true, true, true);
            this.listView.Items.Clear();
            this.listView.Columns.Clear();
            foreach (string headerString in colunmNameList)
            {
                ColumnHeader header;
                header = new ColumnHeader();
                header.Text = headerString;
                listView.Columns.Add(header);
            }
            foreach (ListItem item in ItemList)
                listView.Items.Add(item);
            listView.AutoResizeColumns(ColumnHeaderAutoResizeStyle.HeaderSize);
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
        public string getFtpServerNetworkPropertiesSaveSuccessMsg()
        {
            return getMessageText("FtpServerNetworkPropertiesSaveSuccess");
        }
        public string getGetFtPServerNetworkPropertiesFailureMsg()
        {
            return getMessageText("GetFtPServerNetworkPropertiesFailure");
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
        public string getSomeNetworkSettingNotAvailableMsg()
        {
            return getMessageText("SomeNetworkSettingNotAvailable");
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
        public string getRemoveFtpServerLabel()
        {
            return getLabelText("RemoveThisFtpServerLabel");
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
