using AdminServerObject;
using Newtonsoft.Json.Linq;
using System.Windows.Forms;

namespace UIObject
{
    public class FtpServerNode:Node
    {
        private FtpUserListNode ftpUsersListNode=null;
        private FtpUserGroupsListNode ftpUserGroupsListNode=null;
        public FtpServerNode(JToken token, AdminServer adminServer, string serverDesc,string serverId) : base(token, adminServer)
        {
            nodeType = NodeType.FTPServerNode;
            ftpUsersListNode = new FtpUserListNode(token["ftpUsersListNode"], adminServer,serverId);
            ftpUserGroupsListNode =new FtpUserGroupsListNode(token["ftpUserGroupsListNode"], adminServer, serverId);
            this.Text = serverDesc;
            this.Name = serverId;
            this.Nodes.Add(ftpUsersListNode);
            this.Nodes.Add(ftpUserGroupsListNode);
        }       
        public void handleSelectEvent(ListView listView)
        {
            
            ListItem listItem;

            initListView(listView);

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
