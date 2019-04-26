using AdminServerObject;
using System;
using System.Collections.Generic;
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
            uiManager.popupConnectToServerDiaglog(splitContainer, Panel1Tree,  imageList1);
        }
        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
            this.Dispose();
        }
        private void Panel1Tree_Click(AdminNode node)
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
                    uiManager.popupAdminUserAdministrationForm(node.FullPath);
                    break;
                case NodeType.FTPServerListNode:
                    ((FTPServerListNode)node).handleSelectEvent(settingList);
                    break;
                case NodeType.FTPServerNode:
                    ((FTPServerNode)node).handleSelectEvent(settingList);
                    break;
                case NodeType.RootNode:
                    ((RootNode)node).handleSelectEvent(Panel1Tree, settingList, imageList1, adminServerManager.adminServerList);
                    break;
            }
        }
        private void Panel1Tree_AfterSelect(object sender, TreeViewEventArgs e)
        {
            Panel1Tree_Click((AdminNode)e.Node);
        }
        private void Panel1Tree_NodeMouseClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            if (Panel1Tree.SelectedNode == e.Node)
            {
                Panel1Tree_Click((AdminNode)e.Node);
            }
        }
        private void settingList_SelectedIndexChanged(object sender, EventArgs e)
        {
            ListItem listItem = (ListItem)settingList.SelectedItems[0];
            switch (listItem.ListItemType)
            {
                case ListItemType.AddAdminServerListItem:
                    uiManager.popupConnectToServerDiaglog(splitContainer, Panel1Tree,  imageList1);
                    break;
                /*
                case ListItemType.AddFTPServerListItem:
                    uiManager.popupAddFTPServerDiaglog(splitContainer, Panel1Tree,  imageList1, listItem.fullPath);
                    break;
                default:
                    splitContainer.SelectNextControl((Control)splitContainer, true, true, true, true);
                    AdminNode parentNode = listItem.parentNode;
                    AdminNode childNode = parentNode.findChildNodeByName(listItem.Name);
                    if (childNode == null)
                    {
                        MessageBox.Show(parentNode.Name +","+listItem.Name);
                    }
                    else
                    {
                        childNode.Expand();
                        Panel1Tree.SelectedNode = null;
                        Panel1Tree.SelectedNode = childNode;
                    }                   
                    break;
            }
        }
    }    
}
