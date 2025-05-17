using System.Xml;

namespace PBE.Models
{
    public class Port
    {
        public string outerXml;
        public XmlNode portNode;
        public string applicationName;
        public virtual string name { get; set; }
        public virtual string address { get; set; }
        public virtual string handler { get; set; }
        public virtual string filters { get; set; }
        public virtual string transportTypeData { get; set; }
        public virtual string receivePipelineData { get; set; }
        public virtual string sendPipelineData { get; set; }

        public virtual string receivePipelineName { get; set; }
        public virtual string sendPipelineName { get; set; }

        public string guid = null;

        public virtual XmlNode transportTypeDataNode { get; }

        public XmlNode receivePipelineDataNode { get; set; }
        public XmlNode sendPipelineDataNode { get; set; }
    }
}
