using AdminServerObject;
using Newtonsoft.Json.Linq;
using System;
using System.Windows.Forms;
namespace FtpAdminClient
{
    internal class AdminUserAdministrationNode : Node
    {
        internal AdminUserAdministrationNode(JToken token,AdminServer adminServer, UIManager uiManager) : base(token, adminServer, uiManager)
        {
        }
        internal override void doSelect()
        {
            MessageBox.Show(Convert.ToString(adminServer == null));
        }
    }
}