using PBE.Models;
using PBE.Utils;
using System.Collections.Generic;
using System.Text;
using System.Xml;
using System.Linq;

namespace PBE.Controllers
{
    public class TransportTypeController
    {
        public List<PropertyBag> properties = new List<PropertyBag>();
        private string applicationName;
        private Port port = null;

        public TransportTypeController(Port port, string applicationName)
        {
            this.port = port;
            this.applicationName = applicationName;
            SetData(port.transportTypeData);
            
        }
        private void SetData(string transportTypeData)
        {
            properties.Clear();
            if (transportTypeData == null)
                return;

            XmlDocument doc = new XmlDocument();
            doc.LoadXml(transportTypeData);
            var customProp = doc.SelectSingleNode("//CustomProps");
            ReadInnerXmlContent(customProp.ChildNodes);
        }

        private void ReadInnerXmlContent(XmlNodeList nodes)
        {
            foreach (XmlNode node in nodes)
            {
                if (node.InnerText.Trim().StartsWith("<"))
                {
                    XmlDocument doc = new XmlDocument();
                    doc.LoadXml(node.InnerText);
                    ReadInnerXmlContent(doc.ChildNodes);
                }
                else
                {
                    if (node.HasChildNodes && node.InnerXml.Trim().StartsWith("<"))
                    {
                        foreach (XmlNode childNode in node.ChildNodes)
                        {
                            string warnings = GetWarnings(childNode);
                            properties.Add(new PropertyBag(childNode.Name, childNode.InnerText, warnings));
                        }
                    }
                    else
                    {
                        string warnings = GetWarnings(node);
                        properties.Add(new PropertyBag(node.Name, node.InnerText, warnings));
                    }
                }

            }
        }

        internal void UpdateTransportType(Dictionary<string, string> data)
        {
            XmlNode trTypeDataNode = port.transportTypeDataNode;
            // Step 1: Decode the InnerText into real XML
            string escapedXml = trTypeDataNode.InnerText;
            XmlDocument embeddedDoc = new XmlDocument();
            embeddedDoc.LoadXml(escapedXml); // now we have real nodes

            // Step 2: Update values based on dictionary
            UpdateInnerXmlContent(embeddedDoc.DocumentElement, data);

            // Step 3: Save updated XML back to string
            string updatedXml = embeddedDoc.OuterXml;

            // Step 4: Escape again and store it back
            trTypeDataNode.InnerText = updatedXml;

            // Save to object too
            port.transportTypeData = updatedXml;
        }

        private string GetWarnings(XmlNode node)
        {
            Dictionary<string, string> expectedValues = new Dictionary<string, string>();
            expectedValues["connectionName"] = port.name;
            expectedValues["comments"] = port.name;

            string[] parts = port.address.Split(':');
            if (parts.Length == 2)
            {
                expectedValues["serverName"] = parts[0];
                expectedValues["port"] = parts[1];
                expectedValues["uri"] = port.address;
            }

            expectedValues["queue"] = port.address;
            expectedValues["batchSize"] = "1";
            expectedValues["transactional"] = "true";
            expectedValues["serialProcessing"] = "true";
            expectedValues["onFailure"] = "suspendResumable";

            if (port.GetType() == typeof(ReceivePort))
            {
                expectedValues["timeout"] = "0";

            }
            else// SendPort
            {
                expectedValues["acknowledgeType"] = "None";
                expectedValues["timeOut"] = "7";
                expectedValues["priority"] = "Normal";
                expectedValues["recoverable"] = "true";
                expectedValues["encryptionAlgorithm"] = "None";
                expectedValues["useAuthentication"] = "false";
                expectedValues["segmentationSupport"] = "false";
                expectedValues["transactional"] = "true";
                expectedValues["useJournalQueue"] = "false";
                expectedValues["useDeadLetterQueue"] = "false";
                expectedValues["ackTypeEnumsValue"] = "0";
                expectedValues["timeOutUnits"] = "Days";
                expectedValues["bodyType"] = "8209";
            }

            expectedValues["persistentConnection"] = "true";
            expectedValues["persistentConnectionRecSide"] = "true";
            expectedValues["startBlockDelimiter"] = "0b";
            expectedValues["endBlockDelimiter"] = "1c";
            expectedValues["carriageReturn"] = "0d";
            expectedValues["orderedDelivery"] = "TRUE";
            expectedValues["useMLLPTransAck"] = "false";
            expectedValues["useDerectSynchronousHL7Ack"] = "false";
            expectedValues["noSB"] = "false";

            if (expectedValues.ContainsKey(node.Name) &&
                !node.InnerText.ToLower().Equals(expectedValues[node.Name].ToLower()))
            {
                return "⚠ The expected value is " + expectedValues[node.Name];
            }

            if(node.Name == "maximumMessageSize")
            {
                if(int.Parse(node.InnerText) < 1024)
                {
                    return "⚠ The expected value is >= 1024";
                }
            }
            return "✓";
        }

        private void UpdateTransportTypeData(Dictionary<string, string> data)
        {
            var trTypeDataNode = port.portNode.SelectSingleNode("//ReceiveLocationTransportTypeData");
            // Step 1: Decode the InnerText into real XML
            string escapedXml = trTypeDataNode.InnerText;
            XmlDocument embeddedDoc = new XmlDocument();
            embeddedDoc.LoadXml(escapedXml); // now we have real nodes

            // Step 2: Update values based on dictionary
            UpdateInnerXmlContent(embeddedDoc.DocumentElement, data);

            // Step 3: Save updated XML back to string
            string updatedXml = embeddedDoc.OuterXml;

            // Step 4: Escape again and store it back
            trTypeDataNode.InnerText = updatedXml;
            port.transportTypeData = trTypeDataNode.InnerText;

        }

        private void UpdateInnerXmlContent(XmlNode parentNode, Dictionary<string, string> data)
        {
            foreach (XmlNode node in parentNode.ChildNodes)
            {
                if (node.NodeType == XmlNodeType.Element)
                {
                    if (node.HasChildNodes && node.InnerText.Trim().StartsWith("<"))
                    {
                        if (node.ChildNodes.OfType<XmlElement>().Any())
                        {
                            UpdateInnerXmlContent(node, data);
                        }else // text node children
                        {
                            string escapedXml = node.InnerText;
                            XmlDocument embeddedDoc = new XmlDocument();
                            embeddedDoc.LoadXml(escapedXml);
                            UpdateInnerXmlContent(embeddedDoc.DocumentElement, data);
                            node.InnerText = embeddedDoc.OuterXml;
                        }
                    }
                    else if (data.ContainsKey(node.Name))
                    {
                        node.InnerText = data[node.Name];
                    }
                }
            }

        }
        

    }
}
