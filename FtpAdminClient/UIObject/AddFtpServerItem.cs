using AdminServerObject;
using Newtonsoft.Json.Linq;
using System;
using System.Windows.Forms;
namespace FtpAdminClient
{
    internal class AddFtpServerItem : ListItem
    {
        internal AdminServer adminServer;
        internal FtpServerListNode ftpServerListNode;
        internal AddFtpServerItem(JToken token) : base(token)
        {

        }      
        internal override void doClick(UIManager uiManager)
        {
            AddFtpForm addFtpForm = new AddFtpForm(adminServer, uiManager);
            DialogResult dialogresult = addFtpForm.ShowDialog();
            
            if (dialogresult.Equals(DialogResult.OK))
            {
                ftpServerListNode.updateFtpServerList();
                uiManager.refreshFtpServerListNode(ftpServerListNode);
            }            
        }
    }
}
