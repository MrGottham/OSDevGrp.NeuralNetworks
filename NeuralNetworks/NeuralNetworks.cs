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

        public NeuralNetworks() : base()
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
                this.textBoxEstimateNetEpochs.DataBindings.Add(new System.Windows.Forms.Binding("Text", _EstimateNet, "Epochs", true, System.Windows.Forms.DataSourceUpdateMode.Never));
                UpdateEstimateNetTrainingPairs();
                int width_groupboxes = 0, width = 0;
                for (int i = 0; i < 5; i++)
                {
                    System.Windows.Forms.GroupBox groupbox = (System.Windows.Forms.GroupBox) this.groupBoxEstimateNetRunning.Controls["groupBoxEstimateNetCategory" + (i + 1).ToString()];
                    if (_EstimateNet.InputCategories.Count > i)
                    {
                        groupbox.Text = _EstimateNet.InputCategories[i].Name;
                        groupbox.Tag =  _EstimateNet.InputCategories[i];
                        width = 0;
                        for (int j = 0; j < 4; j++)
                        {
                            System.Windows.Forms.RadioButton radiobutton = (System.Windows.Forms.RadioButton) this.groupBoxEstimateNetRunning.Controls["groupBoxEstimateNetCategory" + (i + 1).ToString()].Controls["radioButtonEstimateNetInput" + (i + 1).ToString() + (j + 1).ToString()];
                            if (_EstimateNet.InputCategories[i].InputValues.Count > j)
                            {
                                radiobutton.Text = _EstimateNet.InputCategories[i].InputValues[j].Name;
                                radiobutton.Tag = _EstimateNet.InputCategories[i].InputValues[j];
                                radiobutton.Click += new EventHandler(radioButtonEstimateNetInput_Click);
                                if (_EstimateNet.InputCategories[i].SelectedInputValue == _EstimateNet.InputCategories[i].InputValues[j])
                                    radiobutton.Checked = true;
                                if (radiobutton.Size.Width > width)
                                    width = radiobutton.Size.Width + 8;
                                radiobutton.Click += new EventHandler(radioButtonEstimateNetInput_Click);
                            }
                            else
                                radiobutton.Hide();
                        }
                        groupbox.Size = new System.Drawing.Size(width, groupbox.Size.Height);
                        width_groupboxes += groupbox.Size.Width;
                    }
                    else
                        groupbox.Hide();
                }
                this.groupBoxEstimateNetOutput.Dock = System.Windows.Forms.DockStyle.Left;
                this.groupBoxEstimateNetOutput.Text = _EstimateNet.Output.Name;
                width = 0;
                for (int i = 0; i < 5; i++)
                {
                    System.Windows.Forms.CheckBox checkbox = (System.Windows.Forms.CheckBox) this.groupBoxEstimateNetOutput.Controls["checkBoxEstimateNetOutput" + (i + 1).ToString()];
                    if (_EstimateNet.Output.OutputValues.Count > i)
                    {
                        checkbox.Text = _EstimateNet.Output.OutputValues[i].Name;
                        checkbox.Tag = _EstimateNet.Output.OutputValues[i];
                        if (checkbox.Size.Width > width)
                            width = checkbox.Size.Width + 8;
                        checkbox.DataBindings.Add(new System.Windows.Forms.Binding("Checked", _EstimateNet.Output.OutputValues[i], "Checked", true, System.Windows.Forms.DataSourceUpdateMode.Never));
                    }
                    else
                        checkbox.Hide();
                }
                this.groupBoxEstimateNetOutput.Size = new System.Drawing.Size(width, this.groupBoxEstimateNetOutput.Size.Height);
                width_groupboxes += this.groupBoxEstimateNetOutput.Size.Width;
                this.groupBoxEstimateNetOutput.Dock = System.Windows.Forms.DockStyle.Fill;
                if (width_groupboxes > this.Size.Width)
                {
                    int pct = ((width_groupboxes * 100) / this.Size.Width) + 5;
                    this.Size = new System.Drawing.Size((this.Size.Width * pct) / 100, (this.Size.Height * pct) / 100);
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
                    if (XOrNet.Epochs == 0 || XOrNet.Error > XOrNet.Tolerance)
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
                if (EstimateNet != null)
                {
                    if (EstimateNet.Epochs == 0 || EstimateNet.Error > EstimateNet.Tolerance)
                    {
                        double d = EstimateNet.Train();
                        EstimateNetOutput output = EstimateNet.Run();
                        foreach (System.Windows.Forms.Binding binding in this.textBoxEstimateNetErrorValue.DataBindings)
                            binding.ReadValue();
                        foreach (System.Windows.Forms.Binding binding in this.textBoxEstimateNetEpochs.DataBindings)
                            binding.ReadValue();
                        for (int i = 0; i < 5; i++)
                        {
                            System.Windows.Forms.CheckBox checkbox = (System.Windows.Forms.CheckBox) this.groupBoxEstimateNetOutput.Controls["checkBoxEstimateNetOutput" + (i + 1).ToString()];
                            foreach (System.Windows.Forms.Binding binding in checkbox.DataBindings)
                                binding.ReadValue();
                        }
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

        private void UpdateEstimateNetTrainingPairs()
        {
            try
            {
                this.listViewEstimateNetTrainingPairs.Clear();
                foreach (EstimateNetTrianPair trainpair in EstimateNet.TrainPairs)
                {
                    if (this.listViewEstimateNetTrainingPairs.Columns.Count == 0)
                    {
                        System.Windows.Forms.ColumnHeader ch = new System.Windows.Forms.ColumnHeader();
                        ch.Text = "";
                        ch.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
                        this.listViewEstimateNetTrainingPairs.Columns.Add(ch);
                        foreach (EstimateNetInputCategory category in EstimateNet.InputCategories)
                        {
                            ch = new System.Windows.Forms.ColumnHeader();
                            ch.Text = category.Name;
                            ch.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
                            this.listViewEstimateNetTrainingPairs.Columns.Add(ch);
                        }
                        ch = new System.Windows.Forms.ColumnHeader();
                        ch.Text = EstimateNet.Output.Name;
                        ch.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
                        this.listViewEstimateNetTrainingPairs.Columns.Add(ch);
                    }
                    System.Windows.Forms.ListViewItem lvi = new System.Windows.Forms.ListViewItem("Training pair", 0);
                    foreach (EstimateNetInputValue inputvalue in trainpair.Sources)
                    {
                        if (lvi.SubItems.Count < this.listViewEstimateNetTrainingPairs.Columns.Count - 1)
                            lvi.SubItems.Add(new System.Windows.Forms.ListViewItem.ListViewSubItem(lvi, inputvalue.Name));
                    }
                    while (lvi.SubItems.Count < this.listViewEstimateNetTrainingPairs.Columns.Count - 1)
                        lvi.SubItems.Add(new System.Windows.Forms.ListViewItem.ListViewSubItem(lvi, String.Empty));
                    string s = string.Empty;
                    foreach (EstimateNetOutputValue outputvalue in trainpair.Targets)
                    {
                        if (outputvalue.Checked)
                        {
                            if (s.Length > 0)
                                s = s + '\n';
                            s = s + outputvalue.Name;
                        }
                    }
                    int p = s.LastIndexOf('\n');
                    if (p >= 0)
                    {
                        s = s.Substring(0, p) + " and " + s.Substring(p + 1);
                        while ((p = s.LastIndexOf('\n')) >= 0)
                            s = s.Substring(0, p) + ", " + s.Substring(p + 1);
                    }
                    lvi.SubItems.Add(new System.Windows.Forms.ListViewItem.ListViewSubItem(lvi, s));
                    lvi.Tag = trainpair;
                    this.listViewEstimateNetTrainingPairs.Items.Add(lvi);
                }
                foreach (System.Windows.Forms.ColumnHeader ch in this.listViewEstimateNetTrainingPairs.Columns)
                    ch.AutoResize(System.Windows.Forms.ColumnHeaderAutoResizeStyle.HeaderSize);
                this.buttonEstimateNetTrainingCreate.Enabled = true;
                this.buttonEstimateNetTrainingModify.Enabled = this.listViewEstimateNetTrainingPairs.SelectedItems.Count > 0;
                this.buttonEstimateNetTrainingDelete.Enabled = this.listViewEstimateNetTrainingPairs.SelectedItems.Count > 0;
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

        private void listViewEstimateNetTrainingPairs_ItemSelectionChanged(object sender, ListViewItemSelectionChangedEventArgs e)
        {
            try
            {
                this.buttonEstimateNetTrainingModify.Enabled = this.listViewEstimateNetTrainingPairs.SelectedItems.Count > 0;
                this.buttonEstimateNetTrainingDelete.Enabled = this.listViewEstimateNetTrainingPairs.SelectedItems.Count > 0;
            }
            catch (System.Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(this, ex.Message, "Information", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Information);
            }
        }

        private void buttonEstimateNetTrainingCreate_Click(object sender, EventArgs e)
        {
            try
            {
                EstimateNetTrianPair trainpair = EstimateNet.TrainPairs.Create();
                EstimateNetTrainPairModifier modifier = new EstimateNetTrainPairModifier(trainpair);
                if (modifier.ShowDialog(this) == System.Windows.Forms.DialogResult.OK)
                {
                }
                modifier.Dispose();
            }
            catch (System.Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(this, ex.Message, "Information", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Information);
            }
        }

        private void buttonEstimateNetTrainingModify_Click(object sender, EventArgs e)
        {
            try
            {
                throw new System.NotImplementedException();
            }
            catch (System.Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(this, ex.Message, "Information", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Information);
            }
        }

        private void buttonEstimateNetTrainingDelete_Click(object sender, EventArgs e)
        {
            try
            {
                throw new System.NotImplementedException();
            }
            catch (System.Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(this, ex.Message, "Information", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Information);
            }
        }

        private void radioButtonEstimateNetInput_Click(object sender, EventArgs e)
        {
            try
            {
                if (sender is System.Windows.Forms.RadioButton)
                {
                    System.Windows.Forms.RadioButton radiobutton = (System.Windows.Forms.RadioButton) sender;
                    if (radiobutton.Tag is EstimateNetInputValue)
                    {
                        if (radiobutton.Parent is System.Windows.Forms.GroupBox)
                        {
                            System.Windows.Forms.GroupBox groupbox = (System.Windows.Forms.GroupBox) radiobutton.Parent;
                            if (groupbox.Tag is EstimateNetInputCategory)
                            {
                                ((EstimateNetInputCategory) groupbox.Tag).SelectedInputValue = (EstimateNetInputValue) radiobutton.Tag;
                                EstimateNetOutput output = EstimateNet.Run();
                                for (int i = 0; i < 5; i ++)
                                {
                                    System.Windows.Forms.CheckBox checkbox = (System.Windows.Forms.CheckBox) this.groupBoxEstimateNetOutput.Controls["checkBoxEstimateNetOutput" + (i + 1).ToString()];
                                    foreach (System.Windows.Forms.Binding binding in checkbox.DataBindings)
                                        binding.ReadValue();
                                }
                            }
                        }
                    }
                }
            }
            catch (System.Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(this, ex.Message, "Information", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Information);
            }
        }
    }
}