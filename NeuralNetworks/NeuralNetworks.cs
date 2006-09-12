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
    }
}