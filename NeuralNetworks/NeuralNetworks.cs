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
                _Backpropagation.UseBias = true;

                System.Collections.Generic.List<int> source = new System.Collections.Generic.List<int>();
                source.Add(10);
                source.Add(20);

                System.Collections.Generic.List<int> target = new System.Collections.Generic.List<int>();
                target.Add(0);

                double d = 0;
                for (int i = 0; i < 3000; i++)
                    d = _Backpropagation.Train(source, target);

                System.Collections.Generic.List<float> r = _Backpropagation.Run(source);
                foreach (float f in r)
                    System.Windows.Forms.MessageBox.Show(f.ToString());
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