using AdminServerObject;
using Newtonsoft.Json.Linq;
using System.Collections.Generic;
using System.Windows.Forms;

namespace FtpAdminClient
{
    public class FtpServerNode:Node
    {
        private FtpUserListNode ftpUsersListNode=null;
        private FtpUserGroupsListNode ftpUserGroupsListNode=null;
        private FtpServerNetworkPropertiesNode ftpServerNetworkPropertiesNode = null;
        private SortedDictionary<string, dynamic> toolStripItemList;
        public FtpServerNode(JToken token, AdminServer adminServer, ImageList imageList, string serverDesc,string serverId) : base(token, adminServer,imageList)
        {
            nodeType = NodeType.FTPServerNode;
            ftpUsersListNode = new FtpUserListNode(token["ftpUsersListNode"], adminServer,imageList,serverId);
            ftpUserGroupsListNode =new FtpUserGroupsListNode(token["ftpUserGroupsListNode"], adminServer,imageList, serverId);
            ftpServerNetworkPropertiesNode = new FtpServerNetworkPropertiesNode(token["ftpServerNetworkPropertiesNode"], adminServer,imageList, serverId);
            toolStripItemList = token["ToolStripItemList"].ToObject<SortedDictionary<string, dynamic>>();
            foreach (string key in toolStripItemList.Keys)
            {
                ToolStripMenuItem tSI = toolStripItemList[key].ToObject<ToolStripMenuItem>();
                tSI.Click += (sender, e) => MessageBox.Show(serverId);
                this.ContextMenuStrip.Items.Add(tSI);
            }
            this.ContextMenuStrip.ImageList = imageList;
            this.Text = serverDesc;
            this.Name = serverId;
            this.Nodes.Add(ftpServerNetworkPropertiesNode);
            this.Nodes.Add(ftpUsersListNode);
            this.Nodes.Add(ftpUserGroupsListNode);
        }       
        public void handleSelectEvent(ListView listView)
        {
            
            ListItem listItem;

            initListView(listView);
            listView.Columns[0].Text += " on " + this.Text;

            listItem = new ListItem();
            listItem.Text = ftpServerNetworkPropertiesNode.Text;
            listItem.Name = listItem.Text;
            listItem.relatedNode = ftpServerNetworkPropertiesNode;
            listItem.SubItems.Add(ftpServerNetworkPropertiesNode.description);
            listItem.ImageIndex = ftpServerNetworkPropertiesNode.ImageIndex;
            listView.Items.Add(listItem);

            listItem = new ListItem();
            listItem.Text = ftpUsersListNode.Text;
            listItem.Name = listItem.Text;
            listItem.relatedNode = ftpUsersListNode;
            listItem.SubItems.Add(ftpUsersListNode.description);
            listItem.ImageIndex = ftpUsersListNode.ImageIndex;
            listView.Items.Add(listItem);

            listItem = new ListItem();
            listItem.Text = ftpUserGroupsListNode.Text;
            listItem.Name = listItem.Text;
            listItem.relatedNode = ftpUserGroupsListNode;
            listItem.SubItems.Add(ftpUserGroupsListNode.description);
            listItem.ImageIndex = ftpUserGroupsListNode.ImageIndex;
            listView.Items.Add(listItem);

            listView.AutoResizeColumns(ColumnHeaderAutoResizeStyle.HeaderSize);
        }
     }
  }
