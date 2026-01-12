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
            this.applicationToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStripMain = new System.Windows.Forms.MenuStrip();
            this.importFromBindingFileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.reloadWithSubstitutionsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exportBindingsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.clearAllToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.treeView1 = new System.Windows.Forms.TreeView();
            this.contextMenuStripTreeNodes.SuspendLayout();
            this.menuStripMain.SuspendLayout();
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
            // contextMenuStripTreeNodes
            // 
            this.contextMenuStripTreeNodes.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.contextMenuStripTreeNodes.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.filtersToolStripMenuItem,
            this.transportTypeToolStripMenuItem,
            this.addressToolStripMenuItem,
            this.handlerToolStripMenuItem,
            this.deletePortToolStripMenuItem,
            this.copyPortToolStripMenuItem,
            this.pastePortToolStripMenuItem,
            this.renamePortToolStripMenuItem,
            this.pipelineDataToolStripMenuItem,
            this.applicationToolStripMenuItem});
            this.contextMenuStripTreeNodes.Name = "contextMenuStripTreeNodes";
            this.contextMenuStripTreeNodes.Size = new System.Drawing.Size(180, 224);
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
            // applicationToolStripMenuItem
            // 
            this.applicationToolStripMenuItem.Name = "applicationToolStripMenuItem";
            this.applicationToolStripMenuItem.Size = new System.Drawing.Size(179, 22);
            this.applicationToolStripMenuItem.Text = "Application";
            this.applicationToolStripMenuItem.Click += new System.EventHandler(this.applicationToolStripMenuItem_Click);
            // 
            // menuStripMain
            // 
            this.menuStripMain.ImageScalingSize = new System.Drawing.Size(24, 24);
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
            this.reloadWithSubstitutionsToolStripMenuItem,
            this.exportBindingsToolStripMenuItem,
            this.clearAllToolStripMenuItem});
            this.importFromBindingFileToolStripMenuItem.Name = "importFromBindingFileToolStripMenuItem";
            this.importFromBindingFileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.importFromBindingFileToolStripMenuItem.Text = "File";
            // 
            // reloadWithSubstitutionsToolStripMenuItem
            // 
            this.reloadWithSubstitutionsToolStripMenuItem.Name = "reloadWithSubstitutionsToolStripMenuItem";
            this.reloadWithSubstitutionsToolStripMenuItem.Size = new System.Drawing.Size(207, 22);
            this.reloadWithSubstitutionsToolStripMenuItem.Text = "Reload with substitutions";
            this.reloadWithSubstitutionsToolStripMenuItem.Click += new System.EventHandler(this.reloadWithSubstitutionsToolStripMenuItem_Click);
            // 
            // exportBindingsToolStripMenuItem
            // 
            this.exportBindingsToolStripMenuItem.Name = "exportBindingsToolStripMenuItem";
            this.exportBindingsToolStripMenuItem.Size = new System.Drawing.Size(207, 22);
            this.exportBindingsToolStripMenuItem.Text = "Export bindings";
            this.exportBindingsToolStripMenuItem.Click += new System.EventHandler(this.exportBindingsToolStripMenuItem_Click);
            // 
            // clearAllToolStripMenuItem
            // 
            this.clearAllToolStripMenuItem.Name = "clearAllToolStripMenuItem";
            this.clearAllToolStripMenuItem.Size = new System.Drawing.Size(207, 22);
            this.clearAllToolStripMenuItem.Text = "Clear all";
            this.clearAllToolStripMenuItem.Click += new System.EventHandler(this.clearAllToolStripMenuItem_Click);
            // 
            // treeView1
            // 
            this.treeView1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.treeView1.ContextMenuStrip = this.contextMenuStripTreeNodes;
            this.treeView1.Location = new System.Drawing.Point(12, 76);
            this.treeView1.Name = "treeView1";
            this.treeView1.Size = new System.Drawing.Size(584, 334);
            this.treeView1.TabIndex = 9;
            // 
            // FormMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(599, 413);
            this.Controls.Add(this.treeView1);
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
            this.Text = "Port Binding Editor 2.0.0";
            this.contextMenuStripTreeNodes.ResumeLayout(false);
            this.menuStripMain.ResumeLayout(false);
            this.menuStripMain.PerformLayout();
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
        private System.Windows.Forms.ContextMenuStrip contextMenuStripTreeNodes;
        private System.Windows.Forms.ToolStripMenuItem filtersToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem transportTypeToolStripMenuItem;
        private System.Windows.Forms.MenuStrip menuStripMain;
        private System.Windows.Forms.ToolStripMenuItem importFromBindingFileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exportBindingsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem addressToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem handlerToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem deletePortToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem copyPortToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem pastePortToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem renamePortToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem pipelineDataToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem receiveToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem sendToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem reloadWithSubstitutionsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem clearAllToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem applicationToolStripMenuItem;
        private System.Windows.Forms.TreeView treeView1;
    }
}

