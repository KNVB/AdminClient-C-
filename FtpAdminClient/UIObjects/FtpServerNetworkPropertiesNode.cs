using AdminServerObject;
using Newtonsoft.Json.Linq;
using System.Windows.Forms;

namespace FtpAdminClient
{
    public class FtpServerNetworkPropertiesNode:Node
    {
       public string serverId;
       public FtpServerNetworkPropertiesNode(JToken token, AdminServer adminServer, ImageList imageList, string serverId) : base(token, adminServer,imageList)
       {
            nodeType = NodeType.FTPServerNetworkPropertiesNode;
            this.serverId = serverId;
        }
    }
}
