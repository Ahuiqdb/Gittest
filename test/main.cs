﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace test
{
    public partial class main : Form
    {
        public main()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form1 ff = new Form1();
            ff.ShowDialog(this);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            htmltoword hff = new htmltoword();
            hff.ShowDialog(this);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            pinyin pff = new pinyin();
            pff.ShowDialog(this);
        }
    }
}
