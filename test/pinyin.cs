using BlueChips.RTQuote.Client;
using SchedulingOptimization.类库;
using System;
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
    public partial class pinyin : Form
    {
        public pinyin()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.textBox2.Text = FirstLetter.GetFristLetter(this.textBox1.Text);
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            this.textBox2.Text = FirstLetter.GetFristLetter(this.textBox1.Text);
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {
            string restr = "";
            string text3 = this.textBox3.Text;
            for (int i = 0; i < text3.Length;i++ )
            {
                int uni = (UInt16)text3[i];
                restr += uni + ",";
            }
            this.textBox4.Text = restr;
        }
    }
}
