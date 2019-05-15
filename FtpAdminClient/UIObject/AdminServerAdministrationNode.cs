using System.Collections.Generic;
using Newtonsoft.Json.Linq;
using AdminServerObject;

namespace FtpAdminClient
{
    internal class AdminServerAdministrationNode : Node
    {
        public AdminUserAdministrationNode adminUserAdministrationNode;
        internal AdminServerAdministrationNode(JToken token, AdminServer adminServer, UIManager uiManager) : base(token,adminServer, uiManager)
        {

            adminUserAdministrationNode = new AdminUserAdministrationNode(token["adminUserAdministrationNode"],adminServer, uiManager);
            
            this.Nodes.Clear();
            this.Nodes.Add(adminUserAdministrationNode);
        }
        internal override void doSelect()
        {
            adminUserAdministrationNode.adminServer = adminServer;
            List<ListItem> itemList = new List<ListItem>();
            ListItem adminUserAdministrationListItem = new ListItem();
            adminUserAdministrationListItem.ImageIndex = adminUserAdministrationNode.SelectedImageIndex;
            adminUserAdministrationListItem.Text = adminUserAdministrationNode.Text;
            adminUserAdministrationListItem.Name = adminUserAdministrationNode.Name;
            adminUserAdministrationListItem.SubItems.Add(adminUserAdministrationNode.description);
            adminUserAdministrationListItem.relatedNode = adminUserAdministrationNode;
            itemList.Add(adminUserAdministrationListItem);
            uiManager.updateListView(this.colunmNameList, itemList);
        }
    }
}
