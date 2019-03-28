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
            administrationNode.Description = "Manage admin. server";

            ItemNode adminUserListNode = new ItemNode();
            adminUserListNode.Text = "Admin. Users";
            adminUserListNode.ImageIndex = 6;
            adminUserListNode.SelectedImageIndex = 6;
            adminUserListNode.Name = "adminUser";
            adminUserListNode.Description = "Manage admin. user";
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
        internal static ItemNode buildAdminServerNode(AdminServer adminServer)
        {
            ItemNode adminServerNode = new ItemNode();
            string key = adminServer.serverName + ":" + adminServer.portNo;

            adminServerNode.Text = key;
            adminServerNode.Name = "adminServer";
            adminServerNode.ImageIndex = 2;
            adminServerNode.SelectedImageIndex = 2;

            ContextMenuStrip adminTopMenu = new ContextMenuStrip();
            adminServerNode.Nodes.Add(buildAdministrationNode(adminServer));
            adminServerNode.Nodes.Add(buildFtpServerListNode(adminServer));
            adminServerNode.ContextMenuStrip = adminTopMenu;

            return adminServerNode;
        }

        internal static void initAdminServerList(ListView settingList, SortedDictionary<string, AdminServer> adminServerList,string rootNodePath)
        {
            AdminServer adminServer;
            SettingListItem listViewItem ;
            initNormalSettingListHeader(settingList);
            settingList.Items.Clear();
            if (adminServerList.Count==0)
            {
                listViewItem = new SettingListItem();
                listViewItem.ImageIndex = 4;
                listViewItem.Text = "Add Admin. Server";
                listViewItem.Name = "addAdminServer";

                initNormalSettingListHeader(settingList);
                settingList.Items.Add(listViewItem);
            }
            else
            {
                foreach (string key in adminServerList.Keys)
                {
                    adminServer = adminServerList[key];
                    listViewItem = new SettingListItem();
                    listViewItem.FullPath = rootNodePath+"\\"+ key;
                    listViewItem.Text = key;
                    listViewItem.Name = "adminServer";
                    listViewItem.ImageIndex = 2;
                    settingList.Items.Add(listViewItem);
                }
            }
            /* 
            * If new items are added to the ListView, 
            * the columns will not resize unless AutoResizeColumns is called again.
            */
           settingList.AutoResizeColumns(ColumnHeaderAutoResizeStyle.HeaderSize);
        }
        internal static void initFTPServerList(ListView settingList, string serverKey)
        {
            SettingListItem listViewItem = new SettingListItem();
            listViewItem.ImageIndex = 4;
            listViewItem.Text = "Add FTP Server";
            listViewItem.Name = "addFTPServer";
            listViewItem.FullPath= serverKey;
            settingList.Items.Clear();

            iniFTPServerListHeader(settingList);
            settingList.Items.Add(listViewItem);
            /* 
             * If new items are added to the ListView, 
             * the columns will not resize unless AutoResizeColumns is called again.
             */
            settingList.AutoResizeColumns(ColumnHeaderAutoResizeStyle.HeaderSize);
        }

        internal static void iniFTPServerListHeader(ListView settingList)
        {
            ColumnHeader header1, header2, header3;
            header1 = new ColumnHeader();
            header2 = new ColumnHeader();
            header3 = new ColumnHeader();

            header1.Text = "FTP Server";
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
        internal static void initNormalSettingListHeader(ListView settingList)
        {
            ColumnHeader header1, header2;
            header1 = new ColumnHeader();
            header2 = new ColumnHeader();
           
            header1.Text = "Name";
            header1.TextAlign = HorizontalAlignment.Left;

            header2.Text = "Description";
            header2.TextAlign = HorizontalAlignment.Left;
            settingList.Columns.Clear();
            settingList.Columns.Add(header1);
            settingList.Columns.Add(header2);
        }
        internal static TreeNode searchNodeByPath(TreeNode rootNode, string nodePath)
        {
            TreeNode resultNode=null;
            foreach (TreeNode n in rootNode.Nodes)
            {
                //MessageBox.Show(n.FullPath + "," + nodePath + "," + (n.FullPath == nodePath).ToString());
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
        internal static void updateList(ListView settingList, TreeNode node)
        {
            SettingListItem listViewItem;
            initNormalSettingListHeader(settingList);
            settingList.Items.Clear();
            foreach (ItemNode childNode in node.Nodes)
            {
                listViewItem = new SettingListItem();
                //listViewItem.serverKey = childNode.FullPath.Split('\\')[1];
                listViewItem.Text = childNode.Text;
                listViewItem.Name = childNode.Name;
                listViewItem.FullPath = childNode.FullPath;
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

        internal static void updateAdminServerList(ListView settingList, TreeNode adminServerNode)
        {
            updateList(settingList, adminServerNode);
        }
    }
}
