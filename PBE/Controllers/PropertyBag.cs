
using System.Collections.Generic;
using System.Windows.Forms;

namespace PBE.Controllers
{
    public class PropertyBag
    {

        public string Name { get; set; }
        public string Value { get; set; }

        public string Warning { get; set; }

        public bool Failed { get {
                return this.Warning.Length > 1;
            }
        }

        public PropertyBag(string name, string value, string warning)
        {
            Name = name;
            Value = value;
            Warning = warning;
        }
        
    }
}
