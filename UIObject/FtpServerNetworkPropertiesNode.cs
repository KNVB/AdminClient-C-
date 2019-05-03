using AdminServerObject;
using Newtonsoft.Json.Linq;
namespace UIObject
{
    public class FtpServerNetworkPropertiesNode:Node
    {
       public string serverId;
       public FtpServerNetworkPropertiesNode(JToken token, AdminServer adminServer, string serverId) : base(token, adminServer)
       {
            nodeType = NodeType.FTPServerNetworkPropertiesNode;
            this.serverId = serverId;
        }
    }
}
