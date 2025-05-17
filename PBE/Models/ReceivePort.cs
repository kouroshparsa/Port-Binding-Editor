using System.Xml;

namespace PBE.Models
{
    public class ReceivePort: Port
    {
        private string _name;
        private string _address;
        private string _handler;
        private string _filters;
        private string _transportTypeData;
        private string _receivePipelineData;
        private string _sendPipelineData;
        private string _receivePipelineName = null;
        private string _sendPipelineName = null;
        public ReceivePort(string xml)
        {
            XmlDocument doc = new XmlDocument();
            doc.LoadXml(xml);
            XmlElement root = doc.DocumentElement;
            string name = root.Attributes["Name"].Value;
            CreatePort(name, root, xml, 0);
        }

        public ReceivePort(string name, XmlNode node, string outerXml, int ind)
        {
            CreatePort(name, node, outerXml, ind);
        }

        private void CreatePort(string name, XmlNode node, string outerXml, int ind)
        {
            this.outerXml = outerXml; // This must be set first
            this.applicationName = node.SelectSingleNode("./ApplicationName").InnerText;
            portNode = node;
            _name = name;
            _address = node.SelectSingleNode("./ReceiveLocations/ReceiveLocation/Address").InnerText;
            _handler = node.SelectSingleNode("./ReceiveLocations/ReceiveLocation/ReceiveHandler").Attributes["Name"].Value;
            var fnode = node.SelectSingleNode("./Filter");
            if (fnode != null)
            {
                _filters = fnode.InnerText;
            }
            _transportTypeData = this.transportTypeDataNode.InnerText;

            this.receivePipelineDataNode = node.SelectSingleNode("./ReceiveLocations/ReceiveLocation/ReceivePipelineData");
            if(this.receivePipelineDataNode != null)
                _receivePipelineData = this.receivePipelineDataNode.InnerText;

            this.sendPipelineDataNode = node.SelectSingleNode("./ReceiveLocations/ReceiveLocation/SendPipelineData");
            if (this.sendPipelineDataNode != null)
                _sendPipelineData = this.sendPipelineDataNode.InnerText;

            var n = node.SelectSingleNode("./ReceiveLocations/ReceiveLocation/ReceivePipeline");
            if (n != null && n.Attributes["Name"] != null)
                _receivePipelineName = n.Attributes["Name"].Value.ToString();
            n = node.SelectSingleNode("./ReceiveLocations/ReceiveLocation/SendPipeline");
            if (n != null && n.Attributes["Name"] != null)
                _sendPipelineName = n.Attributes["Name"].Value.ToString();
        }
        
        public override XmlNode transportTypeDataNode
        {
            get
            {
                return portNode.SelectSingleNode("./ReceiveLocations/ReceiveLocation/ReceiveLocationTransportTypeData");
            }
        }

        public override string name
        {
            get { return _name; }
            set {
                if(_name != null && portNode != null)
                {
                    portNode.Attributes["Name"].Value = value;

                    XmlNode rl = portNode.SelectSingleNode("./ReceiveLocations/ReceiveLocation");
                    if (!value.StartsWith("RP_"))
                        value = "RP_" + value;
                    rl.Attributes["Name"].Value = value.Replace("RP_", "RL_");
                    outerXml = portNode.OuterXml;
                }
                _name = value;

            }
        }

        public override string address
        {
            get { return _address; }
            set
            {
                if (_address != null && portNode != null)
                {
                    XmlNode address = portNode.SelectSingleNode("./ReceiveLocations/ReceiveLocation/Address");
                    address.InnerText = value;
                    outerXml = portNode.OuterXml;
                }
                _address = value;

            }
        }

        public override string handler
        {
            get { return _handler; }
            set
            {
                if (_handler != null && portNode != null)
                {
                    XmlNode handler = portNode.SelectSingleNode("./ReceiveLocations/ReceiveLocation/ReceiveHandler");
                    handler.Attributes["Name"].Value = value;
                    base.outerXml = portNode.OuterXml;
                }
                _handler = value;

            }
        }

        public override string filters
        {
            get { return _filters; }
            set
            {
                if (_filters != null && portNode != null)
                {
                    XmlNode filters = portNode.SelectSingleNode("./Filter");
                    if (filters != null)
                    {
                        filters.InnerText = value;
                        outerXml = portNode.OuterXml;
                    }
                }
                _filters = value;

            }
        }

        public override string transportTypeData
        {
            get { return _transportTypeData; }
            set
            {
                if (_transportTypeData != null && portNode != null)
                {
                    XmlNode transportTypeData = portNode.SelectSingleNode("./ReceiveLocations/ReceiveLocation/ReceiveLocationTransportTypeData");
                    transportTypeData.InnerText = value;
                    outerXml = portNode.OuterXml;
                }
                _transportTypeData = value;

            }
        }

        public override string receivePipelineData
        {
            get { return _receivePipelineData; }
            set
            {
                if (_receivePipelineData != null && portNode != null)
                {
                    XmlNode pipelineData = portNode.SelectSingleNode("./ReceiveLocations/ReceiveLocation/ReceivePipelineData");
                    if (pipelineData != null)
                    {
                        pipelineData.InnerText = value;
                        outerXml = portNode.OuterXml;
                    }
                }
                _receivePipelineData = value;

            }
        }

        public override string sendPipelineData
        {
            get { return _sendPipelineData; }
            set
            {
                if (_sendPipelineData != null && portNode != null)
                {
                    XmlNode pipelineData = portNode.SelectSingleNode("./ReceiveLocations/ReceiveLocation/SendPipelineData");
                    if (pipelineData != null)
                    {
                        pipelineData.InnerText = value;
                        outerXml = portNode.OuterXml;
                    }
                }
                _sendPipelineData = value;

            }
        }

        public override string receivePipelineName
        {
            get { return _receivePipelineName; }
            set { _receivePipelineName = value; }
        }

        public override string sendPipelineName
        {
            get { return _sendPipelineName; }
            set { _sendPipelineName = value; }
        }


    }
}
