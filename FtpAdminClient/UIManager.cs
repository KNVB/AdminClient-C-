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
     
        private UIConfig uiConfig = new UIConfig();
        public UIManager(AdminServerManager adminServerManager)
        {
            rootNode = uiConfig.rootNode;
            this.adminServerManager = adminServerManager;
        }
        private void disconnectServer(string key)
        {
            adminServerManager.disconnectServer(key);
            rootNode.Nodes.Remove(rootNode.Nodes.Find(key, true)[0]);
        }
        public RootNode getRootNode()
        {
            return rootNode;
        }
        public void handleRootNodeSelectEvent(TreeView treeView1, ListView listView, ImageList imageList1, SortedDictionary<string, AdminServer> adminServerList)
        {
            ColumnHeader header;
            ListItem listItem;
            listView.Items.Clear();
            listView.Columns.Clear();
            foreach (string headerString in rootNode.colunmNameList)
            {
                // MessageBox.Show(headerString);
                header = new ColumnHeader();
                header.Text = headerString;
                listView.Columns.Add(header);
            }
            
            foreach (string key in adminServerList.Keys)
            {
                listItem = new ListItem();
                listItem.ListItemType = ListItemType.AdminServerListItem;
                listItem.fullPath = rootNode.FullPath + "\\" + key;
                listItem.Text = key;
                listItem.Name = listItem.Text;
                listItem.ImageIndex = 2;
                listView.Items.Add(listItem);
            }
            //rootNode.addAdminServerListItem.fullPath = rootNode.FullPath;
            listView.Items.Add(rootNode.addAdminServerListItem);
            listView.AutoResizeColumns(ColumnHeaderAutoResizeStyle.HeaderSize);
        }
        public void popupAlertBox(string message)
        {
            MessageBox.Show(message, "Alert", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
        public void popupConnectToServerDiaglog(SplitContainer splitContainer,TreeView treeView, ListView listView, ImageList imageList)
        {
            ConnectToServerForm ctsf = new ConnectToServerForm(this, adminServerManager);
            DialogResult dialogresult = ctsf.ShowDialog();
            if (dialogresult.Equals(DialogResult.OK))
            {
                splitContainer.SelectNextControl((Control)splitContainer, true, true, true, true);
                rebuildAdminServerTree(treeView, listView, imageList);
            }
        }
        private void rebuildAdminServerTree(TreeView treeView1, ListView listView, ImageList imageList1)
        {
            AdminServerNode adminServerNode;
            rootNode.Nodes.Clear();
            foreach (string key in adminServerManager.adminServerList.Keys)
            {
                adminServerNode = uiConfig.getAdminServerNode();
                adminServerNode.Name = key;
                adminServerNode.Text = adminServerNode.Name;
                adminServerNode.buildNode();
                ToolStripMenuItem disconnect = new ToolStripMenuItem();
                disconnect.Text = "Disconnect from the admin. server";
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
    }
}
