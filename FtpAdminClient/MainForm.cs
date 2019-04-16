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
            uiManager.popupConnectToServerDiaglog(splitContainer, Panel1Tree, settingList, imageList1);
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
                    uiManager.handleRootNodeSelectEvent(Panel1Tree, settingList, imageList1, adminServerManager.adminServerList);
                    break;
                case NodeType.AdminServerNode:
                    ((AdminServerNode)e.Node).handleSelectEvent(settingList);
                    break;
                case NodeType.AdminServerAdministrationNode:
                    ((AdminServerAdministrationNode)e.Node).handleSelectEvent(settingList);
                    break;
                case NodeType.AdminUserAdministrationNode:
                    ((AdminUserAdministrationNode)e.Node).handleSelectEvent(settingList);
                    break;   
            }
        }
        private void settingList_SelectedIndexChanged(object sender, EventArgs e)
        {
            ListItem listItem = (ListItem)settingList.SelectedItems[0];
            switch (listItem.ListItemType)
            {
                case ListItemType.AddAdminServerListItem:
                    uiManager.popupConnectToServerDiaglog(splitContainer, Panel1Tree, settingList, imageList1);
                    break;
            }
            /*if (listItem is AddAdminServerListItem)
                uiManager.popupConnectToServerDiaglog(splitContainer,Panel1Tree, settingList, imageList1);
            else
            {
                AdminNode node = (AdminNode)(Panel1Tree.Nodes.Find(listItem.fullPath, true)[0]);
                Panel1Tree.SelectedNode = node;
            }*/
        }
    }    
}
