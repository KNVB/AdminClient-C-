using AdminServerObject;
using Newtonsoft.Json.Linq;
using System.Windows.Forms;

namespace FtpAdminClient
{
    internal class FtpServerNetworkPropertiesNode : Node
    {
        string serverId;
        internal FtpServerNetworkPropertiesNode(JToken token, AdminServer adminServer, UIManager uiManager,string serverId) : base(token, adminServer, uiManager)
        {
            this.serverId= serverId;
        }
        internal override void doSelect()
        {
            EditFtpServerNetworkPropertiesForm efsf = new EditFtpServerNetworkPropertiesForm(adminServer, uiManager,serverId);
            DialogResult dialogresult = efsf.ShowDialog();
        }
    }
}
