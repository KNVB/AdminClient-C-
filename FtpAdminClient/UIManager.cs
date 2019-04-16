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
        public AdminServer getAdminServer(string fullPath)
        {
            AdminServer adminServer = null;
            int index = fullPath.IndexOf("\\");

            string serverKey = fullPath.Substring(index + 1);
            index = serverKey.IndexOf("\\");
            if (index > -1)
            {
                serverKey = serverKey.Substring(0, index);
                adminServer = this.adminServerManager.adminServerList[serverKey];
            }
            return adminServer;
        }
        public RootNode getRootNode()
        {
            return rootNode;
        }        
        public void popupAdminUserAdministrationForm(string fullPath)
        {
            string serverKey = fullPath;
            int index = serverKey.IndexOf("\\");
            serverKey = serverKey.Substring(index + 1);
            index = serverKey.IndexOf("\\");
            serverKey = serverKey.Substring(0,index);
            //MessageBox.Show(serverKey);

            AdminUserForm adminUserForm = new AdminUserForm(serverKey);
            adminUserForm.ShowDialog();

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
        public void popupAddFTPServerDiaglog(SplitContainer splitContainer, TreeView treeView, ListView listView, ImageList imageList,string fullPath)
        {
            AdminServer adminServer = getAdminServer(fullPath);
            AddFtpForm addFtpForm = new AddFtpForm(adminServer);
            DialogResult dialogresult = addFtpForm.ShowDialog();

        }
        private void rebuildAdminServerTree(TreeView treeView1, ListView listView, ImageList imageList1)
        {
            AdminServerNode adminServerNode;
            rootNode.Nodes.Clear();
            foreach (string key in adminServerManager.adminServerList.Keys)
            {
                adminServerNode = uiConfig.getAdminServerNode();
                adminServerNode.adminServer = adminServerManager.adminServerList[key];
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
