using System;
using System.Collections.Generic;
using ObjectLibrary;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using System.Drawing;
using System.IO;

namespace FtpAdminClient
{
    public partial class MainForm : Form
    {
        internal FtpAdminClient ftpAdminClient;
        private TreeNode rootNode;
        public MainForm()
        {
            InitializeComponent();
            ftpAdminClient=new FtpAdminClient();
            rootNode = Panel1Tree.Nodes[0];
        }
        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            ftpAdminClient.disconnectAllAdminServer();
        }
        private void MainForm_Load(object sender, EventArgs e)
        {
            Utility.initAdminServerList(settingList,new SortedDictionary<string, AdminServer>(),"");
        }        
        private void addToolStripMenuItem_Click(object sender, EventArgs e)
        {
            popupConnectToServerDiaglog();
        }
        private void disconnectServer(ItemNode adminServerNode)
        {
            ftpAdminClient.disconnectServer(adminServerNode.Text);
            Panel1Tree.SelectedNode = adminServerNode;
            rootNode.Nodes.Remove(adminServerNode);
        }
        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
            this.Dispose();
        }
        private void ftpServerHandler(string serverKey)
        {
            AdminServer adminServer= ftpAdminClient.adminServerList[serverKey];
            SortedDictionary<string, FtpServerInfo> ftpServerList= adminServer.getFTPServerList();
            if (ftpServerList.Count==0)
                Utility.initFTPServerList(settingList);
        }
        private void Panel1Tree_AfterSelect(object sender, TreeViewEventArgs e)
        {
            TreeNode node = e.Node;
            //MessageBox.Show("Panel1Tree_" + node.FullPath);

            string serverKey = "";
            if (node.FullPath.IndexOf("\\")>-1)
                serverKey = node.FullPath.Split('\\')[1];
            switch (node.Name)
            {
                case "adminUser":
                                popupAdminUserDiaglog(serverKey);
                                break;
                case "ftpServerList":
                                    ftpServerHandler(serverKey);
                                    break;
                case "rootNode":
                                Utility.initAdminServerList(settingList, ftpAdminClient.adminServerList,node.FullPath);
                                break;
                default:
                        Utility.updateList(settingList, node);
                        break;
            }
        }
        private void popupAdminUserDiaglog(string serverKey)
        {
            AdminUserForm adminUserForm = new AdminUserForm(serverKey);
            adminUserForm.ShowDialog();
        }
        private void popupConnectToServerDiaglog()
        {
            ConnectToServerForm ctsf = new ConnectToServerForm(ftpAdminClient);
            DialogResult dialogresult = ctsf.ShowDialog();
            if (dialogresult.Equals(DialogResult.OK))
            {
                splitContainer.SelectNextControl((Control)splitContainer, true, true, true, true);
                rebuildAdminServerList();
            }
        }
        private void rebuildAdminServerList()
        {
            ItemNode adminServerNode;
            rootNode.Nodes.Clear();
            foreach (string key in ftpAdminClient.adminServerList.Keys)
            {
                adminServerNode = Utility.buildAdminServerNode(ftpAdminClient.adminServerList[key]);
                ToolStripMenuItem disconnect = new ToolStripMenuItem();
                disconnect.Text = "Disconnect from the admin. server";
                disconnect.Click += new EventHandler((sender, e) => disconnectServer(adminServerNode));
                disconnect.Image = imageList1.Images[5];
                adminServerNode.ContextMenuStrip.Items.Add(disconnect);
                rootNode.Nodes.Add(adminServerNode);
                if (key== ftpAdminClient.lastServerKey)
                {
                    Panel1Tree.SelectedNode = adminServerNode;
                    adminServerNode.Expand();
                }
            }
        }
        private void settingList_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (settingList.SelectedItems.Count > 0)
            {
                //MessageBox.Show("settingList_" + settingList.SelectedItems[0].Name);
                ListViewItem listViewItem = settingList.SelectedItems[0];
                TreeNode node;
                string serverKey = "";
                if (((SettingListItem)listViewItem).FullPath.IndexOf("\\") > -1)
                    serverKey = ((SettingListItem)listViewItem).FullPath.Split('\\')[1];
                switch (listViewItem.Name)
                {
                    case "adminUser":
                                    popupAdminUserDiaglog(serverKey);
                                    break;
                    case "addAdminServer":
                                           popupConnectToServerDiaglog();
                                           break;
                    case "ftpServerList":
                                       
                                        ftpServerHandler(serverKey);
                                        splitContainer.SelectNextControl((Control)splitContainer, true, true, true, true);
                                        node = Utility.searchNodeByPath(rootNode, ((SettingListItem)listViewItem).FullPath);
                                        Panel1Tree.SelectedNode = node;
                                        node.Expand();
                                        break;
                   default:
                            node = Utility.searchNodeByPath(rootNode, ((SettingListItem)listViewItem).FullPath);
                            Utility.updateList(settingList, node);
                            splitContainer.SelectNextControl((Control)splitContainer, true, true, true, true);
                            Panel1Tree.SelectedNode = node;
                            node.Expand();
                            break;
                }
            }
        }

       
    }    
}
