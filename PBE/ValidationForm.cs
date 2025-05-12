using PBE.Controllers;
using PBE.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace PBE
{
    public partial class ValidationForm : Form
    {
        private string portBindingMasterPath;
        private string generatorPath;
        private DataBindings bindings;
        public ValidationForm(string portBindingMasterPath, string generatorPath, DataBindings bindings)
        {
            InitializeComponent();
            this.portBindingMasterPath = portBindingMasterPath;
            this.generatorPath = generatorPath;
            this.bindings = bindings;
        }

        private void ValidationForm_Load(object sender, EventArgs e)
        {
            dataGridViewValidationResults.Rows.Clear();
            rtb_validation_results.Text = Validator.GetValidationResults(portBindingMasterPath, generatorPath);
            PipelineDataController pdc;

            // Receive pipeline data:
            foreach (Port port in bindings.allPorts.Values)
            {
                pdc = new PipelineDataController(port, true, bindings.AppName);
                List<PropertyBag> warnings = pdc.properties.Where(pb => pb.Failed).ToList();
                foreach (PropertyBag prop in warnings)
                {
                    dataGridViewValidationResults.Rows.Add(port.name, "Receive Pipeline Data", prop.Name, prop.Value, prop.Warning);
                }
            }
            // Send pipeline data:
            foreach (Port port in bindings.allPorts.Values)
            {
                pdc = new PipelineDataController(port, false, bindings.AppName);
                List<PropertyBag> warnings = pdc.properties.Where(pb => pb.Failed).ToList();
                foreach (PropertyBag prop in warnings)
                {
                    dataGridViewValidationResults.Rows.Add(port.name, "Send Pipeline Data", prop.Name, prop.Value, prop.Warning);
                }
            }
            

            // TransportType:
            foreach (Port port in bindings.allPorts.Values)
            {
                var ttc = new TransportTypeController(port, bindings.AppName);
                List<PropertyBag> warnings = ttc.properties.Where(pb => pb.Failed).ToList();
                foreach (PropertyBag prop in warnings)
                {
                    dataGridViewValidationResults.Rows.Add(port.name, "Transport Type", prop.Name, prop.Value, prop.Warning);
                }
            }
        }
    }
}
