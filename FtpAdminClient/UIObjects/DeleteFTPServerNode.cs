using AdminServerObject;
using Newtonsoft.Json.Linq;
using System.Windows.Forms;

namespace FtpAdminClient
{
    public class DeleteFTPServerNode:Node
    {
        private JToken token;
        public string ftpServerId;
        public DeleteFTPServerNode(JToken token, AdminServer adminServer, ImageList imageList, string serverId) : base(token, adminServer,imageList)
        {
            this.token = token;
            this.ftpServerId= serverId;
            nodeType = NodeType.DeleteFTPServerNode;
        }
    }
}