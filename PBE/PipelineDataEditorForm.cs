using PBE.Models;
using System.Collections.Generic;
using System.Windows.Forms;
using PBE.Utils;
using PBE.Controllers;

namespace PBE
{
    public partial class PipelineDataEditorForm : Form
    {

        PipelineDataController pdc;

        public PipelineDataEditorForm(Port port, bool isReceivePipelineData)
        {
            InitializeComponent();
            textBoxPortName.Text = port.name;
            pdc = new PipelineDataController(port, isReceivePipelineData);
            foreach (PropertyBag prop in pdc.properties)
            {
                dataGridViewData.Rows.Add(prop.Name, prop.Value, prop.Warning);
            }
            textBoxPromotions.Text = pdc.promotions;
        }



        private void btnSave_Click(object sender, System.EventArgs e)
        {
            Dictionary<string, string> data = new Dictionary<string, string>();
            foreach (DataGridViewRow row in dataGridViewData.Rows)
            {
                if (row.Cells[0].Value != null && row.Cells[0].Value.ToString().Length > 0)
                {
                    data[row.Cells[0].Value.ToString()] = row.Cells[1].Value.ToString();
                }
            }

            if (textBoxPromotions.Text.Length > 0) {
                XmlHelper.ValidateXml(textBoxPromotions.Text);
            }
            pdc.UpdatePipelineData(data, textBoxPromotions.Text);
            this.Close();
        }
    }
}
