using System.Windows.Forms;
using Newtonsoft.Json.Linq;
using AdminServerObject;
namespace UIObject
{
    public class AdminServerNode : Node
    {
        public AdminServerAdministrationNode adminServerAdministrationNode;
        public FtpServerListNode ftpServerListNode;
        public AdminServerNode(JToken token, AdminServer adminServer) : base(token, adminServer)
        {
            nodeType = NodeType.AdminServerNode;
            adminServerAdministrationNode =new AdminServerAdministrationNode(token["adminServerAdministrationNode"],adminServer);
            ftpServerListNode=new FtpServerListNode(token["ftpServerListNode"], adminServer);
            this.Text = adminServer.serverName + ":" + adminServer.portNo;
            this.Name = this.Text;
            this.Nodes.Add(adminServerAdministrationNode);
            this.Nodes.Add(ftpServerListNode);
            this.ContextMenuStrip = new ContextMenuStrip();
        }
        public void handleSelectEvent(ListView listView)
        {
            ListItem listItem;

            initListView(listView);
            listItem = new ListItem();
            listItem.ListItemType = ListItemType.AdminServerAdministrationItem;
            listItem.Text = adminServerAdministrationNode.Text;
            listItem.Name = listItem.Text;
            listItem.relatedNode = adminServerAdministrationNode;
            listItem.SubItems.Add(adminServerAdministrationNode.description);
            listItem.ImageIndex = adminServerAdministrationNode.ImageIndex;
            listView.Items.Add(listItem);

            listItem = new ListItem();
            listItem.Text = ftpServerListNode.Text;
            listItem.Name = listItem.Text;
            listItem.relatedNode = ftpServerListNode;
            listItem.SubItems.Add(ftpServerListNode.description);
            listItem.ImageIndex = ftpServerListNode.ImageIndex;
            listView.Items.Add(listItem);
            
            listView.AutoResizeColumns(ColumnHeaderAutoResizeStyle.HeaderSize);
        }       
    }
}
