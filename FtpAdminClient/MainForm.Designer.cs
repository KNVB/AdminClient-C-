using System.Windows.Forms;

namespace FtpAdminClient
{
    partial class MainForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.TreeNode treeNode1 = new System.Windows.Forms.TreeNode(global::FtpAdminClient.Properties.Resources.Software_Name, 0, 0);
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.serverToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.addToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.splitContainer = new System.Windows.Forms.SplitContainer();
            this.Panel1Tree = new System.Windows.Forms.TreeView();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.settingList = new System.Windows.Forms.ListView();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer)).BeginInit();
            this.splitContainer.Panel1.SuspendLayout();
            this.splitContainer.Panel2.SuspendLayout();
            this.splitContainer.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.serverToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(284, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // serverToolStripMenuItem
            // 
            this.serverToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.addToolStripMenuItem,
            this.exitToolStripMenuItem});
            this.serverToolStripMenuItem.Name = "serverToolStripMenuItem";
            this.serverToolStripMenuItem.Size = new System.Drawing.Size(51, 20);
            this.serverToolStripMenuItem.Text = "Server";
            // 
            // addToolStripMenuItem
            // 
            this.addToolStripMenuItem.Name = "addToolStripMenuItem";
            this.addToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Alt | System.Windows.Forms.Keys.A)));
            this.addToolStripMenuItem.Size = new System.Drawing.Size(134, 22);
            this.addToolStripMenuItem.Text = "Add";
            this.addToolStripMenuItem.Click += new System.EventHandler(this.addToolStripMenuItem_Click);
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Alt | System.Windows.Forms.Keys.X)));
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(134, 22);
            this.exitToolStripMenuItem.Text = "Exit";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
            // 
            // splitContainer
            // 
            this.splitContainer.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.splitContainer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer.Location = new System.Drawing.Point(0, 24);
            this.splitContainer.Name = "splitContainer";
            // 
            // splitContainer.Panel1
            // 
            this.splitContainer.Panel1.Controls.Add(this.Panel1Tree);
            // 
            // splitContainer.Panel2
            // 
            this.splitContainer.Panel2.BackColor = System.Drawing.SystemColors.Window;
            this.splitContainer.Panel2.Controls.Add(this.settingList);
            this.splitContainer.Size = new System.Drawing.Size(284, 237);
            this.splitContainer.SplitterDistance = 137;
            this.splitContainer.TabIndex = 1;
            // 
            // Panel1Tree
            // 
            this.Panel1Tree.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Panel1Tree.ImageIndex = 0;
            this.Panel1Tree.ImageList = this.imageList1;
            this.Panel1Tree.Location = new System.Drawing.Point(0, 0);
            this.Panel1Tree.Name = "Panel1Tree";
            treeNode1.ImageIndex = 0;
            treeNode1.Name = "rootNode";
            treeNode1.SelectedImageIndex = 0;
            treeNode1.Text = global::FtpAdminClient.Properties.Resources.Software_Name;
            this.Panel1Tree.Nodes.AddRange(new System.Windows.Forms.TreeNode[] {
            treeNode1});
            this.Panel1Tree.SelectedImageIndex = 0;
            this.Panel1Tree.Size = new System.Drawing.Size(133, 233);
            this.Panel1Tree.TabIndex = 0;
            this.Panel1Tree.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.Panel1Tree_AfterSelect);
            // 
            // imageList1
            // 
            this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList1.Images.SetKeyName(0, "win7_ico_shell32_dll-216.jpg");
            this.imageList1.Images.SetKeyName(1, "icons8-root-server-24.png");
            this.imageList1.Images.SetKeyName(2, "icons8-root-server-48.png");
            this.imageList1.Images.SetKeyName(3, "1_-_Data_Center-512.png");
            this.imageList1.Images.SetKeyName(4, "Button Add.png");
            this.imageList1.Images.SetKeyName(5, "Button Close.png");
            this.imageList1.Images.SetKeyName(6, "win7_ico_shell32_dll-170.jpg");
            this.imageList1.Images.SetKeyName(7, "Admin-icon.png");
            this.imageList1.Images.SetKeyName(8, "Home-Server-icon.png");
            this.imageList1.Images.SetKeyName(9, "Button Delete.png");
            // 
            // settingList
            // 
            this.settingList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.settingList.FullRowSelect = true;
            this.settingList.Location = new System.Drawing.Point(0, 0);
            this.settingList.Name = "settingList";
            this.settingList.Size = new System.Drawing.Size(139, 233);
            this.settingList.SmallImageList = this.imageList1;
            this.settingList.TabIndex = 0;
            this.settingList.UseCompatibleStateImageBehavior = false;
            this.settingList.View = System.Windows.Forms.View.Details;
            this.settingList.Click += new System.EventHandler(this.settingList_SelectedIndexChanged);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 261);
            this.Controls.Add(this.splitContainer);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "MainForm";
            this.Text = Properties.Resources.Software_Name;
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainForm_FormClosing);
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.splitContainer.Panel1.ResumeLayout(false);
            this.splitContainer.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer)).EndInit();
            this.splitContainer.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem serverToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem addToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.SplitContainer splitContainer;
        internal System.Windows.Forms.TreeView Panel1Tree;
        internal System.Windows.Forms.ImageList imageList1;
        internal ListView settingList;
    }
}

