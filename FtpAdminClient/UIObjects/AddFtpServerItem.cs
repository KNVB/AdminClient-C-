using AdminServerObject;
using Newtonsoft.Json.Linq;

namespace FtpAdminClient
{
    internal class AddFtpServerItem:ListItem
    {
        internal AdminServer adminServer;
        internal AddFtpServerItem(JToken token) :base(token)
        {

        }
        internal override void doClick(UIManager uiManager)
        {
            uiManager.popupAddFtpServerDiaglog(adminServer,(FtpServerListNode)relatedNode);
        }
    }
}