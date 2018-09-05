using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace taipei_103_4
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (!checkInput())
                return;
            float a = float.Parse(textBox1.Text), b = float.Parse(textBox2.Text), c = float.Parse(textBox3.Text), d = float.Parse(textBox4.Text);
            float ans = a * c + b * (1 - d);
            textBox5.Text = $"通道輸出為 1 的機率為何： {ans}";

        }
       
        private void button2_Click(object sender, EventArgs e)
        {
            if (!checkInput())
                return;
            float a = float.Parse(textBox1.Text), b = float.Parse(textBox2.Text), c = float.Parse(textBox3.Text), d = float.Parse(textBox4.Text);
            //答案即為 輸入 1 又沒錯誤的機率 / 第一題答案
            textBox5.Text = $"假設我們已經觀察到通道輸出為1這時候通道的輸入為1的機率為何： { b*(1-d )/ (a * c + b * (1 - d))}";

        }
        bool checkInput()
        {
            float x = float.Parse(textBox1.Text);
            float y = float.Parse(textBox3.Text);
            float z = float.Parse(textBox4.Text);
            if (x < 0 | y < 0 | z < 0 | x > 1 | y > 1 | z > 1)
            {
                textBox5.Text = "無解";
                return false;
            }
            return true;
        }
    }
}
