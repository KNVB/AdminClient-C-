using System.Collections.Generic;
using AdminServerObject;
using System.Windows.Forms;
using Newtonsoft.Json.Linq;

namespace FtpAdminClient
{
    public class Node : TreeNode
    {
        internal AdminServer adminServer=null;
        internal ImageList imageList;
        internal int nodeType=-1;
        internal List<string> colunmNameList { get; set; }
        internal string description { get; set; }
        internal dynamic obj= null;
        public Node(JToken token,AdminServer adminServer,ImageList imageList)
        {
            this.adminServer = adminServer;
            this.imageList = imageList;
            init(token);
        }
        public Node(JToken token)
        {
            init(token);
        }
        private void init(JToken token)
        {
            obj = (dynamic)token;
            this.SelectedImageIndex = obj.SelectedImageIndex;
            this.ImageIndex = obj.ImageIndex;
            this.description = obj.description;
            
            this.Text = obj.Text;
            this.Name = obj.Name;

            if (obj.colunmNameList!=null)
                this.colunmNameList = obj.colunmNameList.ToObject<List<string>>();
            this.ContextMenuStrip = new ContextMenuStrip();
        }
        public void initListView(ListView listView)
        {
            ColumnHeader header;
            listView.Items.Clear();
            listView.Columns.Clear();
            foreach (string headerString in this.colunmNameList)
            {
                // MessageBox.Show(headerString);
                header = new ColumnHeader();
                header.Text = headerString;
                listView.Columns.Add(header);
            }
        }
     }
}
