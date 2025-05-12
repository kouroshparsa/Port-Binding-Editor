using PBE.Models;
using System;
using System.Collections.Generic;
using System.Xml;

namespace PBE
{
    public class DataBindings
    {
        public Dictionary<string, Port> receivePorts;
        public Dictionary<string, Port> sendPorts;
        public string export_template = null;
        public Dictionary<string, Port> allPorts {
            get
            {
                var all = new Dictionary<string, Port>(this.receivePorts);
                foreach (var kvp in sendPorts)
                {
                    all[kvp.Key] = kvp.Value;
                }
                return all;
            }
        }

        public string AppName { get; internal set; }


        public DataBindings(XmlDocument doc)
        {
            this.receivePorts = new Dictionary<string, Port>();
            this.sendPorts = new Dictionary<string, Port>();
            XmlNode node = doc.SelectSingleNode("/BindingInfo/SendPortCollection/SendPort[1]/ApplicationName");
            if(node == null)
            {
                node = doc.SelectSingleNode("/BindingInfo/ReceivePortCollection/ReceivePort[1]/ApplicationName");
            }
            if (node == null)
            {
                this.AppName = "";
            }
            else
            {
                this.AppName = node.InnerText;
            }
        }

        public Port GetPort(string name)
        {
            if (receivePorts.ContainsKey(name))
                return receivePorts[name];
            else if (sendPorts.ContainsKey(name))
                return sendPorts[name];
            return null;
        }

        public Dictionary<string, Port>GetPorts(string name)
        {
            if (receivePorts.ContainsKey(name))
            {
                return receivePorts;
            }
            else if (sendPorts.ContainsKey(name))
            {
                return sendPorts;
            }
            return null;
        }

    }
}
