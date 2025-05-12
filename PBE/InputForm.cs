using System;
using System.Windows.Forms;

namespace PBE
{
    public partial class InputForm : Form
    {
        public string enteredValue = "";
        public bool ok = false;

        public InputForm(string label, string val=null)
        {
            InitializeComponent();
            label1.Text = label;
            if (val != null)
            {
                textBox1.Text = val;
                enteredValue = val;
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            ok = false;
            this.Close();
        }

        private void bynOk_Click(object sender, EventArgs e)
        {
            enteredValue = textBox1.Text;
            ok = true;
            this.Close();
        }
    }
}
