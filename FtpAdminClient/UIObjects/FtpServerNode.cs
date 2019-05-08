using AdminServerObject;
using Newtonsoft.Json.Linq;
using System.Windows.Forms;

namespace FtpAdminClient
{
    public class FtpServerNode:Node
    {
        public ListItem deleteFTPServerItem;
        private FtpUserListNode ftpUsersListNode=null;
        private FtpUserGroupsListNode ftpUserGroupsListNode=null;
        private FtpServerNetworkPropertiesNode ftpServerNetworkPropertiesNode = null;
        public FtpServerNode(JToken token, AdminServer adminServer, string serverDesc,string serverId) : base(token, adminServer)
        {
            nodeType = NodeType.FTPServerNode;
            deleteFTPServerItem=new ListItem(token["deleteFTPServerItem"]);
            deleteFTPServerItem.ListItemType = ListItemType.DeleteFTPServerItem;
            ftpUsersListNode = new FtpUserListNode(token["ftpUsersListNode"], adminServer,serverId);
            ftpUserGroupsListNode =new FtpUserGroupsListNode(token["ftpUserGroupsListNode"], adminServer, serverId);
            ftpServerNetworkPropertiesNode = new FtpServerNetworkPropertiesNode(token["ftpServerNetworkPropertiesNode"], adminServer, serverId);
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

            listView.Items.Add(this.deleteFTPServerItem);

            listView.AutoResizeColumns(ColumnHeaderAutoResizeStyle.HeaderSize);
        }
     }
  }
