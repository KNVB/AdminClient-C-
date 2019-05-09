using Newtonsoft.Json.Linq;
using AdminServerObject;
using System.Windows.Forms;

namespace FtpAdminClient
{
    public class AdminUserAdministrationNode : Node
    {
        public AdminUserAdministrationNode(JToken token, AdminServer adminServer, ImageList imageList) : base(token, adminServer,imageList)
        {
            this.nodeType = NodeType.AdminUserAdministrationNode;
        }
    }
}