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
        private SortedDictionary<string, FtpServerInfo> ftpServerList;
        public FtpServerListNode(JToken token, AdminServer adminServer) : base(token, adminServer)
        {
            nodeType = NodeType.FTPServerListNode;
            ftpServerList = adminServer.getFTPServerList();
            this.Nodes.Clear();
            foreach (FtpServerInfo ftpServerInfo in ftpServerList.Values)
            {
                ftpServerNode = new FtpServerNode(token["ftpServerNode"], adminServer, ftpServerInfo.description, ftpServerInfo.serverId);
                this.Nodes.Add(ftpServerNode);
            }
            this.addFTPServerItem = new ListItem(token["addFTPServerItem"]);
            this.addFTPServerItem.relatedNode = this;
            this.addFTPServerItem.ListItemType = ListItemType.AddFTPServerItem;
        }

        public void handleSelectEvent(ListView listView)
        {
            FtpServerInfo ftpServerInfo;
            ListItem listItem;
            initListView(listView);
            this.addFTPServerItem.ListItemType = ListItemType.AddFTPServerItem;
            ftpServerList = adminServer.getFTPServerList();
            foreach (string serverId in ftpServerList.Keys)
            {
                ftpServerInfo = ftpServerList[serverId];
                listItem = new ListItem();
                listItem.ListItemType = ListItemType.FTPServerListItem;
                listItem.relatedNode = this;
                listItem.Text = ftpServerInfo.description;
                listItem.Name = ftpServerInfo.serverId;
          //      listItem.ImageIndex = ftpServerNodeTemplate.SelectedImageIndex;
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
    }
}