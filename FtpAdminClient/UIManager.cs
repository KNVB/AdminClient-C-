using System;
using System.Collections.Generic;
using UIObject;
using AdminServerObject;
using System.Windows.Forms;
namespace FtpAdminClient
{
    public class UIManager
    {
        private AdminNode rootNode;
        private AdminServerManager adminServerManager;
        private ImageList imageList1;
        private ListView listView1;
        private SplitContainer splitContainer;
        private TreeView treeView1;
        private UIConfig uiConfig = new UIConfig();
        public UIManager(SplitContainer splitContainer,ImageList imageList1,string rootNodeName)
        {
            adminServerManager = new AdminServerManager();
            rootNode = uiConfig.RootNode;
            rootNode.selectedHandlerType = SelectedHandlerType.InitAdminServerList;
            rootNode.Text = rootNodeName;
            //MessageBox.Show(uiConfig.AdminServerTemplate.adminServerAdministrationNode.adminUserAdministrationNode.Text);
            
            this.splitContainer = splitContainer;
            treeView1 =(TreeView)splitContainer.Panel1.Controls[0];
            listView1 =(ListView)splitContainer.Panel2.Controls[0];
            treeView1.Nodes.Add(rootNode);
            treeView1.SelectedNode = null;
            this.imageList1 = imageList1;
            
        }
        public int addAdminServer(string adminServerName,string portNo, string adminUserName,string adminUserPassword)
        {
            int result = 0;
            int adminPortNo=-1 ;
            if (String.IsNullOrEmpty(adminServerName))
            {
                popupAlertBox("Please enter the admin. server name or IP address.");
                result = -1;
            }
            else
            {
                if (Utility.isValidTCPPortNo(portNo)==-1)
                {
                    popupAlertBox("Please enter the admin. server port no. (0-65535).");
                    result = -2;
                }
                else
                {
                    adminPortNo = Convert.ToInt32(portNo);
                    if (String.IsNullOrEmpty(adminUserName))
                    {
                        popupAlertBox("Please enter the admin. user name.");
                        result = -3;
                    }
                    else
                    {
                        if (String.IsNullOrEmpty(adminUserPassword))
                        {
                            popupAlertBox("Please enter the admin. user password.");
                            result = -4;
                        }
                    }
                }
            }
            if (result==0)
            {
                Cursor.Current = Cursors.WaitCursor;
                try
                {
                    result = adminServerManager.addRemoteServer(adminServerName, adminPortNo, adminUserName, adminUserPassword);
                    switch (result)
                    {
                        case 1:
                            popupAlertBox("The specified server have been added");
                            break;
                        case 2:
                            popupAlertBox("Invalid admin. server name or port no.");
                            break;
                        case 3:
                            popupAlertBox("Invalid admin. user or password");
                            break;
                    }
                }
                catch (Exception err)
                {
                    popupAlertBox(err.Message);
                }
                Cursor.Current = Cursors.Default;
            }
            return result;
        }
        public void disconnectAllAdminServer()
        {
            adminServerManager.disconnectAllAdminServer();
        }
        private void disconnectServer(AdminNode adminServerNode)
        {
            adminServerManager.disconnectServer(adminServerNode.Text);
            rootNode.Nodes.Remove(adminServerNode);
        }
        public void doSelectListItemEvent()
        {
            ListItem listViewItem = (ListItem)listView1.SelectedItems[0];
            switch (listViewItem.selectedHandlerType)
            {
                case SelectedHandlerType.PopupConnectToServerDiaglog:
                    popupConnectToServerDiaglog();
                    break;
            }
        }
        public void doSelectNodeEvent(AdminNode node)
        {
            switch (node.selectedHandlerType)
            {
                case SelectedHandlerType.InitAdminServerList:
                    ((RootNode)node).handleSelectEvent(listView1, adminServerManager.adminServerList);
                    break;
                case SelectedHandlerType.InitAdminServerNode:
                    ((AdminServerNode)node).handleSelectEvent(listView1);
                    break;
            }
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
                rebuildAdminServerList();
            }           
        }
        private void rebuildAdminServerList()
        {
            AdminServerNode adminServerNode;
            rootNode.Nodes.Clear();
            //MessageBox.Show(uiConfig.AdminServerTemplate.adminServerAdministrationNode.Text);
            foreach (string key in adminServerManager.adminServerList.Keys)
            {
                //adminServerNode = (AdminServerNode)ObjectUtility.CloneObject(uiConfig.AdminServerTemplate);
                adminServerNode = new AdminServerNode();
                adminServerNode.adminServerAdministrationNode = uiConfig.AdminServerTemplate.adminServerAdministrationNode;
                adminServerNode.ftpServerListNode = uiConfig.AdminServerTemplate.ftpServerListNode;
                adminServerNode.Name = key;
                adminServerNode.Text = adminServerNode.Name;
                adminServerNode.ImageIndex = uiConfig.AdminServerTemplate.ImageIndex;
                adminServerNode.SelectedImageIndex = uiConfig.AdminServerTemplate.SelectedImageIndex;
                adminServerNode.buildNode();
                ToolStripMenuItem disconnect = new ToolStripMenuItem();
                disconnect.Text = "Disconnect from the admin. server";
                disconnect.Click += new EventHandler((sender, e) => disconnectServer(adminServerNode));
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
    }
}
