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
            Utility.initSettingList(this);
        }        
        private void addToolStripMenuItem_Click(object sender, EventArgs e)
        {
            popupConnectToServerDiaglog();
        }
        internal void AddToRootNode(ItemNode remoteServerNode)
        {
            rootNode.Nodes.Add(remoteServerNode);
        }
        internal void disconnectServer(ItemNode remoteServerNode)
        {
            ftpAdminClient.disconnectServer(remoteServerNode.Text);
            Panel1Tree.SelectedNode = remoteServerNode;
            rootNode.Nodes.Remove(remoteServerNode);
        }
        internal void clearRootNode()
        {
            rootNode.Nodes.Clear();
        }
        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
            this.Dispose();
        }
        private void ftpServerHandler()
        {

        }
        private void popupConnectToServerDiaglog()
        {
            ConnectToServerForm ctsf = new ConnectToServerForm(ftpAdminClient);
            DialogResult dialogresult = ctsf.ShowDialog();
            if (dialogresult.Equals(DialogResult.OK))
            {
                splitContainer.SelectNextControl((Control)splitContainer, true, true, true, true);
                Utility.rebuildRemoteServerList(this, ftpAdminClient);
            }
        }

        private void settingList_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (settingList.SelectedItems.Count > 0)
            {
                MessageBox.Show("settingList_" + settingList.SelectedItems[0].Name);
                switch (settingList.SelectedItems[0].Name)
                {
                    case "addRemoteServer":
                                           popupConnectToServerDiaglog();
                                           break;
                    case "ftpServerList":
                                        ftpServerHandler();
                                        break;
                }
            }
        }

        private void Panel1Tree_AfterSelect(object sender, TreeViewEventArgs e)
        {
            ListViewItem listViewItem;
            TreeNode node = e.Node;
            MessageBox.Show("Panel1Tree_" + node.Name);
            switch (node.Name)
            {
                case "ftpServerList":
                                    ftpServerHandler();
                                    break;
                case "rootNode":
                                Utility.initSettingList(this);
                                break;
                case "remoteServer":
                                   
                                    Utility.initSettingListHeader(this);
                                    settingList.Items.Clear();
                                    foreach (ItemNode childNode in node.Nodes)
                                    {
                                        listViewItem = new ListViewItem();
                                        listViewItem.Text = childNode.Text;
                                        listViewItem.Name = childNode.Name;
                                        listViewItem.SubItems.Add(childNode.Description);
                                        listViewItem.ImageIndex =childNode.ImageIndex;
                                        settingList.Items.Add(listViewItem);
                                    }
                                    /* 
                                    * If new items are added to the ListView, 
                                    * the columns will not resize unless AutoResizeColumns is called again.
                                    */
                                    settingList.AutoResizeColumns(ColumnHeaderAutoResizeStyle.HeaderSize);
                                    break;
            }
        }
    }    
}
