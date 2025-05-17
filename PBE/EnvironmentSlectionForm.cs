using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PBE
{
    public partial class EnvironmentSlectionForm : Form
    {
        public string selectedEnv = null;
        private string[] v;

        public EnvironmentSlectionForm()
        {
            InitializeComponent();
        }

        public EnvironmentSlectionForm(string[] vals)
        {
            InitializeComponent();
            foreach(string v in vals)
            {
                comboBoxEnvs.Items.Add(v);
            }
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            selectedEnv = comboBoxEnvs.Text;
            this.Close();
        }
    }
}
