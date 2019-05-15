using AdminServerObject;
using Newtonsoft.Json.Linq;
using System.Collections.Generic;
namespace FtpAdminClient
{
    internal class FtpUserGroupsListNode:Node
    {
        private JToken token;
        private AddFtpUserGroupItem addFtpUserGroupItem;
        internal FtpUserGroupsListNode(JToken token, AdminServer adminServer, UIManager uiManager, string serverId) : base(token, adminServer, uiManager)
        {
            this.token = token;
            addFtpUserGroupItem=new AddFtpUserGroupItem(token["addFtpUserGroupItem"]);
        }
        internal override void doSelect()
        {
            List<ListItem> itemList = new List<ListItem>();
            itemList.Add(addFtpUserGroupItem);
            uiManager.updateListView(this.colunmNameList, itemList);
        }
    }
}
