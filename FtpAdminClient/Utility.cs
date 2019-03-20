using ObjectLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace FtpAdminClient
{
    internal static class Utility
    {
        private static ItemNode buildAdministrationNode(AdminServer adminServer)
        {
            ItemNode administrationNode = new ItemNode();
            administrationNode.Text = "Administration";
            administrationNode.ImageIndex = 7;
            administrationNode.SelectedImageIndex = 7;
            administrationNode.Name = "administration";
            administrationNode.Description = "Remote server administration";

            ItemNode adminUserListNode = new ItemNode();
            adminUserListNode.Text = "Admin. Users";
            adminUserListNode.ImageIndex = 6;
            adminUserListNode.SelectedImageIndex = 6;
            adminUserListNode.Name = "adminUser";
            administrationNode.Nodes.Add(adminUserListNode);

            return administrationNode;
        }
        private static ItemNode buildFtpServerListNode(AdminServer adminServer)
        {
            ItemNode ftpServerListNode = new ItemNode();
            ftpServerListNode.Text = "FTP Server List";
            ftpServerListNode.Name = "ftpServerList";
            ftpServerListNode.ImageIndex = 3;
            ftpServerListNode.SelectedImageIndex = 3;
            ftpServerListNode.Description = "All FTP server that under the remote server administration.";
            return ftpServerListNode;
        }
        private static ItemNode buildRemoteServerNode(AdminServer adminServer, MainForm mainForm)
        {
            ItemNode remoteServerNode = new ItemNode();
            string key = adminServer.serverName + ":" + adminServer.portNo;

            remoteServerNode.Text = key;
            remoteServerNode.Name = "remoteServer";
            remoteServerNode.ImageIndex = 2;
            remoteServerNode.SelectedImageIndex = 2;
            ContextMenuStrip adminTopMenu = new ContextMenuStrip();
            ToolStripMenuItem disconnect = new ToolStripMenuItem();
            disconnect.Text = "Disconnect from the Remote admin. server";
            disconnect.Click += new EventHandler((sender, e) => mainForm.disconnectServer(remoteServerNode));
            disconnect.Image = mainForm.imageList1.Images[5];
            adminTopMenu.Items.Add(disconnect);

            remoteServerNode.Nodes.Add(buildAdministrationNode(adminServer));
            remoteServerNode.Nodes.Add(buildFtpServerListNode(adminServer));

            remoteServerNode.ContextMenuStrip = adminTopMenu;
            return remoteServerNode;
        }
        internal static void initNormalSettingListHeader(ListView settingList)
        {
            ColumnHeader header1, header2;
            header1 = new ColumnHeader();
            header2 = new ColumnHeader();
           
            header1.Text = "Item";
            header1.TextAlign = HorizontalAlignment.Left;

            header2.Text = "Description";
            header2.TextAlign = HorizontalAlignment.Left;
            settingList.Columns.Clear();
            settingList.Columns.Add(header1);
            settingList.Columns.Add(header2);
        }

        

        internal static void initNormalSettingList(ListView settingList)
        {
            ListViewItem listViewItem = new ListViewItem();
            listViewItem.ImageIndex = 4;
            listViewItem.Text = "Add Remote Server";
            listViewItem.Name = "addRemoteServer";

            settingList.Items.Clear();

            initNormalSettingListHeader(settingList);
            settingList.Items.Add(listViewItem);
            /* 
             * If new items are added to the ListView, 
             * the columns will not resize unless AutoResizeColumns is called again.
             */
            settingList.AutoResizeColumns(ColumnHeaderAutoResizeStyle.HeaderSize);
        }
        internal static void initServerSettingList(ListView settingList, SortedDictionary<string, AdminServer> adminServerList)
        {
            AdminServer adminServer;
            SettingListItem listViewItem ;
            
            initServerSettingListHeader(settingList);
            settingList.Items.Clear();

            foreach(string key in adminServerList.Keys)
            {
                adminServer= adminServerList[key];
                listViewItem = new SettingListItem();
                listViewItem.serverKey = key;
                listViewItem.Text = key;
                listViewItem.Name = "remoteServer";
                listViewItem.ImageIndex = 2;
                settingList.Items.Add(listViewItem);
            }
            /* 
            * If new items are added to the ListView, 
            * the columns will not resize unless AutoResizeColumns is called again.
            */
            settingList.AutoResizeColumns(ColumnHeaderAutoResizeStyle.HeaderSize);
        }
        internal static void initServerSettingListHeader(ListView settingList)
        {
            ColumnHeader header1, header2,header3;
            header1 = new ColumnHeader();
            header2 = new ColumnHeader();
            header3=new ColumnHeader();

            header1.Text = "Remote Server";
            header1.TextAlign = HorizontalAlignment.Left;

            header2.Text = "Users/Connection";
            header2.TextAlign = HorizontalAlignment.Left;

            header3.Text = "State";
            header3.TextAlign = HorizontalAlignment.Left;
            settingList.Columns.Clear();

            settingList.Columns.Add(header1);
            settingList.Columns.Add(header2);
            settingList.Columns.Add(header3);
        }
        internal static void rebuildRemoteServerList(MainForm mainForm, FtpAdminClient ftpAdminClient)
        {
            ItemNode remoteServerNode;
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
        internal static TreeNode searchNodeByPath(TreeNode rootNode, string nodePath)
        {
            TreeNode resultNode=null;
            foreach (TreeNode n in rootNode.Nodes)
            {
                MessageBox.Show(n.FullPath + "," + nodePath + "," + (n.FullPath == nodePath).ToString());
                if (n.FullPath==nodePath)
                {
                    return n;
                }
                else
                {
                    if (n.Nodes.Count > 0)
                    {
                        resultNode = searchNodeByPath(n, nodePath);
                    }
                    if (resultNode != null)
                        return resultNode;
                }

            }
            return null;
        }
        internal static void updateRemoteServerSettingList(ListView settingList, TreeNode remoteServerNode)
        {
            SettingListItem listViewItem;
            initNormalSettingListHeader(settingList);
            settingList.Items.Clear();
            foreach (ItemNode childNode in remoteServerNode.Nodes)
            {
                listViewItem = new SettingListItem();
                listViewItem.serverKey = childNode.FullPath.Split('\\')[1];
                listViewItem.Text = childNode.Text;
                listViewItem.Name = childNode.Name;
                listViewItem.SubItems.Add(childNode.Description);
                listViewItem.ImageIndex = childNode.ImageIndex;
                settingList.Items.Add(listViewItem);
            }
            /* 
            * If new items are added to the ListView, 
            * the columns will not resize unless AutoResizeColumns is called again.
            */
            settingList.AutoResizeColumns(ColumnHeaderAutoResizeStyle.HeaderSize);
        }
    }
}
