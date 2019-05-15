using AdminServerObject;
using Newtonsoft.Json.Linq;
using System.Collections.Generic;

namespace FtpAdminClient
{
    internal class FtpServerListNode : Node
    {
        public AddFtpServerItem addFTPServerItem;
        internal JToken token;
        internal SortedDictionary<string, FtpServerInfo> ftpServerList;
        internal FtpServerListNode(JToken token,AdminServer adminServer, UIManager uiManager) : base(token, adminServer,uiManager)
        {
            this.token= token; 
            updateFtpServerList();
            this.addFTPServerItem = new AddFtpServerItem(token["addFTPServerItem"]);
            this.addFTPServerItem.adminServer=adminServer;
            this.addFTPServerItem.ftpServerListNode = this;
            this.token= token;

        }
        internal void updateFtpServerList()
        {
            this.Nodes.Clear();
            ftpServerList = adminServer.getFTPServerList();
            foreach (FtpServerInfo ftpServerInfo in ftpServerList.Values)
            {
                FtpServerNode ftpServerNode = new FtpServerNode(token["ftpServerNode"], adminServer, uiManager, ftpServerInfo.description, ftpServerInfo.serverId);
                this.Nodes.Add(ftpServerNode);
            }
        }
        internal override void doSelect()
        {
            List<ListItem> itemList = new List<ListItem>();
            this.addFTPServerItem.adminServer = this.adminServer;
            foreach(string serverId in ftpServerList.Keys)
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