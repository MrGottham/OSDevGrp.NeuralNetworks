using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace OSDevGrp.NeuralNetworks
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            try
            {
                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);
                Application.Run(new NeuralNetworks());
            }
            catch (System.Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(null, ex.Message, "Error", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Error);
            }
        }
    }
}