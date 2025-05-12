using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PBE.Controllers
{
    class Validator
    {
        public static string GetValidationResults(string portBindingMasterPath, string generatorPath)
        {
            HashSet<string> bindingVars;
            try
            {
                bindingVars = BindingParser.ExtractVariables(portBindingMasterPath);
            }
            catch (IOException)
            {
                return "Failed to read " + portBindingMasterPath;
            }

            try
            {
                StringBuilder sb = new StringBuilder();
                var res = SettingsFileGeneratorParser.Parse(generatorPath);
                foreach (string varName in bindingVars)
                {
                    List<string> missingValEnvs = new List<string>();
                    if(!res["Default Values"].ContainsKey(varName))
                    {
                        sb.Append($"The variable {varName} is missing in SettingsFileGenerator.\r\n");
                    }
                    else if(res["Default Values"][varName].Trim().Length == 0) // if there is a default value, then do not check the specific values
                    {
                        foreach (var item in res)
                        {
                            string env = item.Key;
                            if (!item.Value.ContainsKey(varName))
                            {
                                sb.Append($"The variable {varName} is missing in SettingsFileGenerator for environment={env}.\r\n");
                                break;
                            }
                        }
                    }
                    
                }

                
                if(sb.Length < 1)
                {
                    return "All variables were found.";
                }
                return sb.ToString();
            }
            catch (IOException)
            {
                return "Failed to read " + generatorPath;
            }

        }

        public static string GetPortValidationResults(string portBindingMasterPath)
        {
            HashSet<string> bindingVars;
            try
            {
                bindingVars = BindingParser.ExtractVariables(portBindingMasterPath);
            }
            catch (IOException)
            {
                return "Failed to read " + portBindingMasterPath;
            }

            return "";
        }
    }
}
