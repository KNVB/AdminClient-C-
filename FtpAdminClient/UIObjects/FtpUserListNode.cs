using AdminServerObject;
using Newtonsoft.Json.Linq;
using System.Windows.Forms;

namespace FtpAdminClient
{
    public class FtpUserListNode : Node
    {
        string serverId;
        public FtpUserListNode(JToken token, AdminServer adminServer, ImageList imageList, string serverId) : base(token, adminServer,imageList)
        {
            nodeType = NodeType.FTPUserListNode;
            this.serverId = serverId;
        }
    }
}
