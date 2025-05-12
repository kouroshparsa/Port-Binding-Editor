namespace PBE
{
    partial class FormMain
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormMain));
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.textBoxPortBindingMasterFile = new System.Windows.Forms.TextBox();
            this.textBoxSettingsFileGeneratorFile = new System.Windows.Forms.TextBox();
            this.btnPortBindingsMaster = new System.Windows.Forms.Button();
            this.btnSettingsFile = new System.Windows.Forms.Button();
            this.treeView1 = new System.Windows.Forms.TreeView();
            this.contextMenuStripTreeNodes = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.filtersToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.transportTypeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.addressToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.handlerToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.deletePortToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.copyPortToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.pastePortToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.renamePortToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.pipelineDataToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.receiveToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.sendToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStripMain = new System.Windows.Forms.MenuStrip();
            this.importFromBindingFileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.importFromBindingFileToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.importSettingsFileGeneratorToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exportBindingsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.btnValidateSettings = new System.Windows.Forms.Button();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.imageBox1 = new Cyotek.Windows.Forms.ImageBox();
            this.contextMenuStripFlowDiagram = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.saveImageToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.contextMenuStripTreeNodes.SuspendLayout();
            this.menuStripMain.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.contextMenuStripFlowDiagram.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(22, 28);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(120, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "PortBindingsMaster File:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 53);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(130, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "SettingsFileGenerator File:";
            // 
            // textBoxPortBindingMasterFile
            // 
            this.textBoxPortBindingMasterFile.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxPortBindingMasterFile.Location = new System.Drawing.Point(141, 25);
            this.textBoxPortBindingMasterFile.Name = "textBoxPortBindingMasterFile";
            this.textBoxPortBindingMasterFile.Size = new System.Drawing.Size(414, 20);
            this.textBoxPortBindingMasterFile.TabIndex = 2;
            this.textBoxPortBindingMasterFile.TextChanged += new System.EventHandler(this.textBoxPortBindingMasterFile_TextChanged);
            this.textBoxPortBindingMasterFile.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBoxPortBindingMasterFile_KeyPress);
            // 
            // textBoxSettingsFileGeneratorFile
            // 
            this.textBoxSettingsFileGeneratorFile.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxSettingsFileGeneratorFile.Location = new System.Drawing.Point(141, 50);
            this.textBoxSettingsFileGeneratorFile.Name = "textBoxSettingsFileGeneratorFile";
            this.textBoxSettingsFileGeneratorFile.Size = new System.Drawing.Size(414, 20);
            this.textBoxSettingsFileGeneratorFile.TabIndex = 3;
            // 
            // btnPortBindingsMaster
            // 
            this.btnPortBindingsMaster.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnPortBindingsMaster.Location = new System.Drawing.Point(561, 25);
            this.btnPortBindingsMaster.Name = "btnPortBindingsMaster";
            this.btnPortBindingsMaster.Size = new System.Drawing.Size(35, 20);
            this.btnPortBindingsMaster.TabIndex = 4;
            this.btnPortBindingsMaster.Text = "<<";
            this.btnPortBindingsMaster.UseVisualStyleBackColor = true;
            this.btnPortBindingsMaster.Click += new System.EventHandler(this.btnPortBindingsMaster_Click);
            // 
            // btnSettingsFile
            // 
            this.btnSettingsFile.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSettingsFile.Location = new System.Drawing.Point(561, 50);
            this.btnSettingsFile.Name = "btnSettingsFile";
            this.btnSettingsFile.Size = new System.Drawing.Size(35, 20);
            this.btnSettingsFile.TabIndex = 5;
            this.btnSettingsFile.Text = "<<";
            this.btnSettingsFile.UseVisualStyleBackColor = true;
            this.btnSettingsFile.Click += new System.EventHandler(this.btnSettingsFile_Click);
            // 
            // treeView1
            // 
            this.treeView1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.treeView1.ContextMenuStrip = this.contextMenuStripTreeNodes;
            this.treeView1.Location = new System.Drawing.Point(6, 6);
            this.treeView1.Name = "treeView1";
            this.treeView1.Size = new System.Drawing.Size(574, 270);
            this.treeView1.TabIndex = 6;
            this.treeView1.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.treeView1_AfterSelect);
            // 
            // contextMenuStripTreeNodes
            // 
            this.contextMenuStripTreeNodes.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.filtersToolStripMenuItem,
            this.transportTypeToolStripMenuItem,
            this.addressToolStripMenuItem,
            this.handlerToolStripMenuItem,
            this.deletePortToolStripMenuItem,
            this.copyPortToolStripMenuItem,
            this.pastePortToolStripMenuItem,
            this.renamePortToolStripMenuItem,
            this.pipelineDataToolStripMenuItem});
            this.contextMenuStripTreeNodes.Name = "contextMenuStripTreeNodes";
            this.contextMenuStripTreeNodes.Size = new System.Drawing.Size(180, 202);
            // 
            // filtersToolStripMenuItem
            // 
            this.filtersToolStripMenuItem.Name = "filtersToolStripMenuItem";
            this.filtersToolStripMenuItem.Size = new System.Drawing.Size(179, 22);
            this.filtersToolStripMenuItem.Text = "Filters";
            this.filtersToolStripMenuItem.Click += new System.EventHandler(this.filtersToolStripMenuItem_Click);
            // 
            // transportTypeToolStripMenuItem
            // 
            this.transportTypeToolStripMenuItem.Name = "transportTypeToolStripMenuItem";
            this.transportTypeToolStripMenuItem.Size = new System.Drawing.Size(179, 22);
            this.transportTypeToolStripMenuItem.Text = "Transport Type Data";
            this.transportTypeToolStripMenuItem.Click += new System.EventHandler(this.transportTypeToolStripMenuItem_Click);
            // 
            // addressToolStripMenuItem
            // 
            this.addressToolStripMenuItem.Name = "addressToolStripMenuItem";
            this.addressToolStripMenuItem.Size = new System.Drawing.Size(179, 22);
            this.addressToolStripMenuItem.Text = "Address";
            this.addressToolStripMenuItem.Click += new System.EventHandler(this.addressToolStripMenuItem_Click);
            // 
            // handlerToolStripMenuItem
            // 
            this.handlerToolStripMenuItem.Name = "handlerToolStripMenuItem";
            this.handlerToolStripMenuItem.Size = new System.Drawing.Size(179, 22);
            this.handlerToolStripMenuItem.Text = "Handler";
            this.handlerToolStripMenuItem.Click += new System.EventHandler(this.handlerToolStripMenuItem_Click);
            // 
            // deletePortToolStripMenuItem
            // 
            this.deletePortToolStripMenuItem.Name = "deletePortToolStripMenuItem";
            this.deletePortToolStripMenuItem.Size = new System.Drawing.Size(179, 22);
            this.deletePortToolStripMenuItem.Text = "Delete Port";
            this.deletePortToolStripMenuItem.Click += new System.EventHandler(this.deletePortToolStripMenuItem_Click);
            // 
            // copyPortToolStripMenuItem
            // 
            this.copyPortToolStripMenuItem.Name = "copyPortToolStripMenuItem";
            this.copyPortToolStripMenuItem.Size = new System.Drawing.Size(179, 22);
            this.copyPortToolStripMenuItem.Text = "Copy Port";
            this.copyPortToolStripMenuItem.Click += new System.EventHandler(this.copyPortToolStripMenuItem_Click);
            // 
            // pastePortToolStripMenuItem
            // 
            this.pastePortToolStripMenuItem.Name = "pastePortToolStripMenuItem";
            this.pastePortToolStripMenuItem.Size = new System.Drawing.Size(179, 22);
            this.pastePortToolStripMenuItem.Text = "Paste Port";
            this.pastePortToolStripMenuItem.Click += new System.EventHandler(this.pastePortToolStripMenuItem_Click);
            // 
            // renamePortToolStripMenuItem
            // 
            this.renamePortToolStripMenuItem.Name = "renamePortToolStripMenuItem";
            this.renamePortToolStripMenuItem.Size = new System.Drawing.Size(179, 22);
            this.renamePortToolStripMenuItem.Text = "Rename Port";
            this.renamePortToolStripMenuItem.Click += new System.EventHandler(this.renamePortToolStripMenuItem_Click);
            // 
            // pipelineDataToolStripMenuItem
            // 
            this.pipelineDataToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.receiveToolStripMenuItem,
            this.sendToolStripMenuItem});
            this.pipelineDataToolStripMenuItem.Name = "pipelineDataToolStripMenuItem";
            this.pipelineDataToolStripMenuItem.Size = new System.Drawing.Size(179, 22);
            this.pipelineDataToolStripMenuItem.Text = "Pipeline Data";
            // 
            // receiveToolStripMenuItem
            // 
            this.receiveToolStripMenuItem.Name = "receiveToolStripMenuItem";
            this.receiveToolStripMenuItem.Size = new System.Drawing.Size(114, 22);
            this.receiveToolStripMenuItem.Text = "Receive";
            this.receiveToolStripMenuItem.Click += new System.EventHandler(this.receiveToolStripMenuItem_Click);
            // 
            // sendToolStripMenuItem
            // 
            this.sendToolStripMenuItem.Name = "sendToolStripMenuItem";
            this.sendToolStripMenuItem.Size = new System.Drawing.Size(114, 22);
            this.sendToolStripMenuItem.Text = "Send";
            this.sendToolStripMenuItem.Click += new System.EventHandler(this.sendToolStripMenuItem_Click);
            // 
            // menuStripMain
            // 
            this.menuStripMain.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.importFromBindingFileToolStripMenuItem});
            this.menuStripMain.Location = new System.Drawing.Point(0, 0);
            this.menuStripMain.Name = "menuStripMain";
            this.menuStripMain.Size = new System.Drawing.Size(599, 24);
            this.menuStripMain.TabIndex = 7;
            this.menuStripMain.Text = "menuStrip1";
            // 
            // importFromBindingFileToolStripMenuItem
            // 
            this.importFromBindingFileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.importFromBindingFileToolStripMenuItem1,
            this.importSettingsFileGeneratorToolStripMenuItem,
            this.exportBindingsToolStripMenuItem});
            this.importFromBindingFileToolStripMenuItem.Name = "importFromBindingFileToolStripMenuItem";
            this.importFromBindingFileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.importFromBindingFileToolStripMenuItem.Text = "File";
            // 
            // importFromBindingFileToolStripMenuItem1
            // 
            this.importFromBindingFileToolStripMenuItem1.Name = "importFromBindingFileToolStripMenuItem1";
            this.importFromBindingFileToolStripMenuItem1.Size = new System.Drawing.Size(227, 22);
            this.importFromBindingFileToolStripMenuItem1.Text = "Import port binding file";
            this.importFromBindingFileToolStripMenuItem1.Click += new System.EventHandler(this.importFromBindingFileToolStripMenuItem1_Click);
            // 
            // importSettingsFileGeneratorToolStripMenuItem
            // 
            this.importSettingsFileGeneratorToolStripMenuItem.Name = "importSettingsFileGeneratorToolStripMenuItem";
            this.importSettingsFileGeneratorToolStripMenuItem.Size = new System.Drawing.Size(227, 22);
            this.importSettingsFileGeneratorToolStripMenuItem.Text = "Import settings file generator";
            this.importSettingsFileGeneratorToolStripMenuItem.Click += new System.EventHandler(this.importSettingsFileGeneratorToolStripMenuItem_Click);
            // 
            // exportBindingsToolStripMenuItem
            // 
            this.exportBindingsToolStripMenuItem.Name = "exportBindingsToolStripMenuItem";
            this.exportBindingsToolStripMenuItem.Size = new System.Drawing.Size(227, 22);
            this.exportBindingsToolStripMenuItem.Text = "Export bindings";
            this.exportBindingsToolStripMenuItem.Click += new System.EventHandler(this.exportBindingsToolStripMenuItem_Click);
            // 
            // btnValidateSettings
            // 
            this.btnValidateSettings.Location = new System.Drawing.Point(141, 76);
            this.btnValidateSettings.Name = "btnValidateSettings";
            this.btnValidateSettings.Size = new System.Drawing.Size(105, 23);
            this.btnValidateSettings.TabIndex = 8;
            this.btnValidateSettings.Text = "Validate";
            this.btnValidateSettings.UseVisualStyleBackColor = true;
            this.btnValidateSettings.Click += new System.EventHandler(this.btnValidate_Click);
            // 
            // tabControl1
            // 
            this.tabControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Location = new System.Drawing.Point(0, 105);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(594, 305);
            this.tabControl1.TabIndex = 10;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.treeView1);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(586, 279);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Tree Diagram";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.imageBox1);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(586, 279);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Flow Diagram";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // imageBox1
            // 
            this.imageBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.imageBox1.ContextMenuStrip = this.contextMenuStripFlowDiagram;
            this.imageBox1.Location = new System.Drawing.Point(6, 6);
            this.imageBox1.Name = "imageBox1";
            this.imageBox1.Size = new System.Drawing.Size(574, 268);
            this.imageBox1.TabIndex = 1;
            // 
            // contextMenuStripFlowDiagram
            // 
            this.contextMenuStripFlowDiagram.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.saveImageToolStripMenuItem});
            this.contextMenuStripFlowDiagram.Name = "contextMenuStripFlowDiagram";
            this.contextMenuStripFlowDiagram.Size = new System.Drawing.Size(135, 26);
            // 
            // saveImageToolStripMenuItem
            // 
            this.saveImageToolStripMenuItem.Name = "saveImageToolStripMenuItem";
            this.saveImageToolStripMenuItem.Size = new System.Drawing.Size(134, 22);
            this.saveImageToolStripMenuItem.Text = "Save Image";
            this.saveImageToolStripMenuItem.Click += new System.EventHandler(this.saveImageToolStripMenuItem_Click);
            // 
            // FormMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(599, 413);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.btnValidateSettings);
            this.Controls.Add(this.menuStripMain);
            this.Controls.Add(this.btnSettingsFile);
            this.Controls.Add(this.btnPortBindingsMaster);
            this.Controls.Add(this.textBoxSettingsFileGeneratorFile);
            this.Controls.Add(this.textBoxPortBindingMasterFile);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStripMain;
            this.Name = "FormMain";
            this.Text = "Port Binding Editor 1.0.0";
            this.Load += new System.EventHandler(this.FormMain_Load);
            this.contextMenuStripTreeNodes.ResumeLayout(false);
            this.menuStripMain.ResumeLayout(false);
            this.menuStripMain.PerformLayout();
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage2.ResumeLayout(false);
            this.contextMenuStripFlowDiagram.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textBoxPortBindingMasterFile;
        private System.Windows.Forms.TextBox textBoxSettingsFileGeneratorFile;
        private System.Windows.Forms.Button btnPortBindingsMaster;
        private System.Windows.Forms.Button btnSettingsFile;
        private System.Windows.Forms.TreeView treeView1;
        private System.Windows.Forms.ContextMenuStrip contextMenuStripTreeNodes;
        private System.Windows.Forms.ToolStripMenuItem filtersToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem transportTypeToolStripMenuItem;
        private System.Windows.Forms.MenuStrip menuStripMain;
        private System.Windows.Forms.ToolStripMenuItem importFromBindingFileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem importFromBindingFileToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem exportBindingsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem addressToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem handlerToolStripMenuItem;
        private System.Windows.Forms.Button btnValidateSettings;
        private System.Windows.Forms.ToolStripMenuItem importSettingsFileGeneratorToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem deletePortToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem copyPortToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem pastePortToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem renamePortToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem pipelineDataToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem receiveToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem sendToolStripMenuItem;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.ContextMenuStrip contextMenuStripFlowDiagram;
        private System.Windows.Forms.ToolStripMenuItem saveImageToolStripMenuItem;
        private Cyotek.Windows.Forms.ImageBox imageBox1;
    }
}

