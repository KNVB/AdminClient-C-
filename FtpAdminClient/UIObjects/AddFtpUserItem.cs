﻿using AdminServerObject;
using Newtonsoft.Json.Linq;
namespace FtpAdminClient
{
    internal class AddFtpUserItem:ListItem
    {
        internal AdminServer adminServer;
        internal string serverId;
        internal AddFtpUserItem(JToken token) : base(token)
        {

        }
        internal override void doClick(UIManager uiManager)
        {

        }
    }
}