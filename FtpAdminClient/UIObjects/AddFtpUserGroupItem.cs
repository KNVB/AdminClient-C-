using AdminServerObject;
using Newtonsoft.Json.Linq;
namespace FtpAdminClient
{
    internal class AddFtpUserGroupItem:ListItem
    {
        internal AdminServer adminServer;
        internal string serverId;
        internal AddFtpUserGroupItem(JToken token) : base(token)
        {

        }
        internal override void doClick(UIManager uiManager)
        {

        }
    }
}