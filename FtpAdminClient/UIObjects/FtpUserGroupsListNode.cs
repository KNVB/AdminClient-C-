using AdminServerObject;
using Newtonsoft.Json.Linq;
using System.Windows.Forms;

namespace FtpAdminClient
{
    public class FtpUserGroupsListNode:Node
    {
        string serverId;
        public FtpUserGroupsListNode(JToken token, AdminServer adminServer, ImageList imageList, string serverId) : base(token, adminServer, imageList)
        {
            nodeType = NodeType.FTPUserGroupsListNode;
            this.serverId= serverId;
        }
    }
}
