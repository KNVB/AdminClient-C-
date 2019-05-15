using AdminServerObject;
using Newtonsoft.Json.Linq;
using System.Collections.Generic;

namespace FtpAdminClient
{
    internal class FtpServerNetworkPropertiesNode : Node
    {
        string serverId;
        internal FtpServerNetworkPropertiesNode(AdminServer adminServer, UIManager uiManager, string serverId) : base(adminServer, uiManager)
        {
            this.serverId = serverId;
        }
        internal override void doSelect()
        {
           // List<ListItem> itemList = new List<ListItem>();
           // uiManager.updateListView(this.colunmNameList, itemList);
        }
    }
}