using System.Collections.Generic;
using AdminServerObject;
using Newtonsoft.Json.Linq;
using System.Windows.Forms;

namespace FtpAdminClient
{
    internal abstract class Node : TreeNode
    {
        internal List<string> colunmNameList { get; set; }
        internal string description { get; set; }

        internal AdminServer adminServer;
        internal UIManager uiManager;
        internal Node(JToken token, UIManager uiManager)
        {
            this.uiManager = uiManager;
            init(token);
        }
        internal Node(JToken token, AdminServer adminServer, UIManager uiManager)
        {
            this.adminServer = adminServer;
            this.uiManager = uiManager;
            init(token);
        }
        internal virtual void doSelect()
        {

        }
        private void init(JToken token)
        {
            dynamic obj = (dynamic)token;
            this.SelectedImageIndex = obj.SelectedImageIndex;
            this.ImageIndex = obj.ImageIndex;
            this.description = obj.description;
            this.Text = obj.Text;
            this.Name = obj.Name;

            if (obj.colunmNameList != null)
                this.colunmNameList = obj.colunmNameList.ToObject<List<string>>();
            this.ContextMenuStrip = new ContextMenuStrip();
        }
    }
}