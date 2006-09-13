namespace OSDevGrp.NeuralNetworks
{
    partial class NeuralNetworks
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
            this.menuStrip = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.helpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tabPageXOrNet = new System.Windows.Forms.TabPage();
            this.tabControl = new System.Windows.Forms.TabControl();
            this.panelXOrNetConfiguration = new System.Windows.Forms.Panel();
            this.groupBoxXOrNetConfiguration = new System.Windows.Forms.GroupBox();
            this.labelXOrNetLearningRate = new System.Windows.Forms.Label();
            this.textBoxXOrNetLearningRate = new System.Windows.Forms.TextBox();
            this.labelXOrNetTolerance = new System.Windows.Forms.Label();
            this.textBoxXOrNetTolerance = new System.Windows.Forms.TextBox();
            this.checkBoxXOrNetUseBias = new System.Windows.Forms.CheckBox();
            this.menuStrip.SuspendLayout();
            this.tabPageXOrNet.SuspendLayout();
            this.tabControl.SuspendLayout();
            this.panelXOrNetConfiguration.SuspendLayout();
            this.groupBoxXOrNetConfiguration.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip
            // 
            this.menuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.helpToolStripMenuItem});
            this.menuStrip.Location = new System.Drawing.Point(0, 0);
            this.menuStrip.Name = "menuStrip";
            this.menuStrip.Size = new System.Drawing.Size(592, 24);
            this.menuStrip.TabIndex = 0;
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.exitToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(35, 20);
            this.fileToolStripMenuItem.Text = "&File";
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(103, 22);
            this.exitToolStripMenuItem.Text = "&Exit";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
            // 
            // helpToolStripMenuItem
            // 
            this.helpToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.aboutToolStripMenuItem});
            this.helpToolStripMenuItem.Name = "helpToolStripMenuItem";
            this.helpToolStripMenuItem.Size = new System.Drawing.Size(40, 20);
            this.helpToolStripMenuItem.Text = "&Help";
            // 
            // aboutToolStripMenuItem
            // 
            this.aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
            this.aboutToolStripMenuItem.Size = new System.Drawing.Size(114, 22);
            this.aboutToolStripMenuItem.Text = "&About";
            this.aboutToolStripMenuItem.Click += new System.EventHandler(this.aboutToolStripMenuItem_Click);
            // 
            // tabPageXOrNet
            // 
            this.tabPageXOrNet.Controls.Add(this.panelXOrNetConfiguration);
            this.tabPageXOrNet.Location = new System.Drawing.Point(4, 22);
            this.tabPageXOrNet.Name = "tabPageXOrNet";
            this.tabPageXOrNet.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageXOrNet.Size = new System.Drawing.Size(584, 396);
            this.tabPageXOrNet.TabIndex = 0;
            this.tabPageXOrNet.Text = "XOrNet";
            this.tabPageXOrNet.UseVisualStyleBackColor = true;
            // 
            // tabControl
            // 
            this.tabControl.Controls.Add(this.tabPageXOrNet);
            this.tabControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl.Location = new System.Drawing.Point(0, 24);
            this.tabControl.Name = "tabControl";
            this.tabControl.SelectedIndex = 0;
            this.tabControl.Size = new System.Drawing.Size(592, 422);
            this.tabControl.TabIndex = 1;
            // 
            // panelXOrNetConfiguration
            // 
            this.panelXOrNetConfiguration.Controls.Add(this.groupBoxXOrNetConfiguration);
            this.panelXOrNetConfiguration.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelXOrNetConfiguration.Location = new System.Drawing.Point(3, 3);
            this.panelXOrNetConfiguration.Name = "panelXOrNetConfiguration";
            this.panelXOrNetConfiguration.Size = new System.Drawing.Size(578, 98);
            this.panelXOrNetConfiguration.TabIndex = 0;
            // 
            // groupBoxXOrNetConfiguration
            // 
            this.groupBoxXOrNetConfiguration.Controls.Add(this.checkBoxXOrNetUseBias);
            this.groupBoxXOrNetConfiguration.Controls.Add(this.textBoxXOrNetTolerance);
            this.groupBoxXOrNetConfiguration.Controls.Add(this.labelXOrNetTolerance);
            this.groupBoxXOrNetConfiguration.Controls.Add(this.textBoxXOrNetLearningRate);
            this.groupBoxXOrNetConfiguration.Controls.Add(this.labelXOrNetLearningRate);
            this.groupBoxXOrNetConfiguration.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBoxXOrNetConfiguration.Location = new System.Drawing.Point(0, 0);
            this.groupBoxXOrNetConfiguration.Name = "groupBoxXOrNetConfiguration";
            this.groupBoxXOrNetConfiguration.Size = new System.Drawing.Size(578, 98);
            this.groupBoxXOrNetConfiguration.TabIndex = 0;
            this.groupBoxXOrNetConfiguration.TabStop = false;
            this.groupBoxXOrNetConfiguration.Text = "Configuration";
            // 
            // labelXOrNetLearningRate
            // 
            this.labelXOrNetLearningRate.AutoSize = true;
            this.labelXOrNetLearningRate.Location = new System.Drawing.Point(6, 22);
            this.labelXOrNetLearningRate.Name = "labelXOrNetLearningRate";
            this.labelXOrNetLearningRate.Size = new System.Drawing.Size(69, 13);
            this.labelXOrNetLearningRate.TabIndex = 0;
            this.labelXOrNetLearningRate.Text = "Learning rate";
            // 
            // textBoxXOrNetLearningRate
            // 
            this.textBoxXOrNetLearningRate.Location = new System.Drawing.Point(81, 19);
            this.textBoxXOrNetLearningRate.Name = "textBoxXOrNetLearningRate";
            this.textBoxXOrNetLearningRate.Size = new System.Drawing.Size(36, 20);
            this.textBoxXOrNetLearningRate.TabIndex = 1;
            this.textBoxXOrNetLearningRate.TextChanged += new System.EventHandler(this.textBoxXOrNetLearningRate_TextChanged);
            // 
            // labelXOrNetTolerance
            // 
            this.labelXOrNetTolerance.AutoSize = true;
            this.labelXOrNetTolerance.Location = new System.Drawing.Point(6, 48);
            this.labelXOrNetTolerance.Name = "labelXOrNetTolerance";
            this.labelXOrNetTolerance.Size = new System.Drawing.Size(55, 13);
            this.labelXOrNetTolerance.TabIndex = 2;
            this.labelXOrNetTolerance.Text = "Tolerance";
            // 
            // textBoxXOrNetTolerance
            // 
            this.textBoxXOrNetTolerance.Location = new System.Drawing.Point(81, 45);
            this.textBoxXOrNetTolerance.Name = "textBoxXOrNetTolerance";
            this.textBoxXOrNetTolerance.Size = new System.Drawing.Size(36, 20);
            this.textBoxXOrNetTolerance.TabIndex = 3;
            // 
            // checkBoxXOrNetUseBias
            // 
            this.checkBoxXOrNetUseBias.AutoSize = true;
            this.checkBoxXOrNetUseBias.Location = new System.Drawing.Point(81, 71);
            this.checkBoxXOrNetUseBias.Name = "checkBoxXOrNetUseBias";
            this.checkBoxXOrNetUseBias.Size = new System.Drawing.Size(101, 17);
            this.checkBoxXOrNetUseBias.TabIndex = 4;
            this.checkBoxXOrNetUseBias.Text = "Use bias values";
            this.checkBoxXOrNetUseBias.UseVisualStyleBackColor = true;
            this.checkBoxXOrNetUseBias.Click += new System.EventHandler(this.checkBoxXOrNetUseBias_Click);
            // 
            // NeuralNetworks
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(592, 446);
            this.Controls.Add(this.tabControl);
            this.Controls.Add(this.menuStrip);
            this.MainMenuStrip = this.menuStrip;
            this.Name = "NeuralNetworks";
            this.Text = "Neural Networks";
            this.menuStrip.ResumeLayout(false);
            this.menuStrip.PerformLayout();
            this.tabPageXOrNet.ResumeLayout(false);
            this.tabControl.ResumeLayout(false);
            this.panelXOrNetConfiguration.ResumeLayout(false);
            this.groupBoxXOrNetConfiguration.ResumeLayout(false);
            this.groupBoxXOrNetConfiguration.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem helpToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem aboutToolStripMenuItem;
        private System.Windows.Forms.TabPage tabPageXOrNet;
        private System.Windows.Forms.TabControl tabControl;
        private System.Windows.Forms.Panel panelXOrNetConfiguration;
        private System.Windows.Forms.GroupBox groupBoxXOrNetConfiguration;
        private System.Windows.Forms.TextBox textBoxXOrNetLearningRate;
        private System.Windows.Forms.Label labelXOrNetLearningRate;
        private System.Windows.Forms.TextBox textBoxXOrNetTolerance;
        private System.Windows.Forms.Label labelXOrNetTolerance;
        private System.Windows.Forms.CheckBox checkBoxXOrNetUseBias;
    }
}

