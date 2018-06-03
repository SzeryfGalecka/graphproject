﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace graphproject
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            NUDsink.Maximum = NUDsource.Maximum = sfmLcanvas1.Graf.GetLength(0);
            NUDsink.Minimum = NUDsource.Minimum = 1;
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void restart_Click(object sender, EventArgs e)
        {
            sfmLcanvas1.StartSLMF();
        }

        private void bgenerate_Click(object sender, EventArgs e)
        {
            if (!GenGraphWorker.IsBusy)
                GenGraphWorker.RunWorkerAsync();
        }

        private void GenGraphWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            bgenerate.Enabled = false;
            try
            {
                sfmLcanvas1.Graf = GraphGenerator.Generate((int) NUPvcount.Value, CBdirected.Checked, CBmixed.Checked);
            }
            catch (Exception ex)
            {
                
            }
            NUDsink.Maximum = NUDsource.Maximum = sfmLcanvas1.Graf.GetLength(0);
            NUDsource.Value = 1;
            NUDsink.Value = 1;
            sfmLcanvas1.EdmondsKarpMode = false;
            bgenerate.Enabled = true;
        }

        private void EKbutton_Click(object sender, EventArgs e)
        {
            sfmLcanvas1.EdmondsKarpMode = !sfmLcanvas1.EdmondsKarpMode;
        }

        private void NUDsource_ValueChanged(object sender, EventArgs e)
        {
            sfmLcanvas1.Source = (int)NUDsource.Value - 1;
        }

        private void NUDsink_ValueChanged(object sender, EventArgs e)
        {
            sfmLcanvas1.Sink = (int)NUDsink.Value - 1;
        }
    }
}
