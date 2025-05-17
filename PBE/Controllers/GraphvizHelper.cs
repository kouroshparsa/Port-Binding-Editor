using PBE.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
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
            Dictionary<string, HashSet<string>> app_ports = new Dictionary<string, HashSet<string>>();
            foreach (Port sendPort in bindings.sendPorts.Values)
            {
                foreach (string receivePortName in GetReceivePorts(sendPort)){
                    if (receivePorts.Contains(receivePortName))
                    {
                        receivePorts.Remove(receivePortName);
                    }

                    string key = "\"" + receivePortName + "\"->\"" + sendPort.name + "\";";
                    if (!identifiedMaps.Contains(key))
                    {
                        identifiedMaps.Add(key);
                        maps.Append(key);
                    }

                    string appName = "?";
                    if (bindings.receivePorts.ContainsKey(receivePortName))
                    {
                        Port receivePort = bindings.receivePorts[receivePortName];
                        appName = receivePort.applicationName;
                    }
                    if (!app_ports.ContainsKey(appName))
                        app_ports[appName] = new HashSet<string>();
                    app_ports[appName].Add(receivePortName);
                    
                    if (!app_ports.ContainsKey(sendPort.applicationName))
                        app_ports[sendPort.applicationName] = new HashSet<string>();
                    app_ports[sendPort.applicationName].Add(sendPort.name);
                }
            }

            // add receive ports that do not have a send port:
            foreach(string receivePortName in receivePorts)
            {
                maps.Append("\"" + receivePortName + "\";");
                Port receivePort = bindings.receivePorts[receivePortName];
                if (!app_ports.ContainsKey(receivePort.applicationName))
                    app_ports[receivePort.applicationName] = new HashSet<string>();
                app_ports[receivePort.applicationName].Add(receivePortName);
            }

            string clusters = GetClusters(app_ports);
            string map_section = maps.ToString();

            string definition = @"digraph G {style=bold;rankdir=""LR"";
node [margin=0.1 fontcolor=blue width=0.5 shape=rectangle style=""rounded, filled""]" +
            clusters + map_section + "}";
            return GetGraph(definition);
        }

        private static string GetClusters(Dictionary<string, HashSet<string>> app_ports)
        {
            int cluster_count = 1;
            StringBuilder sb = new StringBuilder();
            foreach (KeyValuePair<string, HashSet<string>> kv in app_ports)
            {
                StringBuilder sb_ports = new StringBuilder();
                foreach(string p in kv.Value)
                {
                    sb_ports.Append("\"" + p + "\";");
                }

                sb.Append($"subgraph cluster_{cluster_count}" +
                    "{ label = \"" + kv.Key + "\";" +
                    sb_ports +
                "}");
                cluster_count += 1;
            }
            return sb.ToString();
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
