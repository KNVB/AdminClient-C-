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
        JObject objectList;
        public UIObjFactory()
        {
            using (StreamReader streamReader = new StreamReader("UIConfigParameter.json"))
            {
                string json = streamReader.ReadToEnd();
                objectList = JObject.Parse(json);
            }
        }
        public AdminServerNode getAdminServerNode(AdminServer adminServer)
        {
            AdminServerNode adminServerNode=new AdminServerNode(getObj("adminServerNode"),adminServer);
            return adminServerNode;
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
