using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace OSDevGrp.NeuralNetworks
{
    public partial class EstimateNetTrainPairModifier : Form
    {
        private EstimateNetTrianPair _TrainPair = null;

        public EstimateNetTrainPairModifier(EstimateNetTrianPair trainpair)
        {
            InitializeComponent();
            try
            {
                TrainPair = trainpair;
                this.DialogResult = System.Windows.Forms.DialogResult.Cancel;
                for (int i = System.Math.Min(trainpair.EstimateNet.InputCategories.Count, trainpair.Sources.Count) - 1; i >= 0; i--)
                {
                    System.Windows.Forms.GroupBox groupbox = new System.Windows.Forms.GroupBox();
                    this.groupBoxInput.Controls.Add(groupbox);
                    groupbox.Name = "groupBoxCategory" + (i + 1).ToString();
                    groupbox.Text = trainpair.EstimateNet.InputCategories[i].Name;
                    groupbox.TabIndex = i;
                    groupbox.Dock = System.Windows.Forms.DockStyle.Left;
                    int xpos = 6, ypos = 19, width = 0;
                    for (int j = 0; j < trainpair.EstimateNet.InputCategories[i].InputValues.Count; j++)
                    {
                        System.Windows.Forms.RadioButton radiobutton = new System.Windows.Forms.RadioButton();
                        groupbox.Controls.Add(radiobutton);
                        radiobutton.Name = "radioButtonInputValue" + (i + 1).ToString() + (j + 1).ToString();
                        radiobutton.Text = trainpair.EstimateNet.InputCategories[i].InputValues[j].Name;
                        radiobutton.TabIndex = j;
                        radiobutton.AutoSize = true;
                        radiobutton.Location = new System.Drawing.Point(xpos, ypos);
                        if (radiobutton.Size.Width > width)
                            width = radiobutton.Size.Width + 8;
                        radiobutton.Show();
                        ypos += radiobutton.Size.Height + 6;
                    }
                    groupbox.Size = new System.Drawing.Size(width, groupbox.Size.Height);
                    groupbox.Show();
                    if (ypos + 20 > this.panelInput.Height)
                        this.panelInput.Size = new Size(this.panelInput.Size.Width, ypos + 20);
                }
//                if (this.
            }
            catch (System.Exception ex)
            {
                throw ex;
            }
        }

        public EstimateNetTrianPair TrainPair
        {
            get
            {
                return _TrainPair;
            }
            private set
            {
                _TrainPair = value;
            }
        }

        private void buttonOK_Click(object sender, EventArgs e)
        {
            this.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.Close();
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.Close();
        }
    }
}