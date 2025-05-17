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
        public string export_template = @"<?xml version=""1.0"" encoding=""utf-8""?>
<BindingInfo xmlns:xsi=""http://www.w3.org/2001/XMLSchema-instance"" xmlns:xsd=""http://www.w3.org/2001/XMLSchema"" Assembly=""Microsoft.BizTalk.Deployment, Version=3.0.1.0, Culture=neutral"" Version=""3.5.1.0"" BindingStatus=""NoBindings"" BoundEndpoints=""0"" TotalEndpoints=""0"">
  <ModuleRefCollection>
  </ModuleRefCollection>
  <SendPortCollection>
  </SendPortCollection>
  <DistributionListCollection />
  <ReceivePortCollection>
  </ReceivePortCollection>
<PartyCollection xsi:nil=""true"" />
</BindingInfo>";
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
        
        public DataBindings()
        {
            this.receivePorts = new Dictionary<string, Port>();
            this.sendPorts = new Dictionary<string, Port>();
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
