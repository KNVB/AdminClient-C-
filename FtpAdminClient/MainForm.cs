using AdminServerObject;
using System;
using System.Windows.Forms;
using UIObject;
namespace FtpAdminClient
{
    public partial class MainForm : Form
    {
        private AdminServerManager adminServerManager;
        private RootNode rootNode;
        private UIManager uiManager;
        
        public MainForm()
        {
            InitializeComponent();
            adminServerManager = new AdminServerManager();
            uiManager = new UIManager(adminServerManager);
            this.Text = uiManager.getSoftwareName();
            serverToolStripMenuItem.Text = uiManager.getAdminServerLabel();
            addToolStripMenuItem.Text = uiManager.getConnectLabel();
            exitToolStripMenuItem.Text = uiManager.getExitLabel();
        }
        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            adminServerManager.disconnectAllAdminServer();
            uiManager = null;
        }
        private void MainForm_Load(object sender, EventArgs e)
        {
            rootNode = uiManager.getRootNode();
            rootNode.Text = this.Text;
            rootNode.Name = rootNode.Text;
            Panel1Tree.Nodes.Add(rootNode);
        }
        
        private void addToolStripMenuItem_Click(object sender, EventArgs e)
        {
            uiManager.popupConnectToAdminServerDiaglog(splitContainer, Panel1Tree,  imageList1);
        }
        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
            this.Dispose();
        }
        private void Panel1Tree_Click(Node node)
        {
            //AdminServer adminServer= uiManager.getAdminServer(node.FullPath);
            switch (node.nodeType)
            {
                case NodeType.AdminServerNode:
                    ((AdminServerNode)node).handleSelectEvent(settingList);
                    break;
                case NodeType.AdminServerAdministrationNode:
                    ((AdminServerAdministrationNode)node).handleSelectEvent(settingList);
                    break;
                case NodeType.AdminUserAdministrationNode:
                    uiManager.popupAdminUserAdministrationForm(node.adminServer);
                    break;
                case NodeType.DeleteFTPServerNode:
                    uiManager.deleteFtpServer((DeleteFTPServerNode)node, Panel1Tree);
                    break;
                case NodeType.FTPServerListNode:
                    ((FtpServerListNode)node).handleSelectEvent(settingList);
                    break;
                case NodeType.FTPServerNode:
                    ((FtpServerNode)node).handleSelectEvent(settingList);
                    break;
                case NodeType.FTPServerNetworkPropertiesNode:
                    uiManager.popupEditFtpServerNetworkPropertiesForm((FtpServerNetworkPropertiesNode)node);
                    break;
                case NodeType.RootNode:
                    ((RootNode)node).handleSelectEvent(settingList, adminServerManager.adminServerList);
                    break;
            }
        }
        private void Panel1Tree_AfterSelect(object sender, TreeViewEventArgs e)
        {
            Panel1Tree_Click((Node)e.Node);
        }
        private void Panel1Tree_NodeMouseClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            if (Panel1Tree.SelectedNode == e.Node)
            {
                Panel1Tree_Click((Node)e.Node);
            }
        }
        private void settingList_SelectedIndexChanged(object sender, EventArgs e)
        {
            ListItem listItem = (ListItem)settingList.SelectedItems[0];
            switch (listItem.ListItemType)
            {
                case ListItemType.AddAdminServerItem:
                    uiManager.popupConnectToAdminServerDiaglog(splitContainer, Panel1Tree,  imageList1);
                    break;
                case ListItemType.AddFTPServerItem:
                    uiManager.popupAddFTPServerDiaglog(splitContainer, Panel1Tree, listItem);
                    break;
                default:
                    splitContainer.SelectNextControl((Control)splitContainer, true, true, true, true);
                    Node relatedNode = listItem.relatedNode;
                    if (relatedNode == null)
                    {
                        MessageBox.Show(listItem.Name);
                    }
                    else
                    {
                        relatedNode.Expand();
                        Panel1Tree.SelectedNode = null;
                        Panel1Tree.SelectedNode = relatedNode;
                    }                   
                    break;
            }
        }       
    }    
}
