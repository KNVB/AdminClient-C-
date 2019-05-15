using AdminServerObject;
using Newtonsoft.Json.Linq;
using System.Collections.Generic;
namespace FtpAdminClient
{
    internal class FtpServerListNode : Node
    {
        internal AddFtpServerItem addFTPServerItem;
        internal FtpServerListNode(AdminServer adminServer, UIManager uiManager) : base(adminServer, uiManager)
        {
        }
        internal void init(JToken token)
        {
            base.init(token);
            addFTPServerItem = new AddFtpServerItem(token["addFTPServerItem"]);
            this.addFTPServerItem.relatedNode = this;
            this.addFTPServerItem.adminServer = adminServer;
            uiManager.refreshFtpServerListNode(adminServer, this);
        }
        internal override void doSelect()
        {
            SortedDictionary<string, FtpServerInfo> ftpServerList = adminServer.getFTPServerList();
            List<ListItem> itemList = new List<ListItem>();
            foreach (string serverId in ftpServerList.Keys)
            {
                ListItem ftpServerItem = new ListItem();
                FtpServerNode ftpServerNode = ((FtpServerNode)Nodes.Find(serverId, true)[0]);
                FtpServerInfo ftpServerInfo = ftpServerList[serverId];
                ftpServerItem.relatedNode = ftpServerNode;
                ftpServerItem.Text = ftpServerInfo.description;
                ftpServerItem.Name = ftpServerInfo.serverId;
                ftpServerItem.ImageIndex = ftpServerNode.ImageIndex;
                ftpServerItem.SubItems.Add("1");
                switch (ftpServerInfo.status)
                {
                    case FtpServerStatus.DISABLE:
                        ftpServerItem.SubItems.Add("Disabled");
                        break;
                    case FtpServerStatus.STARTED:
                        ftpServerItem.SubItems.Add("Started");
                        break;
                    case FtpServerStatus.STOPPED:
                        ftpServerItem.SubItems.Add("Stopped");
                        break;
                }
                itemList.Add(ftpServerItem);
            }
            itemList.Add(this.addFTPServerItem);
            uiManager.updateListView(this.colunmNameList, itemList);
        }
    }
}