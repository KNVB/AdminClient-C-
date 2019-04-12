using AdminServerObject;
using System;
using System.Windows.Forms;
using UIObject;
namespace FtpAdminClient
{
    public partial class MainForm : Form
    {
        private AdminServerManager adminServerManager = new AdminServerManager();
        private RootNode rootNode;
        private UIManager uiManager=new UIManager();
        
        public MainForm()
        {
            InitializeComponent();
        }
        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            adminServerManager.disconnectAllAdminServer();
            uiManager = null;
        }
        private void MainForm_Load(object sender, EventArgs e)
        {
            this.Text = Properties.Resources.Software_Name;
            rootNode = uiManager.getRootNode();
            rootNode.Text = this.Text;
            rootNode.Name = rootNode.Text;
            Panel1Tree.Nodes.Add(rootNode);
        }
        private void addToolStripMenuItem_Click(object sender, EventArgs e)
        {
            uiManager.popupConnectToServerDiaglog();
        }
        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
            this.Dispose();
        }
        private void Panel1Tree_AfterSelect(object sender, TreeViewEventArgs e)
        {
            switch(((AdminNode)e.Node).nodeType)
            {
                case NodeType.RootNode:
                    ((RootNode)e.Node).handleSelectEvent(settingList, adminServerManager.adminServerList);
                    break;
            }
                // uiManager.doSelectNodeEvent((AdminNode)e.Node, settingList);
        }
        private void settingList_SelectedIndexChanged(object sender, EventArgs e)
        {
            ListItem listViewItem = (ListItem)settingList.SelectedItems[0];
            MessageBox.Show(Panel1Tree.Nodes.Find(listViewItem.fullPath,true).Length.ToString());
            //uiManager.doSelectListItemEvent(settingList);
        }
    }    
}
