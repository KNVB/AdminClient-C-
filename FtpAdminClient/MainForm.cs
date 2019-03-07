using System;
using System.Collections.Generic;
using ObjectLibrary;
using System.Windows.Forms;

namespace FtpAdminClient
{
    public partial class MainForm : Form
    {
        private SortedDictionary<string, AdminServer> adminServerList = new SortedDictionary<string, AdminServer>();
        public MainForm()
        {
            InitializeComponent();
        }
        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            AdminServer adminServer;
            foreach (string key in adminServerList.Keys)
            {
                adminServer = adminServerList[key];
                adminServer.disConnect();
            }

        }
        private void MainForm_Load(object sender, EventArgs e)
        {
            popupConnectToServerDiaglog();
        }
        private void addToolStripMenuItem_Click(object sender, EventArgs e)
        {
            popupConnectToServerDiaglog();
        }
        private void disconnectServer(string key)
        {
            AdminServer adminServer;
            adminServer = adminServerList[key];
            adminServer.disConnect();
            adminServerList.Remove(key);
            refreshUI();
        }
        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
            this.Dispose();
        }
        private void popupConnectToServerDiaglog()
        {
            ConnectToServerForm ctsf = new ConnectToServerForm(adminServerList);
            DialogResult dialogresult = ctsf.ShowDialog();
            if (dialogresult.Equals(DialogResult.OK))
            {
                adminServerList.Add(ctsf.adminServer.serverName + ":" + ctsf.adminServer.portNo, ctsf.adminServer);
                refreshUI();
            }
            ctsf.Dispose();
        }
        private void refreshUI()
        {
            treeView1.Nodes.Clear();
            foreach (string key in adminServerList.Keys)
            {
                ContextMenuStrip docMenu = new ContextMenuStrip();
                TreeNode adminServerNode = new TreeNode();
                adminServerNode.Text = key;
                ToolStripMenuItem addFTP = new ToolStripMenuItem();
                addFTP.Text = "Add FTP server";
                docMenu.Items.Add(addFTP);

                ToolStripMenuItem disconnect = new ToolStripMenuItem();
                disconnect.Text = "Disconnect from admin. server";
                disconnect.Click += new EventHandler((sender, e)=>disconnectServer(key));
                docMenu.Items.Add(disconnect);

                adminServerNode.ContextMenuStrip = docMenu;

                TreeNode ftpServerListNode = new TreeNode();
                ftpServerListNode.Text = "FTP Server List";

                adminServerNode.Nodes.Add(ftpServerListNode);
                treeView1.Nodes.Add(adminServerNode);
            }
        }

        private void treeView1_NodeMouseClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            TreeNode node = e.Node;
            if (node != null)
                MessageBox.Show(this,node.Text,"Alert");
        }       
    }
}
