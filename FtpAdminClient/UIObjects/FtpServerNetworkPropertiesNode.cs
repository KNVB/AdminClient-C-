using AdminServerObject;
using Newtonsoft.Json.Linq;
using System.Collections.Generic;

namespace FtpAdminClient
{
    internal class FtpServerNetworkPropertiesNode : Node
    {
        internal string serverId;
        internal FtpServerNetworkPropertiesNode(AdminServer adminServer, UIManager uiManager, string serverId) : base(adminServer, uiManager)
        {
            this.serverId = serverId;
        }
        internal override void doSelect()
        {
            uiManager.popupEditFtpServerNetworkPropertiesForm(this);
        }
    }
}