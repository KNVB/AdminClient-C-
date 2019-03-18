﻿using ObjectLibrary;
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

            TreeNode adminUserListNode = new TreeNode();
            adminUserListNode.Text = "Admin. Users";
            adminUserListNode.ImageIndex = 6;
            adminUserListNode.SelectedImageIndex = 6;
            administrationNode.Nodes.Add(adminUserListNode);

            return administrationNode;
        }
        private static TreeNode buildFtpServerListNode(AdminServer adminServer)
        {
            TreeNode ftpServerListNode = new TreeNode();
            ftpServerListNode.Text = "FTP Server List";
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
                    selectThisRemoveServerNode(mainForm, remoteServerNode);
                }
            }            
        }
        private static void selectThisRemoveServerNode(MainForm mainForm, TreeNode remoteServerNode)
        {
            ColumnHeader header1, header2;
            ListViewItem listViewItem;
            mainForm.Panel1Tree.SelectedNode = remoteServerNode;

            header1 = new ColumnHeader();
            header2 = new ColumnHeader();
            mainForm.listView1.Items.Clear();

            header1.Text = "Item";
            header1.TextAlign = HorizontalAlignment.Left;

            header2.Text = "Description";
            header2.TextAlign = HorizontalAlignment.Left;

            mainForm.listView1.Columns.Add(header1);
            mainForm.listView1.Columns.Add(header2);
            
           
            listViewItem = new ListViewItem();
            listViewItem.ImageIndex = 7;
            listViewItem.Text = "Administration";
            listViewItem.SubItems.Add("Remote server administration");
            mainForm.listView1.Items.Add(listViewItem);

            listViewItem = new ListViewItem();
            listViewItem.ImageIndex = 3;
            listViewItem.Text = "FTP Server List";
            listViewItem.SubItems.Add("All FTP server that under the remote server administration.");
            mainForm.listView1.Items.Add(listViewItem);

            /* 
             * If new items are added to the ListView, 
             * the columns will not resize unless AutoResizeColumns is called again.
             */             
            mainForm.listView1.AutoResizeColumns(ColumnHeaderAutoResizeStyle.HeaderSize);
        }

    }
}
