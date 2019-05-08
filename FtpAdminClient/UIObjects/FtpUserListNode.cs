using AdminServerObject;
using Newtonsoft.Json.Linq;

namespace FtpAdminClient
{
    public class FtpUserListNode : Node
    {
        string serverId;
        public FtpUserListNode(JToken token, AdminServer adminServer, string serverId) : base(token, adminServer)
        {
            nodeType = NodeType.FTPUserListNode;
            this.serverId = serverId;
        }
    }
}
