using System.Collections.Generic;
using AdminServerObject;
using System.Windows.Forms;
using Newtonsoft.Json.Linq;

namespace UIObject
{
    public class Node : TreeNode
    {
        public AdminServer adminServer=null;
        public int nodeType=-1;
        internal List<string> colunmNameList { get; set; }
        internal string description { get; set; }
        internal dynamic obj= null;
        public Node(JToken token,AdminServer adminServer)
        {
            this.adminServer = adminServer;
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
        /*
        public Node findChildNodeByName(string childNodeName)
        {
            Node childNode = null;
            foreach (Node node in this.Nodes)
            {
                if (node.Name.Equals(childNodeName))
                {
                    childNode = node;
                    break;
                }
            }
            return childNode;
        }*/

    }
}
