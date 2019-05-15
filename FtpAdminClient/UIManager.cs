﻿using AdminServerObject;
using System.Windows.Forms;
using System;
using System.Collections.Generic;

namespace FtpAdminClient
{
    internal class UIManager
    {
        private AdminServerManager adminServerManager;
        private MainForm mainForm;
        private ListView listView;
        private ImageList imageList;
        private RootNode rootNode;
        private SplitContainer splitContainer;
        private TreeView treeView;
        private UIObjFactory uiObjFactory = null;



        internal UIManager(MainForm mainForm)
        {
            adminServerManager = new AdminServerManager();
            uiObjFactory = new UIObjFactory();
            this.mainForm = mainForm;
            this.treeView = mainForm.Panel1Tree;
            this.listView = mainForm.settingList;
            this.imageList = mainForm.imageList1;
            this.splitContainer = mainForm.splitContainer;
            mainForm.serverToolStripMenuItem.Text = getAdminServerLabel();
            mainForm.addToolStripMenuItem.Text = getAddLabel();
            mainForm.exitToolStripMenuItem.Text = getExitLabel();
        }


        internal void close()
        {
            adminServerManager.disconnectAllAdminServer();
        }
        private string getMessageText(string key)
        {
            return uiObjFactory.getMessageText(key);
        }
        private string getLabelText(string key)
        {
            return (uiObjFactory.getLabel(key));
        }
        internal void initMainForm()
        {
            rootNode = new RootNode(null, this);
            rootNode.init(uiObjFactory.getObj("RootNode"));
            rootNode.addAdminServerItem = new AddAdminServerItem(uiObjFactory.getObj("RootNode")["addAdminServerItem"]);
            rootNode.setAdminServerManager(adminServerManager);
            this.mainForm.Text = uiObjFactory.getLabel("AppName");
            rootNode.Text = this.mainForm.Text;
            treeView.BeginUpdate();
            treeView.Nodes.Add(rootNode);
            treeView.EndUpdate();
        }
        internal void popupAddFtpServerDiaglog(FtpServerListNode ftpServerListNode)
        {
            AddFtpForm addFtpForm = new AddFtpForm(ftpServerListNode.adminServer, this);
            DialogResult dialogresult = addFtpForm.ShowDialog();
            if (dialogresult.Equals(DialogResult.OK))
            {
                refreshFtpServerListNode(ftpServerListNode.adminServer, ftpServerListNode);
            }
        }
        public void popupAlertBox(string message)
        {
            MessageBox.Show(message, getAlertLabel(), MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
        internal void popupConnectToAdminServerDiaglog()
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
            MessageBox.Show(message, getMessageLabel(), MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
        }
        internal void refreshFtpServerListNode(AdminServer adminServer, FtpServerListNode ftpServerListNode)
        {
            SortedDictionary<string, FtpServerInfo> ftpServerList = adminServer.getFTPServerList();
            ftpServerListNode.Nodes.Clear();
            foreach (string serverId in ftpServerList.Keys)
            {
                FtpServerNode ftpServerNode = new FtpServerNode(adminServer, this, serverId);
                FtpServerInfo fI = ftpServerList[serverId];
                ftpServerNode.init(uiObjFactory.getObj("ftpServerNode"));
                foreach (string key in ftpServerNode.toolStripItemList.Keys)
                {
                    ToolStripMenuItem tSI = ftpServerNode.toolStripItemList[key].ToObject<ToolStripMenuItem>();
                    tSI.Click += (sender, e) => MessageBox.Show(fI.serverId);
                    ftpServerNode.ContextMenuStrip.Items.Add(tSI);
                }
                ftpServerNode.ContextMenuStrip.ImageList = imageList;
                ftpServerNode.Text = fI.description;
                ftpServerNode.Name = serverId;
                ftpServerListNode.Nodes.Add(ftpServerNode);
            }
            selectNode(ftpServerListNode);
        }
        
        internal void refreshRootNode()
        {
            splitContainer.SelectNextControl((Control)splitContainer, true, true, true, true);
            treeView.BeginUpdate();

            rootNode.Nodes.Clear();
            foreach (string key in adminServerManager.adminServerList.Keys)
            {
                AdminServer adminServer = adminServerManager.adminServerList[key];
                AdminServerNode adminServerNode = new AdminServerNode(adminServer, this);
                adminServerNode.init(uiObjFactory.getObj("adminServerNode"), key);
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
        internal void selectNode(Node relatedNode)
        {
            treeView.SelectedNode = relatedNode;
        }
        internal void updateListView(List<string> colunmNameList, List<ListItem> itemList)
        {
            splitContainer.SelectNextControl((Control)splitContainer, true, true, true, true);
            if ((colunmNameList != null) && (colunmNameList.Count > 0))
            {
                this.listView.Columns.Clear();
                foreach (string headerString in colunmNameList)
                {
                    ColumnHeader header;
                    header = new ColumnHeader();
                    header.Text = headerString;
                    listView.Columns.Add(header);
                }
            }
            if ((itemList != null) && (itemList.Count > 0))
            {
                this.listView.Items.Clear();
                foreach (ListItem item in itemList)
                    listView.Items.Add(item);
            }
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
        public string getAlertLabel()
        {
            return getLabelText("AlertLable");
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
        public string getMessageLabel()
        {
            return getLabelText("MessageLabel");
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
        public string getServerLabel()
        {
            return getLabelText("ServerLabel");
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
