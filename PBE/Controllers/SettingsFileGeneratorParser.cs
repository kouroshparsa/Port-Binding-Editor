using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace PBE.Controllers
{
    class SettingsFileGeneratorParser
    {
        public static Dictionary<string, Dictionary<string, string>> Parse(string path)
        {
            Dictionary<string, Dictionary<string, string>> data = new Dictionary<string, Dictionary<string, string>>();
            string contents = "";
            using (StreamReader reader = new StreamReader(path)) {
                contents = reader.ReadToEnd();
            }

            XDocument doc = XDocument.Parse(contents);
            XNamespace ss = "urn:schemas-microsoft-com:office:spreadsheet";

            var rows = doc.Descendants(ss + "Row")
                          .Select(row => row.Elements(ss + "Cell")
                                            .Select(cell => cell.Element(ss + "Data")?.Value ?? "")
                                            .ToList())
                          .ToList();

            if(rows.Count < 1)
            {
                throw new Exception("Invalid SettingsFileGenerator.");
            }
            Dictionary<int, string> environment_inds = new Dictionary<int, string>();
            bool settingsRow = false;
            foreach (var row in rows)
            {
                if (row[0] == "Environment Name:")
                {
                    for (int ind = 1; ind < row.Count; ind++)
                    {
                        string env = row[ind];
                        environment_inds[ind] = env;
                        data[env] = new Dictionary<string, string>();
                    }
                }else if(row[0] == "Settings:")
                {
                    settingsRow = true;
                }else if(settingsRow) {
                    string key = row[0];
                    for (int ind = 1; ind < row.Count; ind++)
                    {
                        string env = environment_inds[ind];
                        data[env][key] = row[ind];
                    }
                }
            }
            data.Remove("ValueType");
            return data;
        }
    }
}
