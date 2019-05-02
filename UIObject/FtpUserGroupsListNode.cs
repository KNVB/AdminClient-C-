using AdminServerObject;
using Newtonsoft.Json.Linq;

namespace UIObject
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
