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
            this.components = new System.ComponentModel.Container();
            this.menuStrip = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.helpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tabPageXOrNet = new System.Windows.Forms.TabPage();
            this.panelXOrNetConfiguration = new System.Windows.Forms.Panel();
            this.groupBoxXOrNetConfiguration = new System.Windows.Forms.GroupBox();
            this.checkBoxXOrNetUseBias = new System.Windows.Forms.CheckBox();
            this.textBoxXOrNetTolerance = new System.Windows.Forms.TextBox();
            this.labelXOrNetTolerance = new System.Windows.Forms.Label();
            this.textBoxXOrNetLearningRate = new System.Windows.Forms.TextBox();
            this.labelXOrNetLearningRate = new System.Windows.Forms.Label();
            this.tabControl = new System.Windows.Forms.TabControl();
            this.panelXOrNetTraining = new System.Windows.Forms.Panel();
            this.groupBoxXOrNetTraining = new System.Windows.Forms.GroupBox();
            this.panelXOrNetTrainingValues = new System.Windows.Forms.Panel();
            this.labelXOrNetErrorValue = new System.Windows.Forms.Label();
            this.textBoxXOrNetErrorValue = new System.Windows.Forms.TextBox();
            this.labelXOrNetEpochs = new System.Windows.Forms.Label();
            this.textBoxXOrNetEpochs = new System.Windows.Forms.TextBox();
            this.timerTraining = new System.Windows.Forms.Timer(this.components);
            this.panelXOrNetTrainingPairs = new System.Windows.Forms.Panel();
            this.groupBoxXOrNetTrainingPairs = new System.Windows.Forms.GroupBox();
            this.listViewXOrNetTrainingPairs = new System.Windows.Forms.ListView();
            this.menuStrip.SuspendLayout();
            this.tabPageXOrNet.SuspendLayout();
            this.panelXOrNetConfiguration.SuspendLayout();
            this.groupBoxXOrNetConfiguration.SuspendLayout();
            this.tabControl.SuspendLayout();
            this.panelXOrNetTraining.SuspendLayout();
            this.groupBoxXOrNetTraining.SuspendLayout();
            this.panelXOrNetTrainingValues.SuspendLayout();
            this.panelXOrNetTrainingPairs.SuspendLayout();
            this.groupBoxXOrNetTrainingPairs.SuspendLayout();
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
            this.tabPageXOrNet.Controls.Add(this.panelXOrNetTraining);
            this.tabPageXOrNet.Controls.Add(this.panelXOrNetConfiguration);
            this.tabPageXOrNet.Location = new System.Drawing.Point(4, 22);
            this.tabPageXOrNet.Name = "tabPageXOrNet";
            this.tabPageXOrNet.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageXOrNet.Size = new System.Drawing.Size(584, 396);
            this.tabPageXOrNet.TabIndex = 0;
            this.tabPageXOrNet.Text = "XOrNet";
            this.tabPageXOrNet.UseVisualStyleBackColor = true;
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
            // textBoxXOrNetTolerance
            // 
            this.textBoxXOrNetTolerance.Location = new System.Drawing.Point(81, 45);
            this.textBoxXOrNetTolerance.Name = "textBoxXOrNetTolerance";
            this.textBoxXOrNetTolerance.Size = new System.Drawing.Size(48, 20);
            this.textBoxXOrNetTolerance.TabIndex = 3;
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
            // textBoxXOrNetLearningRate
            // 
            this.textBoxXOrNetLearningRate.Location = new System.Drawing.Point(81, 19);
            this.textBoxXOrNetLearningRate.Name = "textBoxXOrNetLearningRate";
            this.textBoxXOrNetLearningRate.Size = new System.Drawing.Size(48, 20);
            this.textBoxXOrNetLearningRate.TabIndex = 1;
            this.textBoxXOrNetLearningRate.TextChanged += new System.EventHandler(this.textBoxXOrNetLearningRate_TextChanged);
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
            // panelXOrNetTraining
            // 
            this.panelXOrNetTraining.Controls.Add(this.groupBoxXOrNetTraining);
            this.panelXOrNetTraining.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelXOrNetTraining.Location = new System.Drawing.Point(3, 101);
            this.panelXOrNetTraining.Name = "panelXOrNetTraining";
            this.panelXOrNetTraining.Size = new System.Drawing.Size(578, 292);
            this.panelXOrNetTraining.TabIndex = 1;
            // 
            // groupBoxXOrNetTraining
            // 
            this.groupBoxXOrNetTraining.Controls.Add(this.panelXOrNetTrainingPairs);
            this.groupBoxXOrNetTraining.Controls.Add(this.panelXOrNetTrainingValues);
            this.groupBoxXOrNetTraining.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBoxXOrNetTraining.Location = new System.Drawing.Point(0, 0);
            this.groupBoxXOrNetTraining.Name = "groupBoxXOrNetTraining";
            this.groupBoxXOrNetTraining.Size = new System.Drawing.Size(578, 292);
            this.groupBoxXOrNetTraining.TabIndex = 0;
            this.groupBoxXOrNetTraining.TabStop = false;
            this.groupBoxXOrNetTraining.Text = "Training";
            // 
            // panelXOrNetTrainingValues
            // 
            this.panelXOrNetTrainingValues.Controls.Add(this.textBoxXOrNetEpochs);
            this.panelXOrNetTrainingValues.Controls.Add(this.labelXOrNetEpochs);
            this.panelXOrNetTrainingValues.Controls.Add(this.textBoxXOrNetErrorValue);
            this.panelXOrNetTrainingValues.Controls.Add(this.labelXOrNetErrorValue);
            this.panelXOrNetTrainingValues.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelXOrNetTrainingValues.Location = new System.Drawing.Point(3, 16);
            this.panelXOrNetTrainingValues.Name = "panelXOrNetTrainingValues";
            this.panelXOrNetTrainingValues.Size = new System.Drawing.Size(572, 57);
            this.panelXOrNetTrainingValues.TabIndex = 0;
            // 
            // labelXOrNetErrorValue
            // 
            this.labelXOrNetErrorValue.AutoSize = true;
            this.labelXOrNetErrorValue.Location = new System.Drawing.Point(3, 3);
            this.labelXOrNetErrorValue.Name = "labelXOrNetErrorValue";
            this.labelXOrNetErrorValue.Size = new System.Drawing.Size(58, 13);
            this.labelXOrNetErrorValue.TabIndex = 0;
            this.labelXOrNetErrorValue.Text = "Error value";
            // 
            // textBoxXOrNetErrorValue
            // 
            this.textBoxXOrNetErrorValue.Location = new System.Drawing.Point(78, 0);
            this.textBoxXOrNetErrorValue.Name = "textBoxXOrNetErrorValue";
            this.textBoxXOrNetErrorValue.ReadOnly = true;
            this.textBoxXOrNetErrorValue.Size = new System.Drawing.Size(48, 20);
            this.textBoxXOrNetErrorValue.TabIndex = 1;
            this.textBoxXOrNetErrorValue.TabStop = false;
            // 
            // labelXOrNetEpochs
            // 
            this.labelXOrNetEpochs.AutoSize = true;
            this.labelXOrNetEpochs.Location = new System.Drawing.Point(3, 30);
            this.labelXOrNetEpochs.Name = "labelXOrNetEpochs";
            this.labelXOrNetEpochs.Size = new System.Drawing.Size(43, 13);
            this.labelXOrNetEpochs.TabIndex = 2;
            this.labelXOrNetEpochs.Text = "Epochs";
            // 
            // textBoxXOrNetEpochs
            // 
            this.textBoxXOrNetEpochs.Location = new System.Drawing.Point(78, 27);
            this.textBoxXOrNetEpochs.Name = "textBoxXOrNetEpochs";
            this.textBoxXOrNetEpochs.ReadOnly = true;
            this.textBoxXOrNetEpochs.Size = new System.Drawing.Size(48, 20);
            this.textBoxXOrNetEpochs.TabIndex = 3;
            this.textBoxXOrNetEpochs.TabStop = false;
            // 
            // timerTraining
            // 
            this.timerTraining.Tick += new System.EventHandler(this.timerTraining_Tick);
            // 
            // panelXOrNetTrainingPairs
            // 
            this.panelXOrNetTrainingPairs.Controls.Add(this.groupBoxXOrNetTrainingPairs);
            this.panelXOrNetTrainingPairs.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelXOrNetTrainingPairs.Location = new System.Drawing.Point(3, 73);
            this.panelXOrNetTrainingPairs.Name = "panelXOrNetTrainingPairs";
            this.panelXOrNetTrainingPairs.Size = new System.Drawing.Size(572, 216);
            this.panelXOrNetTrainingPairs.TabIndex = 1;
            // 
            // groupBoxXOrNetTrainingPairs
            // 
            this.groupBoxXOrNetTrainingPairs.Controls.Add(this.listViewXOrNetTrainingPairs);
            this.groupBoxXOrNetTrainingPairs.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBoxXOrNetTrainingPairs.Location = new System.Drawing.Point(0, 0);
            this.groupBoxXOrNetTrainingPairs.Name = "groupBoxXOrNetTrainingPairs";
            this.groupBoxXOrNetTrainingPairs.Size = new System.Drawing.Size(572, 216);
            this.groupBoxXOrNetTrainingPairs.TabIndex = 0;
            this.groupBoxXOrNetTrainingPairs.TabStop = false;
            this.groupBoxXOrNetTrainingPairs.Text = "Training pairs";
            // 
            // listViewXOrNetTrainingPairs
            // 
            this.listViewXOrNetTrainingPairs.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listViewXOrNetTrainingPairs.Location = new System.Drawing.Point(3, 16);
            this.listViewXOrNetTrainingPairs.Name = "listViewXOrNetTrainingPairs";
            this.listViewXOrNetTrainingPairs.Size = new System.Drawing.Size(566, 197);
            this.listViewXOrNetTrainingPairs.TabIndex = 0;
            this.listViewXOrNetTrainingPairs.UseCompatibleStateImageBehavior = false;
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
            this.panelXOrNetConfiguration.ResumeLayout(false);
            this.groupBoxXOrNetConfiguration.ResumeLayout(false);
            this.groupBoxXOrNetConfiguration.PerformLayout();
            this.tabControl.ResumeLayout(false);
            this.panelXOrNetTraining.ResumeLayout(false);
            this.groupBoxXOrNetTraining.ResumeLayout(false);
            this.panelXOrNetTrainingValues.ResumeLayout(false);
            this.panelXOrNetTrainingValues.PerformLayout();
            this.panelXOrNetTrainingPairs.ResumeLayout(false);
            this.groupBoxXOrNetTrainingPairs.ResumeLayout(false);
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
        private System.Windows.Forms.Panel panelXOrNetTraining;
        private System.Windows.Forms.GroupBox groupBoxXOrNetTraining;
        private System.Windows.Forms.Panel panelXOrNetTrainingValues;
        private System.Windows.Forms.TextBox textBoxXOrNetErrorValue;
        private System.Windows.Forms.Label labelXOrNetErrorValue;
        private System.Windows.Forms.TextBox textBoxXOrNetEpochs;
        private System.Windows.Forms.Label labelXOrNetEpochs;
        private System.Windows.Forms.Timer timerTraining;
        private System.Windows.Forms.Panel panelXOrNetTrainingPairs;
        private System.Windows.Forms.GroupBox groupBoxXOrNetTrainingPairs;
        private System.Windows.Forms.ListView listViewXOrNetTrainingPairs;
    }
}

