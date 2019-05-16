using AdminServerObject;
using Newtonsoft.Json.Linq;
using System.Collections.Generic;
namespace FtpAdminClient
{
    internal class FtpServerNode : Node
    {
        internal FtpUserGroupsListNode ftpUserGroupsListNode = null;
        internal FtpUserListNode ftpUsersListNode = null;
        internal FtpServerNetworkPropertiesNode ftpServerNetworkPropertiesNode = null;
        internal string serverId;
        internal SortedDictionary<string, dynamic> toolStripItemList;
        public FtpServerNode(AdminServer adminServer, UIManager uiManager,string serverId) : base(adminServer, uiManager)
        {
            this.serverId = serverId;
        }
        internal override void doSelect()
        {
            List<ListItem> itemList = new List<ListItem>();
            ListItem listItem = new ListItem();

            listItem.Text = ftpServerNetworkPropertiesNode.Text;
            listItem.Name = listItem.Text;
            listItem.relatedNode = ftpServerNetworkPropertiesNode;
            listItem.SubItems.Add(ftpServerNetworkPropertiesNode.description);
            listItem.ImageIndex = ftpServerNetworkPropertiesNode.ImageIndex;
            itemList.Add(listItem);

            listItem = new ListItem();
            listItem.Text = ftpUsersListNode.Text;
            listItem.Name = listItem.Text;
            listItem.relatedNode = ftpUsersListNode;
            listItem.SubItems.Add(ftpUsersListNode.description);
            listItem.ImageIndex = ftpUsersListNode.ImageIndex;
            itemList.Add(listItem);

            listItem = new ListItem();
            listItem.Text = ftpUserGroupsListNode.Text;
            listItem.Name = listItem.Text;
            listItem.relatedNode = ftpUserGroupsListNode;
            listItem.SubItems.Add(ftpUserGroupsListNode.description);
            listItem.ImageIndex = ftpUserGroupsListNode.ImageIndex;
            itemList.Add(listItem);
            uiManager.updateListView(this.colunmNameList, itemList);
        }
        internal void init(JToken token)
        {
            base.init(token);
            toolStripItemList = token["ToolStripItemList"].ToObject<SortedDictionary<string, dynamic>>();
            ftpServerNetworkPropertiesNode=new FtpServerNetworkPropertiesNode(adminServer, uiManager, serverId);
            ftpUsersListNode = new FtpUserListNode(adminServer, uiManager, serverId);
            ftpUserGroupsListNode =new FtpUserGroupsListNode(adminServer, uiManager, serverId);

            ftpUsersListNode.init(token["ftpUsersListNode"]);
            ftpUserGroupsListNode.init(token["ftpUserGroupsListNode"]);
            ftpServerNetworkPropertiesNode.init(token["ftpServerNetworkPropertiesNode"]);
            this.Nodes.Add(ftpServerNetworkPropertiesNode);
            this.Nodes.Add(ftpUsersListNode);
            this.Nodes.Add(ftpUserGroupsListNode);
        }
    }
}