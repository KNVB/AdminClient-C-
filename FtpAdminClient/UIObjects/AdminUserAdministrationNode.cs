using Newtonsoft.Json.Linq;
using AdminServerObject;
namespace FtpAdminClient
{
    public class AdminUserAdministrationNode : Node
    {
        public AdminUserAdministrationNode(JToken token, AdminServer adminServer) : base(token, adminServer)
        {
            this.nodeType = NodeType.AdminUserAdministrationNode;
        }
    }
}