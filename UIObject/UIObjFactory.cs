using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using AdminServerObject;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace UIObject
{
    public class UIObjFactory
    {
        JObject messageTextList;
        JObject labelList;
        JObject objectList;
        string json;
        public UIObjFactory()
        {
            using (StreamReader streamReader = new StreamReader("MessageText.json"))
            {
                json = streamReader.ReadToEnd();
                messageTextList = JObject.Parse(json);
            }
            using (StreamReader streamReader = new StreamReader("Label.json"))
            {
                json = streamReader.ReadToEnd();
                labelList = JObject.Parse(json);
            }
            using (StreamReader streamReader = new StreamReader("UIObject.json"))
            {
                json = streamReader.ReadToEnd();
                objectList = JObject.Parse(json);
            }
        }
        public AdminServerNode getAdminServerNode(AdminServer adminServer)
        {
            AdminServerNode adminServerNode=new AdminServerNode(getObj("adminServerNode"),adminServer);
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
