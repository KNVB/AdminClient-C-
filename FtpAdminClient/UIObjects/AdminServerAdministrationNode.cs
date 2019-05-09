using Newtonsoft.Json.Linq;
using System.Windows.Forms;
using AdminServerObject;
namespace FtpAdminClient
{
    public class AdminServerAdministrationNode:Node
    {
        public AdminUserAdministrationNode adminUserAdministrationNode;
        public AdminServerAdministrationNode(JToken token, AdminServer adminServer, ImageList imageList) : base(token, adminServer,imageList)
        {
            nodeType = NodeType.AdminServerAdministrationNode;
            adminUserAdministrationNode = new AdminUserAdministrationNode(token["adminUserAdministrationNode"], adminServer,imageList);
            this.Nodes.Add(adminUserAdministrationNode);
        }
        public void handleSelectEvent(ListView listView)
        {
            initListView(listView);
            ListItem adminUserAdministrationListItem = new ListItem();
            adminUserAdministrationListItem.ImageIndex = adminUserAdministrationNode.SelectedImageIndex;
            adminUserAdministrationListItem.Text = adminUserAdministrationNode.Text;
            adminUserAdministrationListItem.Name = adminUserAdministrationNode.Name;
            adminUserAdministrationListItem.SubItems.Add(adminUserAdministrationNode.description);
            adminUserAdministrationListItem.relatedNode = adminUserAdministrationNode;
            listView.Items.Add(adminUserAdministrationListItem);
            listView.AutoResizeColumns(ColumnHeaderAutoResizeStyle.HeaderSize);
        }
    }
}