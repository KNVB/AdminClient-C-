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
        public MainForm()
        {
            InitializeComponent();
      
        }
        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            ftpAdminClient.disconnectAllAdminServer();
        }
        private void MainForm_Load(object sender, EventArgs e)
        {
            popupConnectToServerDiaglog();
        }        
        private void addToolStripMenuItem_Click(object sender, EventArgs e)
        {
            popupConnectToServerDiaglog();
        }        
        internal void disconnectServer(string key)
        {
            ftpAdminClient.disconnectServer(key);
            rootNode.Nodes.RemoveByKey(key);
        }
        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
            this.Dispose();
        }
        private void popupConnectToServerDiaglog()
        {
            ConnectToServerForm ctsf = new ConnectToServerForm(ftpAdminClient.adminServerList);
            DialogResult dialogresult = ctsf.ShowDialog();
            if (dialogresult.Equals(DialogResult.OK))
            {
                TreeNode remoteServerNode = ftpAdminClient.addRemoteServer(ctsf.adminServer,this);
                rootNode.Nodes.Add(remoteServerNode);
                treeView1.SelectedNode = remoteServerNode;
            }
        }

        
    }    
}
