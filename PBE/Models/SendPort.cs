using System.Xml;

namespace PBE.Models
{
    public class SendPort: Port
    {
        private string _name;
        private string _address;
        private string _handler;
        private string _filters;
        private string _transportTypeData;
        private string _receivePipelineData;
        private string _sendPipelineData;

        public SendPort(string xml)
        {
            XmlDocument doc = new XmlDocument();
            doc.LoadXml(xml);
            XmlElement root = doc.DocumentElement;
            string name = root.Attributes["Name"].Value;
            CreatePort(name, root, xml, 0);
        }

        public SendPort(string name, XmlNode node, string outerXml, int ind)
        {
            CreatePort(name, node, outerXml, ind);
        }
        private void CreatePort(string name, XmlNode node, string outerXml, int ind)
        {
            this.outerXml = outerXml; // This must be set first
            portNode = node;
            _name = name;
            _address = node.SelectSingleNode("./PrimaryTransport/Address").InnerText;
            _handler = node.SelectSingleNode("./PrimaryTransport/SendHandler").Attributes["Name"].Value;
            var fnode = node.SelectSingleNode("./Filter");
            if (fnode != null)
            {
                _filters = fnode.InnerText;
            }
            _transportTypeData = this.transportTypeDataNode.InnerText;
            var n = node.SelectSingleNode("./ReceivePipelineData");
            if(n!=null)
                _receivePipelineData = n.InnerText;
            n = node.SelectSingleNode("./SendPipelineData");
            if (n != null)
                _sendPipelineData = n.InnerText;
        }

        public override XmlNode transportTypeDataNode
        {
            get
            {
                return portNode.SelectSingleNode("./PrimaryTransport/TransportTypeData");
            }
        }
        public override string name
        {
            get { return _name; }
            set
            {
                if (_name != null && portNode != null)
                {
                    portNode.Attributes["Name"].Value = value;
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
                    XmlNode address = portNode.SelectSingleNode("./PrimaryTransport/Address");
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
                    XmlNode handler = portNode.SelectSingleNode("./PrimaryTransport/SendHandler");
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
                if (name != null && portNode != null)
                {
                    XmlNode filters = portNode.SelectSingleNode("./Filter");
                    if (filters != null) {
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
                    XmlNode transportTypeData = portNode.SelectSingleNode("./PrimaryTransport/TransportTypeData");
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
                    XmlNode pipelineData = portNode.SelectSingleNode("./ReceivePipelineData");
                    pipelineData.InnerText = value;
                    outerXml = portNode.OuterXml;
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
                    XmlNode pipelineData = portNode.SelectSingleNode("./SendPipelineData");
                    pipelineData.InnerText = value;
                    outerXml = portNode.OuterXml;
                }
                _sendPipelineData = value;

            }
        }

    }
}
