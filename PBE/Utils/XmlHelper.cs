using System;
using System.Text;
using System.Xml;
using System.IO;
using System.Net;
using System.Xml.Schema;
using System.Xml.Linq;

namespace PBE.Utils
{
    public class XmlHelper
    {
        public static string FindXPath(XmlNode node)
        {
            StringBuilder builder = new StringBuilder();
            while (node != null)
            {
                switch (node.NodeType)
                {
                    case XmlNodeType.Attribute:
                        builder.Insert(0, "/@" + node.Name);
                        node = ((XmlAttribute)node).OwnerElement;
                        break;
                    case XmlNodeType.Element:
                        int index = FindElementIndex((XmlElement)node);
                        builder.Insert(0, "/" + node.Name + "[" + index + "]");
                        node = node.ParentNode;
                        break;
                    case XmlNodeType.Document:
                        return builder.ToString();
                    default:
                        throw new ArgumentException("Only elements and attributes are supported");
                }
            }
            throw new ArgumentException("Node was not in a document");
        }

        private static int FindElementIndex(XmlElement element)
        {
            XmlNode parentNode = element.ParentNode;
            if (parentNode is XmlDocument)
                return 1;

            XmlElement parent = (XmlElement)parentNode;
            int index = 1;
            foreach (XmlNode candidate in parent.ChildNodes)
            {
                if (candidate is XmlElement && candidate.Name == element.Name)
                {
                    if (candidate == element)
                        return index;
                    index++;
                }
            }
            throw new ArgumentException("Couldn't find element within parent");
        }

        public static string ConvertEscapedXmlToUnescaped(string escapedXml)
        {
            return WebUtility.HtmlDecode(escapedXml);
        }

        public static void ValidateXml(string xmlString)
        {
            // Convert the XSD string into a schema
            XmlSchemaSet schemaSet = new XmlSchemaSet();
            //schemaSet.Add(null, XmlReader.Create(new StringReader(xsdString)));

            // Set up the XmlReaderSettings
            XmlReaderSettings settings = new XmlReaderSettings
            {
                ValidationType = ValidationType.Schema,
                Schemas = schemaSet
            };

            using (StringReader stringReader = new StringReader(xmlString))
            {
                using (XmlReader reader = XmlReader.Create(stringReader, settings))
                {
                    while (reader.Read()) { }// if invalid, it will throw an XmlException
                }
            }
        }

        public static string FormatXml(string xml)
        {
            try
            {
                XDocument doc = XDocument.Parse(xml);
                return doc.ToString();
            }
            catch (Exception)
            {
                return xml;
            }
        }

        public static string FormatXml(StringBuilder xml)
        {
            return XmlHelper.FormatXml(xml.ToString());
        }

        public static string MinifyXml(string xml)
        {
            var stringBuilder = new StringBuilder();

            var settings = new XmlWriterSettings
            {
                Indent = false,
                NewLineHandling = NewLineHandling.None,
                OmitXmlDeclaration = false
            };

            using (var stringReader = new StringReader(xml))
            using (var xmlReader = XmlReader.Create(stringReader, new XmlReaderSettings { IgnoreWhitespace = true }))
            using (var xmlWriter = XmlWriter.Create(stringBuilder, settings))
            {
                xmlWriter.WriteNode(xmlReader, true);
            }

            return stringBuilder.ToString();
        }

        public static string XmlEscape(string unescaped)
        {
            XmlDocument doc = new XmlDocument();
            var node = doc.CreateAttribute("foo");
            node.InnerText = unescaped;
            return node.InnerXml;
        }

    }


}
