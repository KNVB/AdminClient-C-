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
            AdminServer adminServer;
            FtpServerInfo ftpServerInfo;
            foreach (string key in adminServerList.Keys)
            {
                adminServer = adminServerList[key];
                ftpServerInfo = adminServer.getInitialFtpServerInfo();
                ContextMenuStrip adminTopMenu = new ContextMenuStrip();
                ContextMenuStrip ftpServerAdminMenu = new ContextMenuStrip();
                TreeNode adminServerNode = new TreeNode();
                adminServerNode.ImageIndex = 0;
                adminServerNode.SelectedImageIndex = 0;
                adminServerNode.Text = key;
               
                ToolStripMenuItem disconnect = new ToolStripMenuItem();
                disconnect.Text = "Disconnect from the admin. server";
                disconnect.Click += new EventHandler((sender, e)=>disconnectServer(key));
                adminTopMenu.Items.Add(disconnect);

                adminServerNode.ContextMenuStrip = adminTopMenu;

                TreeNode ftpServerListNode = new TreeNode();
                ftpServerListNode.Text = "FTP Server List";
                ftpServerListNode.ImageIndex = 1;
                ftpServerListNode.SelectedImageIndex = 1;

                ToolStripMenuItem addFTP = new ToolStripMenuItem();
                addFTP.Text = "Add a new FTP server";
                addFTP.Image = imageList1.Images[2];
            //    addFTP.Click += new EventHandler((sender, e) => showFTPParametersForm(ftpServerInfo)); 

                ftpServerAdminMenu.Items.Add(addFTP);
                ftpServerListNode.ContextMenuStrip = ftpServerAdminMenu;
                adminServerNode.Nodes.Add(ftpServerListNode);
                treeView1.Nodes.Add(adminServerNode);
            }
        }
        /*
        private void showFTPParametersForm(FtpServerInfo ftpServerInfo)
        {
            tableLayoutPanel1.Controls.Clear();
            tableLayoutPanel1.RowStyles.Clear();
            tableLayoutPanel1.ColumnCount = 2;

            Label lbl = new Label();
            TextBox Text1 = new TextBox();
            tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));

            lbl.Text= "Server Description:";
            tableLayoutPanel1.Controls.Add(lbl, 0, 0);
            tableLayoutPanel1.Controls.Add(Text1, 1, 0);

        }    */    
    }
}
