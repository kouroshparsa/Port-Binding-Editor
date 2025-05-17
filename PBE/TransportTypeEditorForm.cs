using PBE.Controllers;
using PBE.Models;
using PBE.Utils;
using System.Collections.Generic;
using System.Windows.Forms;

namespace PBE
{
    public partial class TransportTypeEditorForm : Form
    {
        TransportTypeController ttc;

        public TransportTypeEditorForm(Port port)
        {
            InitializeComponent();
            textBoxPortName.Text = port.name;
            ttc = new TransportTypeController(port);
            foreach (PropertyBag prop in ttc.properties)
            {
                dataGridViewTransportType.Rows.Add(prop.Name, prop.Value, prop.Warning);
            }
        }

        private void btnSave_Click(object sender, System.EventArgs e)
        {
            Dictionary<string, string> data = new Dictionary<string, string>();
            foreach (DataGridViewRow row in dataGridViewTransportType.Rows)
            {
                if (row.Cells[0].Value != null && row.Cells[0].Value.ToString().Length > 0)
                {
                    data[row.Cells[0].Value.ToString()] = row.Cells[1].Value.ToString();
                }
            }

            ttc.UpdateTransportType(data);
            this.Close();
        }
    }
}
