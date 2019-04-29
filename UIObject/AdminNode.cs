using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace UIObject
{
    public class AdminNode:TreeNode
    {
        public int nodeType;
        public List<string> colunmNameList { get; set; }
        public string description { get; set; }
        public override object Clone()
        {
            object result = base.Clone();
            ((AdminNode)result).colunmNameList = this.colunmNameList;
            ((AdminNode)result).description = this.description;
            ((AdminNode)result).ContextMenuStrip = new ContextMenuStrip();
            return result;
        }
        public AdminNode findChildNodeByName(string childNodeName)
        {
            AdminNode childNode = null;
            foreach (AdminNode node in this.Nodes)
            {
                if (node.Name.Equals(childNodeName))
                {
                    childNode = node;
                    break;
                }
            }
            return childNode;
        }
    }
}
