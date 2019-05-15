using Newtonsoft.Json.Linq;
using System.Windows.Forms;

namespace FtpAdminClient
{
    internal class ListItem : ListViewItem
    {
        internal Node relatedNode { get; set; } = null;
        internal ListItem()
        {

        }
        internal ListItem(JToken token)
        {
            dynamic obj = (dynamic)token;
            this.ImageIndex = obj.ImageIndex;
            this.Text = obj.Text;
            this.Name = obj.Name;
        }

        internal virtual void doClick(UIManager uiManager)
        {
            uiManager.selectNode(relatedNode);
        }
    }
}
