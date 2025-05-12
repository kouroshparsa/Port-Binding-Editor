using System.Xml;

namespace PBE.Models
{
    public class Port
    {
        public string outerXml;
        public XmlNode portNode;
        public virtual string name { get; set; }
        public virtual string address { get; set; }
        public virtual string handler { get; set; }
        public virtual string filters { get; set; }
        public virtual string transportTypeData { get; set; }
        public virtual string receivePipelineData { get; set; }
        public virtual string sendPipelineData { get; set; }

        public string guid = null;

        public virtual XmlNode transportTypeDataNode { get; }


    }
}
