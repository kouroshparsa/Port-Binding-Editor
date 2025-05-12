using PBE.Models;
using PBE.Utils;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Text.RegularExpressions;
using System.Xml;
using System.Xml.Linq;

namespace PBE.Controllers
{
    public class BindingExporter
    {
        private static void RemoveXmlnsXsiAttributes(XmlNode node)
        {
            XmlAttribute xsiAttr = node.Attributes["xmlns:xsi"]; ;
            if (xsiAttr != null)
            {
                node.Attributes.Remove(xsiAttr);
            }
        }
        
        private static string RemoveNamespace(string xml)
        {
            string pattern = " xmlns:xsi=\".*?\" ";
            List<Match> matches = new List<Match>();
            foreach (Match match in Regex.Matches(xml, pattern))
            {
                matches.Add(match);
            }

            for(int i=matches.Count-1; i>=0; i--)
            {
                Match match = matches[i];
                xml = xml.Substring(0, match.Index) + xml.Substring(match.Index + match.Length);
            }
            return xml;
        }

        public static void Export(DataBindings bindings, string path)
        {
            string template = bindings.export_template;
            StringBuilder sb = new StringBuilder();
            foreach (KeyValuePair<string, Port> entry in bindings.receivePorts)
            {
                ReceivePort rp = (ReceivePort)entry.Value;
                if(rp.guid != null)
                {
                    string xml = XmlHelper.FormatXml(rp.outerXml);
                    xml = xml.Replace(" xmlns:xsi=\"http://www.w3.org/2001/XMLSchema-instance\" />",
                        " />");
                    template = template.Replace(rp.guid, xml);
                }else { // new port
                    sb.Append(rp.outerXml);
                }
            }

            if(sb.Length > 0)
            {
                int ind = template.IndexOf("</ReceivePortCollection>");
                template = template.Insert(ind, XmlHelper.FormatXml(sb));
            }

            sb.Clear();
            
            foreach (KeyValuePair<string, Port> entry in bindings.sendPorts)
            {
                SendPort sp = (SendPort)entry.Value;
                if (sp.guid != null)
                {
                    string xml = XmlHelper.FormatXml(sp.outerXml);
                    xml = xml.Replace(" xmlns:xsi=\"http://www.w3.org/2001/XMLSchema-instance\" />",
                        " />");
                    template = template.Replace(sp.guid,xml);
                }
                else
                { // new port
                    sb.Append(sp.outerXml);
                }
            }

            if (sb.Length > 0)
            {
                int ind = template.IndexOf("</SendPortCollection>");
                template = template.Insert(ind, XmlHelper.FormatXml(sb));
            }

            using (StreamWriter outputFile = new StreamWriter(path))
            {
                outputFile.WriteLine(template);
            }
        }
    }
}
