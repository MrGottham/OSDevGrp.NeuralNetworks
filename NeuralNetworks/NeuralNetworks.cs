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
        private EstimateNet _EstimateNet = null;

        public NeuralNetworks()
        {
            InitializeComponent();
            try
            {
                _XOrNet = new XOrNet();
                _EstimateNet = new EstimateNet();
                this.textBoxXOrNetLearningRate.Tag = _XOrNet;
                this.textBoxXOrNetLearningRate.DataBindings.Add(new System.Windows.Forms.Binding("Text", _XOrNet, "LearningRate", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
                this.textBoxXOrNetTolerance.DataBindings.Add(new System.Windows.Forms.Binding("Text", _XOrNet, "Tolerance", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
                this.checkBoxXOrNetUseBias.Tag = _XOrNet; 
                this.checkBoxXOrNetUseBias.DataBindings.Add(new System.Windows.Forms.Binding("Checked", _XOrNet, "UseBias", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
                this.textBoxXOrNetErrorValue.DataBindings.Add(new System.Windows.Forms.Binding("Text", _XOrNet, "Error", true, System.Windows.Forms.DataSourceUpdateMode.Never));
                this.textBoxXOrNetEpochs.DataBindings.Add(new System.Windows.Forms.Binding("Text", _XOrNet, "Epochs", true, System.Windows.Forms.DataSourceUpdateMode.Never));
                int no = 0;
                while (no < _XOrNet.TrainPairs.Sources.Count && no < _XOrNet.TrainPairs.Targets.Count)
                {
                    if (this.listViewXOrNetTrainingPairs.Columns.Count == 0)
                    {
                        System.Windows.Forms.ColumnHeader ch = new System.Windows.Forms.ColumnHeader();
                        ch.Text = "";
                        ch.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
                        this.listViewXOrNetTrainingPairs.Columns.Add(ch);
                        foreach (int i in _XOrNet.TrainPairs.Sources[no])
                        {
                            ch = new System.Windows.Forms.ColumnHeader();
                            ch.Text = "Value";
                            ch.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
                            this.listViewXOrNetTrainingPairs.Columns.Add(ch);
                        }
                        foreach (int i in _XOrNet.TrainPairs.Targets[no])
                        {
                            ch = new System.Windows.Forms.ColumnHeader();
                            ch.Text = "Result";
                            ch.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
                            this.listViewXOrNetTrainingPairs.Columns.Add(ch);
                        }
                        ch = new System.Windows.Forms.ColumnHeader();
                        ch.Text = "";
                        ch.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
                        this.listViewXOrNetTrainingPairs.Columns.Add(ch);
                    }
                    System.Windows.Forms.ListViewItem lvi = new System.Windows.Forms.ListViewItem("Training pair", 0);
                    foreach(int i in _XOrNet.TrainPairs.Sources[no])
                        lvi.SubItems.Add(new System.Windows.Forms.ListViewItem.ListViewSubItem(lvi, i.ToString()));
                    foreach (int i in _XOrNet.TrainPairs.Targets[no])
                        lvi.SubItems.Add(new System.Windows.Forms.ListViewItem.ListViewSubItem(lvi, i.ToString()));
                    this.listViewXOrNetTrainingPairs.Items.Add(lvi);
                    no++;
                }
                foreach (System.Windows.Forms.ColumnHeader ch in this.listViewXOrNetTrainingPairs.Columns)
                    ch.AutoResize(System.Windows.Forms.ColumnHeaderAutoResizeStyle.HeaderSize);
                this.textBoxXOrNetFloatResult.DataBindings.Add(new System.Windows.Forms.Binding("Text", _XOrNet, "FloatResult", true, System.Windows.Forms.DataSourceUpdateMode.Never));
                this.checkBoxXOrNetResult.DataBindings.Add(new System.Windows.Forms.Binding("Checked", _XOrNet, "BooleanResult", true, System.Windows.Forms.DataSourceUpdateMode.Never));
                this.textBoxEstimateNetLarningRate.Tag = _EstimateNet;
                this.textBoxEstimateNetLarningRate.DataBindings.Add(new System.Windows.Forms.Binding("Text", _EstimateNet, "LearningRate", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
                this.textBoxEstimateNetTolerance.DataBindings.Add(new System.Windows.Forms.Binding("Text", _EstimateNet, "Tolerance", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
                this.checkBoxEstimateNetUseBias.Tag = _EstimateNet;
                this.checkBoxEstimateNetUseBias.DataBindings.Add(new System.Windows.Forms.Binding("Checked", _EstimateNet, "UseBias", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
                this.textBoxEstimateNetErrorValue.DataBindings.Add(new System.Windows.Forms.Binding("Text", _EstimateNet, "Error", true, System.Windows.Forms.DataSourceUpdateMode.Never));
                this.textBoxEstimateNetEpochs.DataBindings.Add(new System.Windows.Forms.Binding("Text", _EstimateNet, "Error", true, System.Windows.Forms.DataSourceUpdateMode.Never));
                this.comboBoxEstimateNetCategory.BeginUpdate();
                this.comboBoxEstimateNetCategory.DataSource = _EstimateNet.InputCategories;
                this.comboBoxEstimateNetCategory.DisplayMember = "Name";
                this.comboBoxEstimateNetCategory.ValueMember = "This";
                this.comboBoxEstimateNetCategory.EndUpdate();
                if (this.comboBoxEstimateNetCategory.Items.Count > 0)
                {
                    this.comboBoxEstimateNetCategory.SelectedIndex = 0;

                    this.comboBoxEstimateNetValue.BeginUpdate();
                    this.comboBoxEstimateNetValue.DataSource = ((EstimateNetInputCategory) this.comboBoxEstimateNetCategory.SelectedValue).InputValues;
                    this.comboBoxEstimateNetValue.DisplayMember = "Name";
                    this.comboBoxEstimateNetValue.ValueMember = "This";
                    if (this.comboBoxEstimateNetValue.Items.Count > 0)
                        this.comboBoxEstimateNetValue.SelectedItem = ((EstimateNetInputCategory) this.comboBoxEstimateNetCategory.SelectedValue).SelectedInputValue;
                    this.comboBoxEstimateNetValue.EndUpdate();
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

        private EstimateNet EstimateNet
        {
            get
            {
                return _EstimateNet;
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
                        float f = XOrNet.Run(this.checkBoxXOrNetValue1.Checked, this.checkBoxXOrNetValue2.Checked);
                        foreach (System.Windows.Forms.Binding binding in this.textBoxXOrNetErrorValue.DataBindings)
                            binding.ReadValue();
                        foreach (System.Windows.Forms.Binding binding in this.textBoxXOrNetEpochs.DataBindings)
                            binding.ReadValue();
                        foreach (System.Windows.Forms.Binding binding in this.textBoxXOrNetFloatResult.DataBindings)
                            binding.ReadValue();
                        foreach (System.Windows.Forms.Binding binding in this.checkBoxXOrNetResult.DataBindings)
                            binding.ReadValue();
                    }
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

        private void textBoxLearningRate_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (sender.GetType() == typeof(System.Windows.Forms.TextBox))
                {
                    if (((System.Windows.Forms.TextBox) sender).Tag != null)
                    {
                        if (((System.Windows.Forms.TextBox) sender).Tag.GetType() == typeof(XOrNet))
                            XOrNet.ReTrain();
                        else if (((System.Windows.Forms.TextBox) sender).Tag.GetType() == typeof(EstimateNet))
                            EstimateNet.ReTrain();
                        else
                            throw new System.NotImplementedException();
                    }
                }
            }
            catch (System.Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(this, ex.Message, "Information", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Information);
            }
        }

        private void checkBoxUseBias_Click(object sender, EventArgs e)
        {
            try
            {
                if (sender.GetType() == typeof(System.Windows.Forms.CheckBox))
                {
                    if (((System.Windows.Forms.CheckBox) sender).Tag != null)
                    {
                        if (((System.Windows.Forms.CheckBox) sender).Tag.GetType() == typeof(XOrNet))
                            XOrNet.ReTrain();
                        else if (((System.Windows.Forms.CheckBox) sender).Tag.GetType() == typeof(EstimateNet))
                            EstimateNet.ReTrain();
                        else
                            throw new System.NotImplementedException();
                    }
                }
            }
            catch (System.Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(this, ex.Message, "Information", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Information);
            }
        }

        private void checkBoxXOrNetValue_Click(object sender, EventArgs e)
        {
            try
            {
                float f = XOrNet.Run(this.checkBoxXOrNetValue1.Checked, this.checkBoxXOrNetValue2.Checked);
                foreach (System.Windows.Forms.Binding binding in this.textBoxXOrNetFloatResult.DataBindings)
                    binding.ReadValue();
                foreach (System.Windows.Forms.Binding binding in this.checkBoxXOrNetResult.DataBindings)
                    binding.ReadValue();
            }
            catch (System.Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(this, ex.Message, "Information", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Information);
            }
        }

        private void comboBoxEstimateNetCategory_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                this.comboBoxEstimateNetValue.BeginUpdate();
                if (this.comboBoxEstimateNetValue.ValueMember.Length > 0)
                    this.comboBoxEstimateNetValue.ValueMember = "";
                this.comboBoxEstimateNetValue.DataSource = null;
                if (this.comboBoxEstimateNetCategory.SelectedIndex >= 0)
                {
                    this.comboBoxEstimateNetValue.DataSource = ((EstimateNetInputCategory) this.comboBoxEstimateNetCategory.SelectedValue).InputValues;
                    this.comboBoxEstimateNetValue.DisplayMember = "Name";
                    this.comboBoxEstimateNetValue.ValueMember = "This";
                    if (this.comboBoxEstimateNetValue.Items.Count > 0)
                        this.comboBoxEstimateNetValue.SelectedItem = ((EstimateNetInputCategory) this.comboBoxEstimateNetCategory.SelectedValue).SelectedInputValue;
                }
                this.comboBoxEstimateNetValue.EndUpdate();
            }
            catch (System.Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(this, ex.Message, "Information", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Information);
            }
        }

        private void comboBoxEstimateNetValue_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (this.comboBoxEstimateNetValue.ValueMember.Length > 0)
                {
                    if (this.comboBoxEstimateNetCategory.SelectedIndex >= 0)
                        ((EstimateNetInputCategory) this.comboBoxEstimateNetCategory.SelectedValue).SelectedInputValue = (EstimateNetInputValue) this.comboBoxEstimateNetValue.SelectedValue;
                }
            }
            catch (System.Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(this, ex.Message, "Information", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Information);
            }
        }
    }
}