using PBE.Models;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Xml;

namespace PBE
{
    public class TreeNodeHelper
    {
        private static int GetFilterCount(string filters)
        {
            if (filters.Length < 1)
                return 0;
            XmlDocument document = new XmlDocument();
            document.LoadXml(filters);
            return document.SelectNodes("/Filter/Group").Count;
        }
        public static void DrawTree(TreeView treeView1, DataBindings bindings)
        {

            treeView1.Nodes.Clear();
            var root = new TreeNode("Bindings");
            treeView1.Nodes.Add(root);
            var rec = new TreeNode("Receive Ports");
            var send = new TreeNode("Send Ports");
            root.Nodes.Add(rec);
            root.Nodes.Add(send);
            foreach(KeyValuePair<string, Port> entry in bindings.receivePorts)
            {
                var node = new TreeNode(entry.Key);
                rec.Nodes.Add(node);
                node.Nodes.Add(new TreeNode($"Address: {entry.Value.address}"));
                node.Nodes.Add(new TreeNode($"Handler: {entry.Value.handler}"));
            }

            foreach (KeyValuePair<string, Port> entry in bindings.sendPorts)
            {
                var node = new TreeNode(entry.Key);
                send.Nodes.Add(node);
                node.Nodes.Add(new TreeNode($"Address: {entry.Value.address}"));
                node.Nodes.Add(new TreeNode($"Handler: {entry.Value.handler}"));
                int filterCount = GetFilterCount(entry.Value.filters);
                node.Nodes.Add(new TreeNode($"Filters: {filterCount}"));
            }
            
            treeView1.ExpandAll();
        }
    }
}
