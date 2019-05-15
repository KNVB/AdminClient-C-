using System.Collections.Generic;
using Newtonsoft.Json.Linq;
using AdminServerObject;

namespace FtpAdminClient
{
    internal class RootNode:Node
    {
        private AdminServerManager adminServerManager;
        private AddAdminServerItem addAdminServerItem;
        public RootNode(JToken token, UIManager uiManager) : base(token, uiManager)
        {
            addAdminServerItem = new AddAdminServerItem(token["addAdminServerItem"]);

        }
        internal override void doSelect()
        {
            List<ListItem> itemList = new List<ListItem>();

            foreach (string key in this.adminServerManager.adminServerList.Keys)
            {
                ListItem listItem = new ListItem();
                listItem.relatedNode = (Node)Nodes.Find(key, true)[0];
                listItem.Text = key;
                listItem.Name = listItem.Text;
                listItem.ImageIndex = 2;
                itemList.Add(listItem);
            }
            itemList.Add(this.addAdminServerItem);
            uiManager.updateListView(this.colunmNameList, itemList);
        }
        public void setAdminServerManager(AdminServerManager adminServerManager)
        {
            this.adminServerManager = adminServerManager;
            addAdminServerItem.setAdminServerManager(adminServerManager);
        }
    }
}
