using AdminServerObject;
using System;
using System.Windows.Forms;
using UIObject;
namespace FtpAdminClient
{
    public partial class MainForm : Form
    {
        AdminServerManager adminServerManager;
        UIManager uiManager;
        public MainForm()
        {
            InitializeComponent();
        }
        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            uiManager.disconnectAllAdminServer();
            uiManager = null;
        }
        private void MainForm_Load(object sender, EventArgs e)
        {
            this.Text = Properties.Resources.Software_Name;
            uiManager = new UIManager(splitContainer, imageList1, this.Text);
        }
        private void addToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
        }
        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
            this.Dispose();
        }
        private void Panel1Tree_AfterSelect(object sender, TreeViewEventArgs e)
        {
            uiManager.doSelectNodeEvent((AdminNode)e.Node);
        }
        private void settingList_SelectedIndexChanged(object sender, EventArgs e)
        {
            uiManager.doSelectListItemEvent();
        }
    }    
}
