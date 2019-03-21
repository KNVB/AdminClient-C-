using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace FtpAdminClient
{
    public partial class AdminUserForm : DetailSetting
    {
        public AdminUserForm(string serverKey)
        {
            InitializeComponent();
            this.Text = "Manage Admin. user on " + serverKey;
        }
    }
}
