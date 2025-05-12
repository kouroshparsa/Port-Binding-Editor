using PBE.Models;
using PBE.Utils;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace PBE
{
    public partial class FilterEditorForm : Form
    {
        private Port port;
        public FilterEditorForm(Port port)
        {
            this.port = port;
            InitializeComponent();
            richTextBoxFilters.Text = XmlHelper.FormatXml(port.filters);
        }

        private void btnFind_Click(object sender, EventArgs e)
        {
            richTextBoxFilters.SelectionStart = 0;
            richTextBoxFilters.SelectionLength = richTextBoxFilters.Text.Length;
            richTextBoxFilters.SelectionBackColor = Color.White;

            string keywords = textBoxSearch.Text;
            if (keywords == string.Empty)
                return;

            int s_start = richTextBoxFilters.SelectionStart, startIndex = 0, index;

            while ((index = richTextBoxFilters.Text.IndexOf(keywords, startIndex)) != -1)
            {
                richTextBoxFilters.Select(index, keywords.Length);
                richTextBoxFilters.SelectionBackColor = Color.Yellow;

                startIndex = index + keywords.Length;
            }

            richTextBoxFilters.SelectionStart = s_start;
            richTextBoxFilters.SelectionLength = 0;
            richTextBoxFilters.SelectionBackColor = Color.White;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                string xml = XmlHelper.MinifyXml(richTextBoxFilters.Text.Replace("\n", "\r\n"));
                const string XML_DEF = @"<?xml version=""1.0"" encoding=""utf-16""?>";
                if (!xml.StartsWith("<?xml")){
                    xml = XML_DEF + xml;
                }
                this.port.filters = xml;
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Invalid xml: {ex.Message}");
            }

        }
    }
}
