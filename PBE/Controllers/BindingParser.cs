using PBE.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text.RegularExpressions;
using System.Xml;

namespace PBE.Controllers
{
    public class BindingParser
    {

        private static void LoadReceivePorts(XmlDocument document, DataBindings bindings)
        {
            var nodes = document.SelectNodes("/BindingInfo/ReceivePortCollection/ReceivePort");
            int ind = 0;
            foreach (XmlNode node in nodes)
            {
                node.Attributes.RemoveNamedItem("xmlns:xsi");
                string name = node.Attributes["Name"].Value;
                bindings.receivePorts.Add(name, new ReceivePort(name, node, node.OuterXml, ind));
                ind += 1;
            }
        }

        private static void LoadSendPorts(XmlDocument document, DataBindings bindings)
        {
            var nodes = document.SelectNodes("/BindingInfo/SendPortCollection/SendPort");
            int ind = 0;
            foreach (XmlNode node in nodes)
            {
                node.Attributes.RemoveNamedItem("xmlns:xsi");
                string name = node.Attributes["Name"].Value;
                bindings.sendPorts.Add(name, new SendPort(name, node, node.OuterXml, ind));
                ind += 1;
            }
        }
        public static DataBindings Parse(string path)
        {
            var doc = new XmlDocument();
            doc.Load(path);
            DataBindings bindings = new DataBindings(doc);
            LoadReceivePorts(doc, bindings);
            LoadSendPorts(doc, bindings);
            SetGuids(path, bindings);
            return bindings;
        }

        private static void SetGuids(string path, DataBindings bindings)
        {
            string text = File.ReadAllText(path);
            var matches = Regex.Matches(text, @"<ReceivePort Name=""(.*?)"">.*?</ReceivePort>", RegexOptions.Singleline);
            List<string[]> replacements = new List<string[]>();
            foreach (Match match in matches)
            {
                var nameMatch = Regex.Match(match.Value, @"<ReceivePort\s+Name=""(.*?)""", RegexOptions.IgnoreCase);
                string portName = nameMatch.Groups[1].Value;
                string g = "{{" + Guid.NewGuid().ToString() + "}}";
                if (bindings.receivePorts.ContainsKey(portName))// the matched regex could be a comment
                {
                    bindings.receivePorts[portName].guid = g;
                    replacements.Add(new string[] { match.Value, g });
                    System.Diagnostics.Debug.WriteLine(portName, g);
                }
            }

            foreach (string[] rep in replacements)
            {
                text = text.Replace(rep[0], rep[1]);
            }

            matches = Regex.Matches(text, @"<SendPort Name=""(.*?)"">.*?</SendPort>", RegexOptions.Singleline);
            foreach (Match match in matches)
            {
                var nameMatch = Regex.Match(match.Value, @"<SendPort\s+Name=""(.*?)""", RegexOptions.IgnoreCase);
                string portName = nameMatch.Groups[1].Value;
                string g = "{{" + Guid.NewGuid().ToString() + "}}";
                if (bindings.sendPorts.ContainsKey(portName))// the matched regex could be a comment
                {
                    bindings.sendPorts[portName].guid = g;
                    replacements.Add(new string[] { match.Value, g });
                    System.Diagnostics.Debug.WriteLine(portName, g);
                }
            }

            foreach (string[] rep in replacements)
            {
                text = text.Replace(rep[0], rep[1]);
            }
            bindings.export_template = text;
        }
        public static HashSet<string> ExtractVariables(string portBindingMasterPath)
        {
            string content;
            using (StreamReader reader = new StreamReader(portBindingMasterPath))
            {
                content = reader.ReadToEnd();
            }
            
            HashSet<string> results = new HashSet<string>();
            Regex regex = new Regex(@"\$\{(.*?)\}");
            MatchCollection matches = regex.Matches(content);

            foreach (Match match in matches)
            {
                results.Add(match.Groups[1].Value);
            }

            return results;
        }
    }
}