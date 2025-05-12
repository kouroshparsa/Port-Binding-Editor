using PBE.Controllers;
using PBE.Models;
using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.Text.RegularExpressions;
using System.Windows.Forms;



namespace PBE
{
    public partial class FormMain : Form
    {
        private DataBindings bindings;
        public FormMain()
        {
            InitializeComponent();
            
        }

        private void DrawFlow()
        {
            Image img = GraphvizHelper.GetGraph(this.bindings);
            imageBox1.Image = img;
        }
        private void btnPortBindingsMaster_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog of = new OpenFileDialog())
            {
                if (of.ShowDialog() == DialogResult.OK)
                {
                    textBoxPortBindingMasterFile.Text = of.FileName;
                    this.bindings = BindingParser.Parse(of.FileName);
                    TreeNodeHelper.DrawTree(treeView1, this.bindings);
                    DrawFlow();

                }
            }
            
        }
        private void btnSettingsFile_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog of = new OpenFileDialog())
            {
                if (of.ShowDialog() == DialogResult.OK)
                {
                    textBoxSettingsFileGeneratorFile.Text = of.FileName;
                }
            }
        }

        private void filtersToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (treeView1.SelectedNode == null) {
                MessageBox.Show("Please select a node");
                return;
            }

            string sendPortName = "";
            if (treeView1.SelectedNode.Level == 3)
            {
                if(treeView1.SelectedNode.Parent.Parent.Text != "Send Ports")
                {
                    MessageBox.Show("Please select a valid node under send ports");
                    return;
                }
                sendPortName = treeView1.SelectedNode.Parent.Text;
            }
            else if (treeView1.SelectedNode.Level == 2)
            {
                if (treeView1.SelectedNode.Parent.Text != "Send Ports")
                {
                    MessageBox.Show("Please select a valid node under send ports");
                    return;
                }
                sendPortName = treeView1.SelectedNode.Text;
            }
            else
            {
                MessageBox.Show("Please select a valid node");
                return;
            }

            Port port = bindings.sendPorts[sendPortName];
            var form = new FilterEditorForm(port);
            form.ShowDialog();
            //bindings.sendPorts[sendPortName].filters = form.GetFilters();
            TreeNodeHelper.DrawTree(treeView1, this.bindings);
            DrawFlow();
        }

        private string GetSelectedPort()
        {
            if (treeView1.SelectedNode == null)
            {
                MessageBox.Show("Please select a node");
                return null;
            }

            string portName = null;
            if (treeView1.SelectedNode.Level == 3)
            {
                portName = treeView1.SelectedNode.Parent.Text;
            }
            else if (treeView1.SelectedNode.Level == 2)
            {
                portName = treeView1.SelectedNode.Text;
            }
            else
            {
                MessageBox.Show("Please select a valid node");
                return null;
            }
            return portName;
        }
        private void pipelineDataToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void transportTypeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string portName = GetSelectedPort();
            if (portName == null)
                return;

            Port port = null;
            if (bindings.sendPorts.ContainsKey(portName))
                port = bindings.sendPorts[portName];
            else
                port = bindings.receivePorts[portName];
            
            var form = new TransportTypeEditorForm(port, bindings.AppName);
            form.ShowDialog();
            
        }

        private void importFromBindingFileToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            btnPortBindingsMaster_Click(sender, e);
        }

        private void exportBindingsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if(this.bindings == null)
            {
                MessageBox.Show("First you need to load a binding file");
                return;
            }

            using (SaveFileDialog sfd = new SaveFileDialog())
            {
                if (sfd.ShowDialog() == DialogResult.OK)
                {
                    BindingExporter.Export(bindings, sfd.FileName);
                }
            }
            
        }

        private void addressToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string portName = GetSelectedPort();
            if (portName == null)
                return;

            dynamic port;
            if (bindings.receivePorts.ContainsKey(portName))
                port = bindings.receivePorts[portName];
            else
                port = bindings.sendPorts[portName];
            
            var form = new InputForm("Enter the address:", port.address);
            form.ShowDialog();
            if (form.ok)
            {
                port.address = form.enteredValue;
                TreeNodeHelper.DrawTree(treeView1, this.bindings);
            }
        }

        private void handlerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string portName = GetSelectedPort();
            if (portName == null)
                return;
            dynamic port;
            if (bindings.receivePorts.ContainsKey(portName))
                port = bindings.receivePorts[portName];
            else
                port = bindings.sendPorts[portName];

            var form = new InputForm("Enter the handler (host instance) name:", port.handler);
            form.ShowDialog();
            if (form.ok) {
                port.handler = form.enteredValue;
                TreeNodeHelper.DrawTree(treeView1, this.bindings);
            }
        }

        private void btnValidate_Click(object sender, EventArgs e)
        {
            if(string.IsNullOrEmpty(textBoxPortBindingMasterFile.Text) ||
                string.IsNullOrEmpty(textBoxSettingsFileGeneratorFile.Text))
            {
                MessageBox.Show("Please enter a port binding master file and a file generator to validate against.");
                return;
            }
            var form = new ValidationForm(textBoxPortBindingMasterFile.Text, textBoxSettingsFileGeneratorFile.Text, bindings);
            form.ShowDialog();
        }

        private void importSettingsFileGeneratorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            btnSettingsFile_Click(sender, e);
        }

        private void deletePortToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var confirmResult = MessageBox.Show("Are you sure to delete this port?",
                                     "Confirm Delete!",
                                     MessageBoxButtons.YesNo);
            if (confirmResult == DialogResult.No)
            {
                return;
            }


            string portName = GetSelectedPort();
            if (portName == null)
                return;

            var ports = bindings.GetPorts(portName);
            string guid = bindings.GetPort(portName).guid;
            if (guid != null) {
                bindings.export_template = bindings.export_template.Replace(guid, "");
            }
            ports.Remove(portName);
            TreeNodeHelper.DrawTree(treeView1, this.bindings);
            DrawFlow();
        }

        private void renamePort(string oldName, string newName)
        {
            var ports = bindings.GetPorts(oldName);
            ports[newName] = ports[oldName];
            ports.Remove(oldName);
            ports[newName].name = newName;
            TreeNodeHelper.DrawTree(treeView1, this.bindings);
            DrawFlow();
        }
        private void renamePortToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string portName = GetSelectedPort();
            if (portName == null)
                return;

            var ports = bindings.GetPorts(portName);
            string newPortName = null;
            string prefix = "";
            do
            {
                if(newPortName != null)
                {
                    prefix = "Invalid port name. This port name is already in use. ";
                }
                var form = new InputForm($"{prefix}Enter a new port name:", portName);
                form.ShowDialog();
                if (!form.ok)
                {
                    return;
                }
                newPortName = form.enteredValue;
            } while (ports.ContainsKey(newPortName));

            renamePort(portName, newPortName);

        }

        private void copyPortToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string portName = GetSelectedPort();
            if (portName == null)
                return;

            var port = bindings.GetPort(portName);
            Clipboard.SetText(port.outerXml);
        }

        private string replace_guids(string str)
        {
            string pattern = "ConfigurationClsid=\"([^\"]+)\"";

            foreach (Match match in Regex.Matches(str, pattern))
            {
                if (match.Success && match.Groups.Count > 0)
                {
                    var old = match.Groups[1].Value;
                    Console.WriteLine(old);
                    string newVal = $"ConfigurationClsid=\"{Guid.NewGuid()}\"";
                    str = str.Replace(match.Value, newVal);
                }
            }
            return str;
        }
        private void pastePortToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string portXml = Clipboard.GetText().Trim();
            portXml = replace_guids(portXml);

            try
            {
                if (portXml.StartsWith("<ReceivePort"))
                {
                    var port = new ReceivePort(portXml);
                    bindings.receivePorts.Add(port.name, port);
                    TreeNodeHelper.DrawTree(treeView1, this.bindings);
                    DrawFlow();
                }
                else if (portXml.StartsWith("<SendPort"))
                {
                    var port = new SendPort(portXml);
                    bindings.sendPorts.Add(port.name, port);
                    TreeNodeHelper.DrawTree(treeView1, this.bindings);
                    DrawFlow();
                }
                else
                {
                    MessageBox.Show("Invalid value. You can only paste a send port or receive port xml.");
                }
            }catch(Exception ex)
            {
                MessageBox.Show($"Invalid xml. {ex.Message}");
            }

        }

        private void textBoxPortBindingMasterFile_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBoxPortBindingMasterFile_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == Convert.ToChar(Keys.Enter))
            {
                this.bindings = BindingParser.Parse(textBoxPortBindingMasterFile.Text);
                TreeNodeHelper.DrawTree(treeView1, this.bindings);
                DrawFlow();
            }
        }

        private void pipelineDataToolStripMenuItem_Click_1(object sender, EventArgs e)
        {

        }

        private void receiveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string portName = GetSelectedPort();
            if (portName == null)
                return;

            Port port = null;
            if (bindings.sendPorts.ContainsKey(portName))
                port = bindings.sendPorts[portName];
            else
                port = bindings.receivePorts[portName];

            var form = new PipelineDataEditorForm(port, true, bindings.AppName);
            form.ShowDialog();
        }

        private void sendToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string portName = GetSelectedPort();
            if (portName == null)
                return;

            Port port = null;
            if (bindings.sendPorts.ContainsKey(portName))
                port = bindings.sendPorts[portName];
            else
                port = bindings.receivePorts[portName];

            var form = new PipelineDataEditorForm(port, false, bindings.AppName);
            form.ShowDialog();
        }

        private void btnValidatePorts_Click(object sender, EventArgs e)
        {

        }

        private void treeView1_AfterSelect(object sender, TreeViewEventArgs e)
        {

        }

        private void saveImageToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if(bindings == null)
            {
                MessageBox.Show("First load a port binding file");
                return;
            }


            using (SaveFileDialog sfd = new SaveFileDialog())
            {
                sfd.Filter = "Image Files (*.jpg)|*.jpg";
                sfd.DefaultExt = "jpg";
                sfd.AddExtension = true;
                if (sfd.ShowDialog() == DialogResult.OK)
                {
                    Image img = GraphvizHelper.GetGraph(this.bindings);
                    img.Save(sfd.FileName, ImageFormat.Jpeg);
                }
            }

        }

        private void FormMain_Load(object sender, EventArgs e)
        {
        }
    }
}
