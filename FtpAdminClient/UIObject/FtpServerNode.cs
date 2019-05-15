using AdminServerObject;
using Newtonsoft.Json.Linq;
using System.Collections.Generic;

namespace FtpAdminClient
{
    internal class FtpServerNode:Node
    {
        internal FtpServerNetworkPropertiesNode ftpServerNetworkPropertiesNode;
        internal FtpUserListNode ftpUserListNode;
        internal FtpUserGroupsListNode ftpUserGroupsListNode;

        internal SortedDictionary<string, dynamic> toolStripItemList;
        internal FtpServerNode(JToken token, AdminServer adminServer, UIManager uiManager, string serverDesc,string serverId) : base(token, adminServer, uiManager)
        {
            toolStripItemList = token["ToolStripItemList"].ToObject<SortedDictionary<string, dynamic>>();
            ftpUserListNode = new FtpUserListNode(token["ftpUsersListNode"], adminServer, uiManager, serverId);
            ftpUserGroupsListNode = new FtpUserGroupsListNode(token["ftpUserGroupsListNode"], adminServer,uiManager, serverId);
            ftpServerNetworkPropertiesNode=new FtpServerNetworkPropertiesNode(token["ftpServerNetworkPropertiesNode"], adminServer, uiManager, serverId);
            this.Text = serverDesc;
            this.Name = serverId;
            this.Nodes.Clear();
            this.Nodes.Add(ftpServerNetworkPropertiesNode);
            this.Nodes.Add(ftpUserListNode);
            this.Nodes.Add(ftpUserGroupsListNode);
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
            listItem.Text = ftpUserListNode.Text;
            listItem.Name = listItem.Text;
            listItem.relatedNode = ftpUserListNode;
            listItem.SubItems.Add(ftpUserListNode.description);
            listItem.ImageIndex = ftpUserListNode.ImageIndex;
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
    }
  }
