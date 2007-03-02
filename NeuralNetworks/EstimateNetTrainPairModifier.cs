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

        public EstimateNetTrainPairModifier(EstimateNetTrianPair trainpair) : base()
        {
            InitializeComponent();
            try
            {
                TrainPair = trainpair;
                this.DialogResult = System.Windows.Forms.DialogResult.Cancel;
                this.panelInput.Size = new System.Drawing.Size(this.panelInput.Size.Width, 0);
                int width_groupboxes = 0;
                for (int i = System.Math.Min(trainpair.EstimateNet.InputCategories.Count, trainpair.Sources.Count) - 1; i >= 0; i--)
                {
                    System.Windows.Forms.GroupBox groupbox = new System.Windows.Forms.GroupBox();
                    this.groupBoxInput.Controls.Add(groupbox);
                    groupbox.Name = "groupBoxCategory" + (i + 1).ToString();
                    groupbox.Text = trainpair.EstimateNet.InputCategories[i].Name;
                    groupbox.TabIndex = i;
                    groupbox.Dock = System.Windows.Forms.DockStyle.Left;
                    groupbox.Tag = trainpair.EstimateNet.InputCategories[i];
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
                        radiobutton.Tag = trainpair.EstimateNet.InputCategories[i].InputValues[j];
                        if (trainpair.Sources[i].Value == trainpair.EstimateNet.InputCategories[i].InputValues[j].Value)
                            radiobutton.Checked = true;
                        radiobutton.Show();
                        ypos += radiobutton.Size.Height + 6;
                    }
                    groupbox.Size = new System.Drawing.Size(width, groupbox.Size.Height);
                    groupbox.Show();
                    width_groupboxes += groupbox.Size.Width;
                    if (ypos + 20 > this.panelInput.Height)
                        this.panelInput.Size = new Size(this.panelInput.Size.Width, ypos + 20);
                }
                if (this.groupBoxInput.Controls.Count > 0)
                {
                    this.groupBoxInput.Controls[0].Dock = System.Windows.Forms.DockStyle.Fill;
                }
                if (width_groupboxes > this.Size.Width)
                {
                    int pct = ((width_groupboxes * 100) / this.Size.Width) + 5;
                    this.Size = new System.Drawing.Size((this.Size.Width * pct) / 100, (this.Size.Height * pct) / 100);
                }
                this.groupBoxOutput.Text = this.groupBoxOutput.Text + ": " + trainpair.EstimateNet.Output.Name;
                for (int i = 0, xpos = 6, ypos = 19; i < System.Math.Min(trainpair.EstimateNet.Output.OutputValues.Count, trainpair.Targets.Count); i++)
                {
                    System.Windows.Forms.CheckBox checkbox = new System.Windows.Forms.CheckBox();
                    this.groupBoxOutput.Controls.Add(checkbox);
                    checkbox.Name = "checkBoxOutputValue" + (i + 1).ToString();
                    checkbox.Text = trainpair.EstimateNet.Output.OutputValues[i].Name;
                    checkbox.TabIndex = i;
                    checkbox.AutoSize = true;
                    checkbox.Location = new System.Drawing.Point(xpos, ypos);
                    checkbox.Tag = trainpair.EstimateNet.Output.OutputValues[i];
                    if (trainpair.Targets[i].Checked)
                        checkbox.Checked = true;
                    checkbox.Show();
                    ypos += checkbox.Size.Height;
                }
                if (this.groupBoxOutput.Controls.Count > 0)
                {
                    int delta = this.groupBoxOutput.Size.Height - (this.groupBoxOutput.Controls[this.groupBoxOutput.Controls.Count - 1].Location.Y + this.groupBoxOutput.Controls[this.groupBoxOutput.Controls.Count - 1].Size.Height + 6);
                    if (delta > 0)
                        this.Size = new System.Drawing.Size(this.Size.Width, this.Size.Height - delta);
                }
                this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
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
            try
            {
                for (int i = 0; i < this.groupBoxInput.Controls.Count; i++)
                {
                    if (this.groupBoxInput.Controls[i] is System.Windows.Forms.GroupBox)
                    {
                        for (int j = 0; j < this.groupBoxInput.Controls[i].Controls.Count; j++)
                        {
                            if (this.groupBoxInput.Controls[i].Controls[j] is System.Windows.Forms.RadioButton)
                            {
                                if (((System.Windows.Forms.RadioButton) this.groupBoxInput.Controls[i].Controls[j]).Checked)
                                    TrainPair.Sources[this.groupBoxInput.Controls[i].TabIndex] = (EstimateNetInputValue) this.groupBoxInput.Controls[i].Controls[j].Tag;
                            }
                        }
                    }
                }
                for (int i = 0; i < this.groupBoxOutput.Controls.Count; i++)
                {
                    if (this.groupBoxOutput.Controls[i] is System.Windows.Forms.CheckBox)
                    {
                        if (((System.Windows.Forms.CheckBox) this.groupBoxOutput.Controls[i]).Checked)
                            TrainPair.Targets[i].Value = TrainPair.EstimateNet.Sigmoid.UpperBound;
                        else if (TrainPair.EstimateNet.Sigmoid.LowerBound < 0)
                            TrainPair.Targets[i].Value = 0;
                        else
                            TrainPair.Targets[i].Value = TrainPair.EstimateNet.Sigmoid.LowerBound;
                    }
                }
                this.DialogResult = System.Windows.Forms.DialogResult.OK;
                this.Close();
            }
            catch (System.Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(this, ex.Message, "Information", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Information);
            }
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            try
            {
                this.DialogResult = System.Windows.Forms.DialogResult.Cancel;
                this.Close();
            }
            catch (System.Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(this, ex.Message, "Information", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Information);
            }
        }
    }
}