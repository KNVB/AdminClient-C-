using AdminServerObject;
using Newtonsoft.Json.Linq;
using System.Collections.Generic;
using System.Windows.Forms;

namespace UIObject
{
    public class FtpServerListNode : Node
    {
        public ListItem addFTPServerItem;
        private FtpServerNode ftpServerNode;
        private JToken token;
        private SortedDictionary<string, FtpServerInfo> ftpServerList;
        public FtpServerListNode(JToken token, AdminServer adminServer) : base(token, adminServer)
        {
            nodeType = NodeType.FTPServerListNode;
            ftpServerList = adminServer.getFTPServerList();
            this.token = token;
            this.Nodes.Clear();
            foreach (FtpServerInfo ftpServerInfo in ftpServerList.Values)
            {
                ftpServerNode = new FtpServerNode(this.token["ftpServerNode"], adminServer, ftpServerInfo.description, ftpServerInfo.serverId);
                this.Nodes.Add(ftpServerNode);
            }
            this.addFTPServerItem = new ListItem(this.token["addFTPServerItem"]);
            this.addFTPServerItem.relatedNode = this;
            this.addFTPServerItem.ListItemType = ListItemType.AddFTPServerItem;
        }

        public void handleSelectEvent(ListView listView)
        {
            FtpServerInfo ftpServerInfo;
            ListItem listItem;
            initListView(listView);
            this.addFTPServerItem.ListItemType = ListItemType.AddFTPServerItem;
            //ftpServerList = adminServer.getFTPServerList();
            foreach (string serverId in ftpServerList.Keys)
            {
                ftpServerNode = ((FtpServerNode)Nodes.Find(serverId, true)[0]);
                ftpServerInfo = ftpServerList[serverId];
                listItem = new ListItem();
                listItem.ListItemType = ListItemType.FTPServerListItem;
                listItem.relatedNode = ftpServerNode;
                listItem.Text = ftpServerInfo.description;
                listItem.Name = ftpServerInfo.serverId;
                listItem.ImageIndex =  ftpServerNode.ImageIndex;
                listItem.SubItems.Add("1");
                switch (ftpServerInfo.status)
                {
                    case FtpServerStatus.DISABLE:
                        listItem.SubItems.Add("Disabled");
                        break;
                    case FtpServerStatus.STARTED:
                        listItem.SubItems.Add("Started");
                        break;
                    case FtpServerStatus.STOPPED:
                        listItem.SubItems.Add("Stopped");
                        break;
                }

                listView.Items.Add(listItem);
            }
            listView.Items.Add(this.addFTPServerItem);
            listView.AutoResizeColumns(ColumnHeaderAutoResizeStyle.HeaderSize);
        }
        public void rebuildFtpServerTree(TreeView treeView)
        {
            FtpServerNode ftpServerNode;
            SortedDictionary<string, FtpServerInfo> ftpServerList = adminServer.getFTPServerList();
            this.Nodes.Clear();
            foreach (FtpServerInfo ftpServerInfo in ftpServerList.Values)
            {
                ftpServerNode = new FtpServerNode(this.token["ftpServerNode"], adminServer, ftpServerInfo.description, ftpServerInfo.serverId);
                this.Nodes.Add(ftpServerNode);
                if (adminServer.lastServerId.Equals(ftpServerInfo.serverId))
                {
                    treeView.SelectedNode = ftpServerNode;
                    this.Expand();
                }
            }
        }
    }
}