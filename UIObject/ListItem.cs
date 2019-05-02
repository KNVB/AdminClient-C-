using System;
using System.Windows.Forms;
using Newtonsoft.Json.Linq;

namespace UIObject
{
    public class ListItem : ListViewItem
    {
        public Node relatedNode { get; set; } = null;
        public int ListItemType = -1;
        internal dynamic obj = null;
        public ListItem()
        {

        }
        public ListItem(JToken token)
        {
            obj = (dynamic)token;
            this.ImageIndex = obj.ImageIndex;
            this.Text = obj.Text;
            this.Name = obj.Name;
        }
    }
}
