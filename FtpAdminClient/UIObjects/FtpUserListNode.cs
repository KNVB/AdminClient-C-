using AdminServerObject;
using Newtonsoft.Json.Linq;
using System.Collections.Generic;
namespace FtpAdminClient
{
    internal class FtpUserListNode : Node
    {
        string serverId;
        AddFtpUserItem addFtpUserItem;
        public FtpUserListNode(AdminServer adminServer, UIManager uiManager, string serverId) : base(adminServer, uiManager)
        {
            this.serverId = serverId;
        }
        internal override void doSelect()
        {
            List<ListItem> itemList = new List<ListItem>();
            itemList.Add(addFtpUserItem);
            uiManager.updateListView(this.colunmNameList, itemList);
        }
        internal void init(JToken token)
        {
            base.init(token);
            addFtpUserItem = new AddFtpUserItem(token["addFtpUserItem"]);
            addFtpUserItem.serverId = serverId;
        }
    }
}