using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using UIObject;
using System.Web.Script.Serialization;

namespace ConsoleApplication1
{
    class Program
    {
        static void Main(string[] args)
        {
            JavaScriptSerializer jss = new JavaScriptSerializer();
            UIConfig uiConfig = new UIConfig();
            //  AdminServerNode a =(AdminServerNode)ObjectExtensions.Copy(uiConfig.adminServerNode);
            AdminServerNode a =(AdminServerNode)uiConfig.adminServerNode.Clone();
            Console.WriteLine(uiConfig.rootNode == null);
            Console.WriteLine(a.SelectedImageIndex);
            Console.WriteLine(a.adminServerAdministrationNode.adminUserAdministrationNode == null);
            Console.ReadLine();
        }
    }
}
