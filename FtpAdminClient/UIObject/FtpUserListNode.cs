using AdminServerObject;
using Newtonsoft.Json.Linq;
using System.Collections.Generic;
namespace FtpAdminClient
{
    internal class FtpUserListNode:Node
    {
        private JToken token;
        private AddFtpUserItem addFtpUserItem;
        internal FtpUserListNode(JToken token, AdminServer adminServer, UIManager uiManager, string serverId) : base(token, adminServer, uiManager)
        {
            this.token = token;
            addFtpUserItem= new AddFtpUserItem(token["addFtpUserItem"]); 
        }
        internal override void doSelect()
        {
            List<ListItem> itemList = new List<ListItem>();
            itemList.Add(addFtpUserItem);
            uiManager.updateListView(this.colunmNameList, itemList);
        }
    }
}