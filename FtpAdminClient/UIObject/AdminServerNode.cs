using System.Collections.Generic;
using Newtonsoft.Json.Linq;
using AdminServerObject;

namespace FtpAdminClient
{
    internal class AdminServerNode : Node
    {
        internal FtpServerListNode ftpServerListNode;
        internal AdminServerAdministrationNode adminServerAdministrationNode;
        internal SortedDictionary<string, dynamic> toolStripItemList;
        internal AdminServerNode(JToken token, AdminServer adminServer, UIManager uiManager) : base(token, adminServer, uiManager)
        {
            toolStripItemList = token["ToolStripItemList"].ToObject<SortedDictionary<string, dynamic>>();
            adminServerAdministrationNode = new AdminServerAdministrationNode(token["adminServerAdministrationNode"], adminServer, uiManager);
            ftpServerListNode = new FtpServerListNode(token["ftpServerListNode"], adminServer, uiManager);
            uiManager.refreshFtpServerListNode(ftpServerListNode);
            this.Nodes.Clear();
            this.Nodes.Add(adminServerAdministrationNode);
            this.Nodes.Add(ftpServerListNode);
        }
        internal override void doSelect()
        {
            List<ListItem> itemList = new List<ListItem>();
            ListItem listItem = new ListItem();
            listItem.Text = adminServerAdministrationNode.Text;
            listItem.Name = listItem.Text;
            listItem.relatedNode = adminServerAdministrationNode;
            listItem.SubItems.Add(adminServerAdministrationNode.description);
            listItem.ImageIndex = adminServerAdministrationNode.ImageIndex;
            itemList.Add(listItem);

            listItem = new ListItem();
            listItem.Text = ftpServerListNode.Text;
            listItem.Name = listItem.Text;
            listItem.relatedNode = ftpServerListNode;
            listItem.SubItems.Add(ftpServerListNode.description);
            listItem.ImageIndex = ftpServerListNode.ImageIndex;
            itemList.Add(listItem);
            uiManager.updateListView(this.colunmNameList, itemList);
        }
    }
}
