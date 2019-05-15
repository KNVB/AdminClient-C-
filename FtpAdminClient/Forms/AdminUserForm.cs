using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using AdminServerObject;
using System.Windows.Forms;

namespace FtpAdminClient
{
    public partial class AdminUserForm : DetailSetting
    {
        internal AdminUserForm(AdminServer  adminServer,UIManager uiManager)
        {
            InitializeComponent();
            this.Text +=uiManager.getAdminUserFormLabel()+adminServer.serverName+":"+adminServer.portNo;
        }
    }
}
