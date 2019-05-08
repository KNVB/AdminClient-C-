using AdminServerObject;
using Newtonsoft.Json.Linq;

namespace FtpAdminClient
{
    public class FtpUserGroupsListNode:Node
    {
        string serverId;
        public FtpUserGroupsListNode(JToken token, AdminServer adminServer, string serverId) : base(token, adminServer)
        {
            nodeType = NodeType.FTPUserGroupsListNode;
            this.serverId= serverId;
        }
    }
}
