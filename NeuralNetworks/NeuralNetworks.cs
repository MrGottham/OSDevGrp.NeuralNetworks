using System;
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
                this.textBoxXOrNetLearningRate.DataBindings.Add(new System.Windows.Forms.Binding("Text", _XOrNet, "LearningRate"));
                this.textBoxXOrNetTolerance.DataBindings.Add(new System.Windows.Forms.Binding("Text", _XOrNet, "Tolerance"));
                this.checkBoxXOrNetUseBias.DataBindings.Add(new System.Windows.Forms.Binding("Checked", _XOrNet, "UseBias"));
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
            XOrNet.ReTrain();
        }

        private void checkBoxXOrNetUseBias_Click(object sender, EventArgs e)
        {
            XOrNet.ReTrain();
        }
    }
}