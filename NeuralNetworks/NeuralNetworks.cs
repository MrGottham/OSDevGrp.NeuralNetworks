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
        private IntBackpropagation _Backpropagation = null;

        public NeuralNetworks()
        {
            InitializeComponent();
            try
            {
                System.Collections.Generic.List<uint> neurons = new System.Collections.Generic.List<uint>();
                neurons.Add(2);
                neurons.Add(3);
                neurons.Add(1);
                _Backpropagation = new IntBackpropagation(neurons);
            }
            catch (System.Exception ex)
            {
                throw ex;
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
    }
}