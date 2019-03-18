using ObjectLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace FtpAdminClient
{
    internal static class Utility
    {
        private static TreeNode buildAdministrationNode(AdminServer adminServer)
        {
            TreeNode administrationNode = new TreeNode();
            administrationNode.Text = "Administration";
            administrationNode.ImageIndex = 7;
            administrationNode.SelectedImageIndex = 7;
            administrationNode.Name = adminServer.serverName + ":" + adminServer.portNo;

            TreeNode adminUserListNode = new TreeNode();
            adminUserListNode.Text = "Admin. Users";
            adminUserListNode.ImageIndex = 6;
            adminUserListNode.SelectedImageIndex = 6;
            administrationNode.Name = adminServer.serverName + ":" + adminServer.portNo;
            administrationNode.Nodes.Add(adminUserListNode);

            return administrationNode;
        }
        private static TreeNode buildFtpServerListNode(AdminServer adminServer)
        {
            TreeNode ftpServerListNode = new TreeNode();
            ftpServerListNode.Text = "FTP Server List";
            ftpServerListNode.Name = adminServer.serverName + ":" + adminServer.portNo ;
            ftpServerListNode.ImageIndex = 3;
            ftpServerListNode.SelectedImageIndex = 3;
            return ftpServerListNode;
        }
        private static TreeNode buildRemoteServerNode(AdminServer adminServer, MainForm mainForm)
        {
            TreeNode remoteServerNode = new TreeNode();
            string key = adminServer.serverName + ":" + adminServer.portNo;

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

            remoteServerNode.Nodes.Add(buildAdministrationNode(adminServer));
            remoteServerNode.Nodes.Add(buildFtpServerListNode(adminServer));

            remoteServerNode.ContextMenuStrip = adminTopMenu;
            return remoteServerNode;
        }
        internal static void rebuildRemoteServerList(MainForm mainForm, FtpAdminClient ftpAdminClient)
        {
            TreeNode remoteServerNode;
            mainForm.clearRootNode();
            string[] keys = ftpAdminClient.adminServerList.Keys.ToArray();
            for (int i = 0; i < keys.Length; i++)
            {
                remoteServerNode = buildRemoteServerNode(ftpAdminClient.adminServerList[keys[i]], mainForm);
                mainForm.AddToRootNode(remoteServerNode);
                if (keys[i].Equals(ftpAdminClient.lastServerKey))
                {
                    mainForm.Panel1Tree.SelectedNode = remoteServerNode;
                    remoteServerNode.Expand();
                }
            }            
        }
    }
}
