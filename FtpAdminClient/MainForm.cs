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
            //popupConnectToServerDiaglog();
        }        
        private void addToolStripMenuItem_Click(object sender, EventArgs e)
        {
            popupConnectToServerDiaglog();
        }
        internal void AddToRootNode(TreeNode remoteServerNode)
        {
            rootNode.Nodes.Add(remoteServerNode);
        }
        internal void disconnectServer(string key)
        {
            ftpAdminClient.disconnectServer(key);
            rootNode.Nodes.RemoveByKey(key);
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
        private void popupConnectToServerDiaglog()
        {
            ConnectToServerForm ctsf = new ConnectToServerForm(ftpAdminClient);
            DialogResult dialogresult = ctsf.ShowDialog();
            if (dialogresult.Equals(DialogResult.OK))
            {
                Utility.rebuildRemoteServerList(this, ftpAdminClient);
                splitContainer.SelectNextControl((Control)splitContainer, true, true, true, true);
                settingList.Clear();
            }
        }

        private void settingList_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (settingList.SelectedItems.Count > 0)
            {
                switch (settingList.SelectedItems[0].Text)
                {
                    case "Add Remote Server":
                        popupConnectToServerDiaglog();
                        break;
                }
            }
            
        }

        private void Panel1Tree_AfterSelect(object sender, TreeViewEventArgs e)
        {
            
        }
    }    
}
