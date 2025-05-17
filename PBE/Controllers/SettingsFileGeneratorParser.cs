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
            // returns data[environment][substitution-key-name]

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
            int default_val_ind = 1;
            foreach (var row in rows)
            {
                if (row[0] == "Environment Name:")
                {
                    for (int ind = 1; ind < row.Count; ind++)
                    {
                        string env = row[ind];
                        environment_inds[ind] = env;
                        if(env == "Default Values")
                        {
                            default_val_ind = ind;
                        }
                        data[env] = new Dictionary<string, string>();
                    }
                }else if(row[0] == "Settings:")
                {
                    settingsRow = true;
                }else if(settingsRow) {
                    string key = row[0];
                    string default_val = environment_inds[default_val_ind];
                    for (int ind = 1; ind < row.Count; ind++)
                    {
                        string env = environment_inds[ind];
                        string val = row[ind];
                        if (ind != default_val_ind && string.IsNullOrEmpty(val))
                        {
                            val = row[default_val_ind];
                        }
                        data[env][key] = val;
                    }
                }
            }
            data.Remove("ValueType");
            return data;
        }
    }
}
