using System.Windows.Forms;
using Newtonsoft.Json.Linq;
using AdminServerObject;
using System.Collections.Generic;

namespace FtpAdminClient
{
    public class AdminServerNode : Node
    {
        public AdminServerAdministrationNode adminServerAdministrationNode;
        public FtpServerListNode ftpServerListNode;
        private SortedDictionary<string, dynamic> toolStripItemList;
        public AdminServerNode(JToken token, AdminServer adminServer, ImageList imageList) : base(token, adminServer,imageList)
        {
            nodeType = NodeType.AdminServerNode;
            adminServerAdministrationNode =new AdminServerAdministrationNode(token["adminServerAdministrationNode"],adminServer,imageList);
            ftpServerListNode=new FtpServerListNode(token["ftpServerListNode"], adminServer,imageList);
            toolStripItemList = token["ToolStripItemList"].ToObject<SortedDictionary<string, dynamic>>();
            foreach (string key in toolStripItemList.Keys)
            {
                ToolStripMenuItem tSI = toolStripItemList[key].ToObject<ToolStripMenuItem>();
                tSI.Click += (sender, e) => MessageBox.Show(adminServer.serverName+":"+adminServer.portNo);
                this.ContextMenuStrip.Items.Add(tSI);
            }
            this.ContextMenuStrip.ImageList = imageList;
            this.Text = adminServer.serverName + ":" + adminServer.portNo;
            this.Name = this.Text;
            this.Nodes.Add(adminServerAdministrationNode);
            this.Nodes.Add(ftpServerListNode);
        }
        public void handleSelectEvent(ListView listView)
        {
            ListItem listItem;

            initListView(listView);
            listItem = new ListItem();
            listItem.ListItemType = ListItemType.AdminServerAdministrationItem;
            listItem.Text = adminServerAdministrationNode.Text;
            listItem.Name = listItem.Text;
            listItem.relatedNode = adminServerAdministrationNode;
            listItem.SubItems.Add(adminServerAdministrationNode.description);
            listItem.ImageIndex = adminServerAdministrationNode.ImageIndex;
            listView.Items.Add(listItem);

            listItem = new ListItem();
            listItem.Text = ftpServerListNode.Text;
            listItem.Name = listItem.Text;
            listItem.relatedNode = ftpServerListNode;
            listItem.SubItems.Add(ftpServerListNode.description);
            listItem.ImageIndex = ftpServerListNode.ImageIndex;
            listView.Items.Add(listItem);
            
            listView.AutoResizeColumns(ColumnHeaderAutoResizeStyle.HeaderSize);
        }       
    }
}
