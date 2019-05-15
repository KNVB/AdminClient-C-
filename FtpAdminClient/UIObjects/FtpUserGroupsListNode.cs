using AdminServerObject;
using Newtonsoft.Json.Linq;
using System.Collections.Generic;
namespace FtpAdminClient
{
    internal class FtpUserGroupsListNode : Node
    {
        string serverId;
        AddFtpUserGroupItem addFtpUserGroupItem;
        internal FtpUserGroupsListNode(AdminServer adminServer, UIManager uiManager, string serverId) : base(adminServer, uiManager)
        {
            this.serverId = serverId;
        }
        internal void init(JToken token)
        {
            base.init(token);
            addFtpUserGroupItem = new AddFtpUserGroupItem(token["addFtpUserGroupItem"]);
            addFtpUserGroupItem.serverId = serverId;
        }
        internal override void doSelect()
        {
            List<ListItem> itemList = new List<ListItem>();
            itemList.Add(addFtpUserGroupItem);
            uiManager.updateListView(this.colunmNameList, itemList);
        }
    }
}