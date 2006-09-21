﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace OSDevGrp.NeuralNetworks
{
    public partial class NeuralNetworks : Form
    {
        private XOrNet _XOrNet = null;

        public NeuralNetworks()
        {
            InitializeComponent();
            try
            {
                _XOrNet = new XOrNet();
                this.textBoxXOrNetLearningRate.DataBindings.Add(new System.Windows.Forms.Binding("Text", _XOrNet, "LearningRate", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
                this.textBoxXOrNetTolerance.DataBindings.Add(new System.Windows.Forms.Binding("Text", _XOrNet, "Tolerance", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
                this.checkBoxXOrNetUseBias.DataBindings.Add(new System.Windows.Forms.Binding("Checked", _XOrNet, "UseBias", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
                this.textBoxXOrNetErrorValue.DataBindings.Add(new System.Windows.Forms.Binding("Text", _XOrNet, "Error", true, System.Windows.Forms.DataSourceUpdateMode.Never));
                this.textBoxXOrNetEpochs.DataBindings.Add(new System.Windows.Forms.Binding("Text", _XOrNet, "Epochs", true, System.Windows.Forms.DataSourceUpdateMode.Never));
                foreach(System.Collections.Generic.List<int> source in _XOrNet.TrainPairs.Sources)
                {
                    this.listViewXOrNetTrainingPairs.Items.Add("Test");
                }
                this.timerTraining.Interval = 2500;
                this.timerTraining.Enabled = true;
            }
            catch (System.Exception ex)
            {
                throw ex;
            }
        }

        private XOrNet XOrNet
        {
            get
            {
                return _XOrNet;
            }
        }

        private void timerTraining_Tick(object sender, EventArgs e)
        {
            try
            {
                this.timerTraining.Enabled = false;
                if (XOrNet != null)
                {
                    if (XOrNet.Error > XOrNet.Tolerance)
                    {
                        double d = XOrNet.Train();
                    }
                    foreach (System.Windows.Forms.Binding binding in this.textBoxXOrNetErrorValue.DataBindings)
                        binding.ReadValue();
                    foreach (System.Windows.Forms.Binding binding in this.textBoxXOrNetEpochs.DataBindings)
                        binding.ReadValue();
                }
                this.timerTraining.Interval = 100;
                this.timerTraining.Enabled = true;
            }
            catch (System.Exception ex)
            {
                this.timerTraining.Enabled = false;
                System.Windows.Forms.MessageBox.Show(this, ex.Message, "Information", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Information);
            }
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            System.Windows.Forms.MessageBox.Show(this, this.ProductName + "\nVersion: " + this.ProductVersion + "\n\nDevelopment team:\n" + this.CompanyName, "About", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Information);
        }

        private void textBoxXOrNetLearningRate_TextChanged(object sender, EventArgs e)
        {
            try
            {
                XOrNet.ReTrain();
            }
            catch (System.Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(this, ex.Message, "Information", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Information);
            }
        }

        private void checkBoxXOrNetUseBias_Click(object sender, EventArgs e)
        {
            try
            {
                XOrNet.ReTrain();
            }
            catch (System.Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(this, ex.Message, "Information", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Information);
            }
        }
    }
}