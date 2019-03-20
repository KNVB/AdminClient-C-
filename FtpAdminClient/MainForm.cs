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
            Utility.initNormalSettingList(settingList);
        }        
        private void addToolStripMenuItem_Click(object sender, EventArgs e)
        {
            popupConnectToServerDiaglog();
        }
        private void disconnectServer(ItemNode remoteServerNode)
        {
            ftpAdminClient.disconnectServer(remoteServerNode.Text);
            Panel1Tree.SelectedNode = remoteServerNode;
            rootNode.Nodes.Remove(remoteServerNode);
        }
        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
            this.Dispose();
        }
        private void ftpServerHandler(string serverKey)
        {

        }
        private void Panel1Tree_AfterSelect(object sender, TreeViewEventArgs e)
        {
            TreeNode node = e.Node;
            MessageBox.Show("Panel1Tree_" + node.FullPath);
            switch (node.Name)
            {
                case "ftpServerList":
                                    ftpServerHandler(node.FullPath.Split('\\')[1]);
                                    break;
                case "rootNode":
                                if (ftpAdminClient.adminServerList.Count == 0)
                                    Utility.initNormalSettingList(settingList);
                                else
                                    Utility.initServerSettingList(settingList, ftpAdminClient.adminServerList);
                                break;
                case "remoteServer":
                                    Utility.updateRemoteServerSettingList(settingList, node);
                                    break;
            }
        }
        private void popupConnectToServerDiaglog()
        {
            ConnectToServerForm ctsf = new ConnectToServerForm(ftpAdminClient);
            DialogResult dialogresult = ctsf.ShowDialog();
            if (dialogresult.Equals(DialogResult.OK))
            {
                splitContainer.SelectNextControl((Control)splitContainer, true, true, true, true);
                rebuildRemoteServerList();
            }
        }
        private void rebuildRemoteServerList()
        {
            ItemNode remoteServerNode;
            rootNode.Nodes.Clear();
            foreach (string key in ftpAdminClient.adminServerList.Keys)
            {
                remoteServerNode = Utility.buildRemoteServerNode(ftpAdminClient.adminServerList[key]);
                ToolStripMenuItem disconnect = new ToolStripMenuItem();
                disconnect.Text = "Disconnect from the Remote admin. server";
                disconnect.Click += new EventHandler((sender, e) => disconnectServer(remoteServerNode));
                disconnect.Image = imageList1.Images[5];
                remoteServerNode.ContextMenuStrip.Items.Add(disconnect);
                rootNode.Nodes.Add(remoteServerNode);
                if (key== ftpAdminClient.lastServerKey)
                {
                    Panel1Tree.SelectedNode = remoteServerNode;
                    remoteServerNode.Expand();
                }
            }
        }
        private void settingList_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (settingList.SelectedItems.Count > 0)
            {
                MessageBox.Show("settingList_" + settingList.SelectedItems[0].Name);
                ListViewItem listViewItem = settingList.SelectedItems[0];
                switch (listViewItem.Name)
                {
                    case "addRemoteServer":
                                           popupConnectToServerDiaglog();
                                           break;
                    case "ftpServerList":
                                        ftpServerHandler(((SettingListItem)listViewItem).serverKey);
                                        break;
                    case "remoteServer":
                                        string nodePath=rootNode.FullPath+"\\"+(((SettingListItem)listViewItem).serverKey);
                                        TreeNode node=Utility.searchNodeByPath(rootNode, nodePath);
                                        Utility.updateRemoteServerSettingList(settingList, node);
                                        splitContainer.SelectNextControl((Control)splitContainer, true, true, true, true);
                                        Panel1Tree.SelectedNode = node;
                                        break;
                                            
                }
            }
        }

       
    }    
}
