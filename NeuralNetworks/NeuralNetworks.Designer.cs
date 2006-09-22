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
            System.Windows.Forms.GroupBox groupBoxXOrNetRunning;
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(NeuralNetworks));
            this.checkBoxXOrNetResult = new System.Windows.Forms.CheckBox();
            this.textBoxXOrNetFloatResult = new System.Windows.Forms.TextBox();
            this.labelXOrNetEqual = new System.Windows.Forms.Label();
            this.checkBoxXOrNetValue2 = new System.Windows.Forms.CheckBox();
            this.labelXOrNetXOr = new System.Windows.Forms.Label();
            this.checkBoxXOrNetValue1 = new System.Windows.Forms.CheckBox();
            this.menuStrip = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.helpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tabPageXOrNet = new System.Windows.Forms.TabPage();
            this.panelXOrNetTraining = new System.Windows.Forms.Panel();
            this.groupBoxXOrNetTraining = new System.Windows.Forms.GroupBox();
            this.panelXOrNetTrainingPairs = new System.Windows.Forms.Panel();
            this.groupBoxXOrNetTrainingPairs = new System.Windows.Forms.GroupBox();
            this.listViewXOrNetTrainingPairs = new System.Windows.Forms.ListView();
            this.imageListLarge = new System.Windows.Forms.ImageList(this.components);
            this.imageListSmall = new System.Windows.Forms.ImageList(this.components);
            this.panelXOrNetTrainingValues = new System.Windows.Forms.Panel();
            this.textBoxXOrNetEpochs = new System.Windows.Forms.TextBox();
            this.labelXOrNetEpochs = new System.Windows.Forms.Label();
            this.textBoxXOrNetErrorValue = new System.Windows.Forms.TextBox();
            this.labelXOrNetErrorValue = new System.Windows.Forms.Label();
            this.panelXOrNetRunning = new System.Windows.Forms.Panel();
            this.panelXOrNetConfiguration = new System.Windows.Forms.Panel();
            this.groupBoxXOrNetConfiguration = new System.Windows.Forms.GroupBox();
            this.checkBoxXOrNetUseBias = new System.Windows.Forms.CheckBox();
            this.textBoxXOrNetTolerance = new System.Windows.Forms.TextBox();
            this.labelXOrNetTolerance = new System.Windows.Forms.Label();
            this.textBoxXOrNetLearningRate = new System.Windows.Forms.TextBox();
            this.labelXOrNetLearningRate = new System.Windows.Forms.Label();
            this.tabControl = new System.Windows.Forms.TabControl();
            this.timerTraining = new System.Windows.Forms.Timer(this.components);
            groupBoxXOrNetRunning = new System.Windows.Forms.GroupBox();
            groupBoxXOrNetRunning.SuspendLayout();
            this.menuStrip.SuspendLayout();
            this.tabPageXOrNet.SuspendLayout();
            this.panelXOrNetTraining.SuspendLayout();
            this.groupBoxXOrNetTraining.SuspendLayout();
            this.panelXOrNetTrainingPairs.SuspendLayout();
            this.groupBoxXOrNetTrainingPairs.SuspendLayout();
            this.panelXOrNetTrainingValues.SuspendLayout();
            this.panelXOrNetRunning.SuspendLayout();
            this.panelXOrNetConfiguration.SuspendLayout();
            this.groupBoxXOrNetConfiguration.SuspendLayout();
            this.tabControl.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBoxXOrNetRunning
            // 
            groupBoxXOrNetRunning.Controls.Add(this.checkBoxXOrNetResult);
            groupBoxXOrNetRunning.Controls.Add(this.textBoxXOrNetFloatResult);
            groupBoxXOrNetRunning.Controls.Add(this.labelXOrNetEqual);
            groupBoxXOrNetRunning.Controls.Add(this.checkBoxXOrNetValue2);
            groupBoxXOrNetRunning.Controls.Add(this.labelXOrNetXOr);
            groupBoxXOrNetRunning.Controls.Add(this.checkBoxXOrNetValue1);
            groupBoxXOrNetRunning.Dock = System.Windows.Forms.DockStyle.Fill;
            groupBoxXOrNetRunning.Location = new System.Drawing.Point(0, 0);
            groupBoxXOrNetRunning.Name = "groupBoxXOrNetRunning";
            groupBoxXOrNetRunning.Size = new System.Drawing.Size(578, 47);
            groupBoxXOrNetRunning.TabIndex = 0;
            groupBoxXOrNetRunning.TabStop = false;
            groupBoxXOrNetRunning.Text = "Running";
            // 
            // checkBoxXOrNetResult
            // 
            this.checkBoxXOrNetResult.AutoSize = true;
            this.checkBoxXOrNetResult.Enabled = false;
            this.checkBoxXOrNetResult.Location = new System.Drawing.Point(236, 19);
            this.checkBoxXOrNetResult.Name = "checkBoxXOrNetResult";
            this.checkBoxXOrNetResult.Size = new System.Drawing.Size(56, 17);
            this.checkBoxXOrNetResult.TabIndex = 5;
            this.checkBoxXOrNetResult.TabStop = false;
            this.checkBoxXOrNetResult.Text = "Result";
            this.checkBoxXOrNetResult.UseVisualStyleBackColor = true;
            // 
            // textBoxXOrNetFloatResult
            // 
            this.textBoxXOrNetFloatResult.Location = new System.Drawing.Point(182, 17);
            this.textBoxXOrNetFloatResult.Name = "textBoxXOrNetFloatResult";
            this.textBoxXOrNetFloatResult.ReadOnly = true;
            this.textBoxXOrNetFloatResult.Size = new System.Drawing.Size(48, 20);
            this.textBoxXOrNetFloatResult.TabIndex = 4;
            this.textBoxXOrNetFloatResult.TabStop = false;
            // 
            // labelXOrNetEqual
            // 
            this.labelXOrNetEqual.AutoSize = true;
            this.labelXOrNetEqual.Location = new System.Drawing.Point(163, 20);
            this.labelXOrNetEqual.Name = "labelXOrNetEqual";
            this.labelXOrNetEqual.Size = new System.Drawing.Size(13, 13);
            this.labelXOrNetEqual.TabIndex = 3;
            this.labelXOrNetEqual.Text = "=";
            // 
            // checkBoxXOrNetValue2
            // 
            this.checkBoxXOrNetValue2.AutoSize = true;
            this.checkBoxXOrNetValue2.Location = new System.Drawing.Point(104, 19);
            this.checkBoxXOrNetValue2.Name = "checkBoxXOrNetValue2";
            this.checkBoxXOrNetValue2.Size = new System.Drawing.Size(53, 17);
            this.checkBoxXOrNetValue2.TabIndex = 2;
            this.checkBoxXOrNetValue2.Text = "Value";
            this.checkBoxXOrNetValue2.UseVisualStyleBackColor = true;
            this.checkBoxXOrNetValue2.Click += new System.EventHandler(this.checkBoxXOrNetValue_Click);
            // 
            // labelXOrNetXOr
            // 
            this.labelXOrNetXOr.AutoSize = true;
            this.labelXOrNetXOr.Location = new System.Drawing.Point(68, 20);
            this.labelXOrNetXOr.Name = "labelXOrNetXOr";
            this.labelXOrNetXOr.Size = new System.Drawing.Size(30, 13);
            this.labelXOrNetXOr.TabIndex = 1;
            this.labelXOrNetXOr.Text = "XOR";
            // 
            // checkBoxXOrNetValue1
            // 
            this.checkBoxXOrNetValue1.AutoSize = true;
            this.checkBoxXOrNetValue1.Checked = true;
            this.checkBoxXOrNetValue1.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBoxXOrNetValue1.Location = new System.Drawing.Point(9, 19);
            this.checkBoxXOrNetValue1.Name = "checkBoxXOrNetValue1";
            this.checkBoxXOrNetValue1.Size = new System.Drawing.Size(53, 17);
            this.checkBoxXOrNetValue1.TabIndex = 0;
            this.checkBoxXOrNetValue1.Text = "Value";
            this.checkBoxXOrNetValue1.UseVisualStyleBackColor = true;
            this.checkBoxXOrNetValue1.Click += new System.EventHandler(this.checkBoxXOrNetValue_Click);
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
            this.tabPageXOrNet.Controls.Add(this.panelXOrNetRunning);
            this.tabPageXOrNet.Controls.Add(this.panelXOrNetConfiguration);
            this.tabPageXOrNet.Location = new System.Drawing.Point(4, 22);
            this.tabPageXOrNet.Name = "tabPageXOrNet";
            this.tabPageXOrNet.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageXOrNet.Size = new System.Drawing.Size(584, 396);
            this.tabPageXOrNet.TabIndex = 0;
            this.tabPageXOrNet.Text = "XOrNet";
            this.tabPageXOrNet.UseVisualStyleBackColor = true;
            // 
            // panelXOrNetTraining
            // 
            this.panelXOrNetTraining.Controls.Add(this.groupBoxXOrNetTraining);
            this.panelXOrNetTraining.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelXOrNetTraining.Location = new System.Drawing.Point(3, 101);
            this.panelXOrNetTraining.Name = "panelXOrNetTraining";
            this.panelXOrNetTraining.Size = new System.Drawing.Size(578, 245);
            this.panelXOrNetTraining.TabIndex = 1;
            // 
            // groupBoxXOrNetTraining
            // 
            this.groupBoxXOrNetTraining.Controls.Add(this.panelXOrNetTrainingPairs);
            this.groupBoxXOrNetTraining.Controls.Add(this.panelXOrNetTrainingValues);
            this.groupBoxXOrNetTraining.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBoxXOrNetTraining.Location = new System.Drawing.Point(0, 0);
            this.groupBoxXOrNetTraining.Name = "groupBoxXOrNetTraining";
            this.groupBoxXOrNetTraining.Size = new System.Drawing.Size(578, 245);
            this.groupBoxXOrNetTraining.TabIndex = 0;
            this.groupBoxXOrNetTraining.TabStop = false;
            this.groupBoxXOrNetTraining.Text = "Training";
            // 
            // panelXOrNetTrainingPairs
            // 
            this.panelXOrNetTrainingPairs.Controls.Add(this.groupBoxXOrNetTrainingPairs);
            this.panelXOrNetTrainingPairs.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelXOrNetTrainingPairs.Location = new System.Drawing.Point(3, 73);
            this.panelXOrNetTrainingPairs.Name = "panelXOrNetTrainingPairs";
            this.panelXOrNetTrainingPairs.Size = new System.Drawing.Size(572, 169);
            this.panelXOrNetTrainingPairs.TabIndex = 1;
            // 
            // groupBoxXOrNetTrainingPairs
            // 
            this.groupBoxXOrNetTrainingPairs.Controls.Add(this.listViewXOrNetTrainingPairs);
            this.groupBoxXOrNetTrainingPairs.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBoxXOrNetTrainingPairs.Location = new System.Drawing.Point(0, 0);
            this.groupBoxXOrNetTrainingPairs.Name = "groupBoxXOrNetTrainingPairs";
            this.groupBoxXOrNetTrainingPairs.Size = new System.Drawing.Size(572, 169);
            this.groupBoxXOrNetTrainingPairs.TabIndex = 0;
            this.groupBoxXOrNetTrainingPairs.TabStop = false;
            this.groupBoxXOrNetTrainingPairs.Text = "Training pairs";
            // 
            // listViewXOrNetTrainingPairs
            // 
            this.listViewXOrNetTrainingPairs.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listViewXOrNetTrainingPairs.FullRowSelect = true;
            this.listViewXOrNetTrainingPairs.GridLines = true;
            this.listViewXOrNetTrainingPairs.LargeImageList = this.imageListLarge;
            this.listViewXOrNetTrainingPairs.Location = new System.Drawing.Point(3, 16);
            this.listViewXOrNetTrainingPairs.Name = "listViewXOrNetTrainingPairs";
            this.listViewXOrNetTrainingPairs.Size = new System.Drawing.Size(566, 150);
            this.listViewXOrNetTrainingPairs.SmallImageList = this.imageListSmall;
            this.listViewXOrNetTrainingPairs.TabIndex = 0;
            this.listViewXOrNetTrainingPairs.UseCompatibleStateImageBehavior = false;
            this.listViewXOrNetTrainingPairs.View = System.Windows.Forms.View.Details;
            // 
            // imageListLarge
            // 
            this.imageListLarge.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageListLarge.ImageStream")));
            this.imageListLarge.TransparentColor = System.Drawing.Color.Transparent;
            this.imageListLarge.Images.SetKeyName(0, "Training.bmp");
            // 
            // imageListSmall
            // 
            this.imageListSmall.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageListSmall.ImageStream")));
            this.imageListSmall.TransparentColor = System.Drawing.Color.Transparent;
            this.imageListSmall.Images.SetKeyName(0, "Training.bmp");
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
            // textBoxXOrNetEpochs
            // 
            this.textBoxXOrNetEpochs.Location = new System.Drawing.Point(78, 27);
            this.textBoxXOrNetEpochs.Name = "textBoxXOrNetEpochs";
            this.textBoxXOrNetEpochs.ReadOnly = true;
            this.textBoxXOrNetEpochs.Size = new System.Drawing.Size(48, 20);
            this.textBoxXOrNetEpochs.TabIndex = 3;
            this.textBoxXOrNetEpochs.TabStop = false;
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
            // textBoxXOrNetErrorValue
            // 
            this.textBoxXOrNetErrorValue.Location = new System.Drawing.Point(78, 0);
            this.textBoxXOrNetErrorValue.Name = "textBoxXOrNetErrorValue";
            this.textBoxXOrNetErrorValue.ReadOnly = true;
            this.textBoxXOrNetErrorValue.Size = new System.Drawing.Size(48, 20);
            this.textBoxXOrNetErrorValue.TabIndex = 1;
            this.textBoxXOrNetErrorValue.TabStop = false;
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
            // panelXOrNetRunning
            // 
            this.panelXOrNetRunning.Controls.Add(groupBoxXOrNetRunning);
            this.panelXOrNetRunning.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panelXOrNetRunning.Location = new System.Drawing.Point(3, 346);
            this.panelXOrNetRunning.Name = "panelXOrNetRunning";
            this.panelXOrNetRunning.Size = new System.Drawing.Size(578, 47);
            this.panelXOrNetRunning.TabIndex = 2;
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
            // timerTraining
            // 
            this.timerTraining.Tick += new System.EventHandler(this.timerTraining_Tick);
            // 
            // NeuralNetworks
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(592, 446);
            this.Controls.Add(this.tabControl);
            this.Controls.Add(this.menuStrip);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip;
            this.Name = "NeuralNetworks";
            this.Text = "Neural Networks";
            groupBoxXOrNetRunning.ResumeLayout(false);
            groupBoxXOrNetRunning.PerformLayout();
            this.menuStrip.ResumeLayout(false);
            this.menuStrip.PerformLayout();
            this.tabPageXOrNet.ResumeLayout(false);
            this.panelXOrNetTraining.ResumeLayout(false);
            this.groupBoxXOrNetTraining.ResumeLayout(false);
            this.panelXOrNetTrainingPairs.ResumeLayout(false);
            this.groupBoxXOrNetTrainingPairs.ResumeLayout(false);
            this.panelXOrNetTrainingValues.ResumeLayout(false);
            this.panelXOrNetTrainingValues.PerformLayout();
            this.panelXOrNetRunning.ResumeLayout(false);
            this.panelXOrNetConfiguration.ResumeLayout(false);
            this.groupBoxXOrNetConfiguration.ResumeLayout(false);
            this.groupBoxXOrNetConfiguration.PerformLayout();
            this.tabControl.ResumeLayout(false);
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
        private System.Windows.Forms.ImageList imageListSmall;
        private System.Windows.Forms.ImageList imageListLarge;
        private System.Windows.Forms.Panel panelXOrNetRunning;
        private System.Windows.Forms.CheckBox checkBoxXOrNetValue1;
        private System.Windows.Forms.Label labelXOrNetXOr;
        private System.Windows.Forms.CheckBox checkBoxXOrNetValue2;
        private System.Windows.Forms.TextBox textBoxXOrNetFloatResult;
        private System.Windows.Forms.Label labelXOrNetEqual;
        private System.Windows.Forms.CheckBox checkBoxXOrNetResult;
    }
}

