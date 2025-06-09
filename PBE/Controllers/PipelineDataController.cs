using PBE.Models;
using PBE.Utils;
using System.Collections.Generic;
using System.Text;
using System.Xml;

namespace PBE.Controllers
{
    public class PipelineDataController
    {
        public List<PropertyBag> properties = new List<PropertyBag>();
        public string promotions = "";
        private Port port = null;
        private bool isReceivePipelineData = false;

        public PipelineDataController(Port port, bool isReceivePipelineData)
        {
            this.port = port;
            this.isReceivePipelineData = isReceivePipelineData;
            if (isReceivePipelineData)
                SetData(port.receivePipelineData, port.receivePipelineName);
            else
                SetData(port.sendPipelineData, port.sendPipelineName);

        }
        private void SetData(string data, string pipelineName)
        {
            properties.Clear();
            if (string.IsNullOrEmpty(data))
                return;

            XmlDocument doc = new XmlDocument();
            doc.LoadXml(data);
            foreach (XmlNode node in doc.SelectNodes("//Properties"))
            {
                ReadInnerXmlContent(node.ChildNodes, pipelineName);
            }
        }

        private void ReadInnerXmlContent(XmlNodeList nodes, string pipelineName)
        {
            foreach (XmlNode node in nodes)
            {
                if (node.InnerText.Trim().StartsWith("<")) // <Promotions>
                {
                    string xml = XmlHelper.FormatXml(node.InnerText);
                    promotions  = xml;
                }
                else
                {
                    if (node.HasChildNodes && node.InnerXml.Trim().StartsWith("<"))
                    {
                        foreach (XmlNode childNode in node.ChildNodes)
                        {
                            string warnings = GetWarnings(childNode, pipelineName);
                            properties.Add(new PropertyBag(childNode.Name, childNode.InnerText, warnings));
                        }
                    }
                    else
                    {
                        string warnings = GetWarnings(node, pipelineName);
                        properties.Add(new PropertyBag(node.Name, node.InnerText, warnings));
                    }
                }

            }
        }

        private string GetWarnings(XmlNode node, string pipelineName)
        {
            Dictionary<string, string> expectedValues = new Dictionary<string, string>();
            expectedValues["AssociateInterfaceNameForAck"] = port.name;
            expectedValues["FileLog_SaveDaily"] = "-1";
            expectedValues["TrailingDelimiterAllowed"] = "-1";
            expectedValues["FailLog_SaveDaily"] = "-1";
            expectedValues["ExceptionSource"] = port.applicationName;
            

            if (expectedValues.ContainsKey(node.Name) &&
                !node.InnerText.ToLower().Equals(expectedValues[node.Name].ToLower()))
            {
                return "⚠ The expected value is " + expectedValues[node.Name];
            }

            // For send port CorolarHL7v2XAckReceivePipeline, ConsumeMessage should be true ("1")
            // and for receive port, CorolarHL7v2XAckSendPipeline ConsumeMessage should be false ("0")
            // it seems contradictory that for one false is 0 and for the other true is 0 but that's what I observed
            if (node.Name=="ConsumeMessage" && pipelineName != null)
            {
                if (pipelineName.EndsWith("CorolarHL7v2XAckReceivePipeline") && !node.InnerText.ToLower().Equals("1")){
                    return "⚠ The expected value is 1 (true)";

                }else if (pipelineName.EndsWith("CorolarHL7v2XAckSendPipeline") && !node.InnerText.ToLower().Equals("0"))
                {
                    return "⚠ The expected value is 0 (false)";
                }
            }
            return "✓";
        }

        public void UpdatePipelineData(Dictionary<string, string> data, string promotions)
        {
            XmlNode node = port.receivePipelineDataNode;
            if (!isReceivePipelineData)
            {
                node = port.sendPipelineDataNode;
            }

            string res = UpdateInnerXmlContent(node.ChildNodes, data, promotions); // escaped xml
            res = XmlHelper.ConvertEscapedXmlToUnescaped(res);
            node.InnerText = res;
            if (isReceivePipelineData)
            {
                port.receivePipelineData = res;
            }
            else
            {
                port.sendPipelineData = res;
            }

        }

        private static string UpdateInnerXmlContent(XmlNodeList nodes, Dictionary<string, string> data, string promotions)
        {
            StringBuilder sb = new StringBuilder();
            foreach (XmlNode node in nodes)
            {
                if (node.InnerText.Trim().StartsWith("<Promotions>"))
                {
                    node.InnerText = promotions.Replace("\r\n", "");

                }
                else if (node.InnerText.Trim().StartsWith("<"))
                {
                    XmlDocument doc = new XmlDocument();
                    doc.LoadXml(node.InnerText);
                    string res = UpdateInnerXmlContent(doc.ChildNodes, data, promotions);
                    node.InnerText = res;
                }
                else
                {
                    if (node.HasChildNodes && node.InnerXml.Trim().StartsWith("<"))
                    {
                        foreach (XmlNode childNode in node.ChildNodes)
                        {
                            if (data.ContainsKey(childNode.Name))
                            {
                                childNode.InnerText = data[childNode.Name];
                            }
                            else if (childNode.ChildNodes.Count > 0)
                            {
                                string inner = UpdateInnerXmlContent(childNode.ChildNodes, data, promotions);
                            }
                        }
                    }
                    else
                    {
                        if (data.ContainsKey(node.Name))
                        {
                            node.InnerText = data[node.Name];
                        }
                    }
                }
                sb.Append(node.OuterXml);
            }


            return sb.ToString();
        }
    }
}
