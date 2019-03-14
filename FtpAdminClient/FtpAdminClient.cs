using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using ObjectLibrary;

namespace FtpAdminClient
{
    public class FtpAdminClient
    {
        public SortedDictionary<string, AdminServer> adminServerList = new SortedDictionary<string, AdminServer>();
        public FtpAdminClient()
        {

        }
        public void disconnectServer(string key)
        {
            AdminServer adminServer;
            adminServer = adminServerList[key];
            adminServer.disConnect();
            adminServerList.Remove(key);
        }
        public void disconnectAllAdminServer()
        {
            string[] keys = adminServerList.Keys.ToArray();
            for (int i= 0;i<keys.Length;i++)
            {
                disconnectServer(keys[i]);
            }
        }

        internal TreeNode addRemoteServer(AdminServer adminServer,MainForm mainForm)
        {
            TreeNode remoteServerNode = new TreeNode();
            string key = adminServer.serverName + ":" + adminServer.portNo;
            adminServerList.Add(key, adminServer);
          
            remoteServerNode.Text = key;
            remoteServerNode.Name = key;
            remoteServerNode.ImageIndex = 2;
            remoteServerNode.SelectedImageIndex = 2;
            ContextMenuStrip adminTopMenu = new ContextMenuStrip();
            ToolStripMenuItem disconnect = new ToolStripMenuItem();
            disconnect.Text = "Disconnect from the Remote admin. server";
            disconnect.Click += new EventHandler((sender, e) => mainForm.disconnectServer(key));
            disconnect.Image = mainForm.imageList1.Images[5];
            adminTopMenu.Items.Add(disconnect);

            TreeNode administrationNode = new TreeNode();
            administrationNode.Text = "Administration";
            administrationNode.ImageIndex = 7;
            administrationNode.SelectedImageIndex = 7;

            TreeNode adminUserListNode = new TreeNode();
            adminUserListNode.Text = "Admin. Users";
            adminUserListNode.ImageIndex = 6;
            adminUserListNode.SelectedImageIndex = 6;
            administrationNode.Nodes.Add(adminUserListNode);

            remoteServerNode.Nodes.Add(administrationNode);

            TreeNode ftpServerListNode = new TreeNode();
            ftpServerListNode.Text = "FTP Server List";
            ftpServerListNode.ImageIndex = 3;
            ftpServerListNode.SelectedImageIndex = 3;

            remoteServerNode.Nodes.Add(ftpServerListNode);
            remoteServerNode.ContextMenuStrip = adminTopMenu;
            return remoteServerNode;
        }
    }
}
