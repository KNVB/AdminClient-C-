using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.IO;
using AdminServerObject;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace FtpAdminClient
{
    public class UIObjFactory
    {
        JObject messageTextList;
        JObject labelList;
        JObject objectList;
        string json;
        public UIObjFactory()
        {
            using (StreamReader streamReader = new StreamReader(@"json\MessageText.json"))
            {
                json = streamReader.ReadToEnd();
                messageTextList = JObject.Parse(json);
            }
            using (StreamReader streamReader = new StreamReader(@"json\Label.json"))
            {
                json = streamReader.ReadToEnd();
                labelList = JObject.Parse(json);
            }
            using (StreamReader streamReader = new StreamReader(@"json\UIObject.json"))
            {
                json = streamReader.ReadToEnd();
                objectList = JObject.Parse(json);
            }
        }
        public AdminServerNode getAdminServerNode(AdminServer adminServer,ImageList imageList)
        {
            AdminServerNode adminServerNode=new AdminServerNode(getObj("adminServerNode"),adminServer,imageList);
            return adminServerNode;
        }
        public string getMessageText(string key)
        {
            return (string)messageTextList[key];
        }
        public string getLabel(string key)
        {
            return (string)labelList[key];
        }
        public RootNode getRootNode()
        {
            RootNode rootNode = new RootNode(getObj("RootNode"));
            return rootNode;
        }
        public JToken getObj(string key)
        {
            return objectList[key];
        }
    }
}
