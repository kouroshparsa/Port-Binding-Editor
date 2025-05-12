using PBE.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Text;
using System.Xml;

namespace PBE.Controllers
{
    public class GraphvizHelper
    {
        public static Image GetGraph(DataBindings bindings)
        {
            HashSet<string> receivePorts = new HashSet<string>(bindings.receivePorts.Keys);
            StringBuilder maps = new StringBuilder();
            HashSet<string> identifiedMaps = new HashSet<string>();
            foreach (Port port in bindings.sendPorts.Values)
            {
                foreach (string receivePortName in GetReceivePorts(port)){
                    if (receivePorts.Contains(receivePortName))
                    {
                        receivePorts.Remove(receivePortName);
                    }

                    string key = "\"" + receivePortName + "\"->\"" + port.name + "\";";
                    if (!identifiedMaps.Contains(key))
                    {
                        identifiedMaps.Add(key);
                        maps.Append(key);
                    }
                }
            }

            // add receive ports that do not have a send port:
            foreach(string port in receivePorts)
            {
                maps.Append("\"" + port + "\";");
            }

            string map_section = maps.ToString();
            string definition = @"digraph G {style=bold;
rankdir=""LR"";
node [margin=0.1 fontcolor=blue width=0.5 shape=rectangle style=""rounded, filled""]
subgraph cluster_1 {
    label = """ + bindings.AppName + "\";" +
    map_section + 
"}}";
            return GetGraph(definition);
        }

        private static HashSet<string> GetReceivePorts(Port sendPort)
        {
            HashSet<string> ports = new HashSet<string>();
            string xPath = "/Filter/Group/Statement[contains(@Property,'BTS.ReceivePortName')]";
            string f = sendPort.filters;
            XmlDocument doc = new XmlDocument();
            doc.LoadXml(f);
            foreach (XmlNode node in doc.SelectNodes(xPath))
            {
                ports.Add(node.Attributes["Value"].Value.ToString());
            }
            return ports;
        }

        public static Image GetGraph(string dotInput)
        {
            var dotPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "tools", "graphviz", "dot.exe");

            using (var memoryStream = new MemoryStream())
            {
                var processStartInfo = new ProcessStartInfo
                {
                    FileName = dotPath,
                    Arguments = "-Tpng -Gdpi=300", // No input/output file
                    RedirectStandardInput = true,
                    RedirectStandardOutput = true,
                    RedirectStandardError = true, // Optional: useful for debugging
                    UseShellExecute = false,
                    CreateNoWindow = true
                };

                using (var process = new Process { StartInfo = processStartInfo })
                {
                    process.Start();

                    // Write the DOT content to standard input
                    using (var writer = process.StandardInput)
                    {
                        writer.Write(dotInput);
                    }

                    // Read the PNG image from standard output
                    using (var outputStream = process.StandardOutput.BaseStream)
                    {
                        outputStream.CopyTo(memoryStream);
                    }

                    process.WaitForExit();

                    if (process.ExitCode != 0)
                    {
                        throw new Exception("Graphviz failed to process the input.");
                    }
                }

                memoryStream.Seek(0, SeekOrigin.Begin);
                return Image.FromStream(memoryStream);
            }
        }


    }
}
