using Newtonsoft.Json.Linq;
using AdminServerObject;
namespace UIObject
{
    public class AdminUserAdministrationNode : Node
    {
        public AdminUserAdministrationNode(JToken token, AdminServer adminServer) : base(token, adminServer)
        {
            this.nodeType = NodeType.AdminUserAdministrationNode;
        }
    }
}