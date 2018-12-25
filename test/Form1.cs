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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        string filePath = "";
        private void button1_Click(object sender, EventArgs e)
        {
            //创建文件弹出选择窗口（包括文件名）对象
            OpenFileDialog ofd = new OpenFileDialog();
            //判断选择的路径
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                this.textBox1.Text = ofd.FileName.ToString();
            }
            filePath = this.textBox1.Text;
        }
    }
}
