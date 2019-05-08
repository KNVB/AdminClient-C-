using AdminServerObject;
using Newtonsoft.Json.Linq;

namespace FtpAdminClient
{
    public class DeleteFTPServerNode:Node
    {
        private JToken token;
        public string ftpServerId;
        public DeleteFTPServerNode(JToken token, AdminServer adminServer, string serverId) : base(token, adminServer)
        {
            this.token = token;
            this.ftpServerId= serverId;
            nodeType = NodeType.DeleteFTPServerNode;
        }
    }
}