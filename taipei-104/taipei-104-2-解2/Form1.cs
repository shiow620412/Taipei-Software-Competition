using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Numerics;//需加入參考

namespace taipei_104_2_解2
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            List<TextBox> l = Controls.OfType<TextBox>().ToList();
            l.ForEach(x => x.Clear());
        }

        private void button1_Click(object sender, EventArgs e)
        {
            BigInteger num1 = BigInteger.Parse(textBox1.Text);
            BigInteger num2 = BigInteger.Parse(textBox2.Text);
            textBox3.Text = (num1 + num2).ToString();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            BigInteger num1 = BigInteger.Parse(textBox1.Text);
            BigInteger num2 = BigInteger.Parse(textBox2.Text);
            textBox3.Text = (num1 - num2).ToString();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            BigInteger num1 = BigInteger.Parse(textBox1.Text);
            BigInteger num2 = BigInteger.Parse(textBox2.Text);
            textBox3.Text = (num1 * num2).ToString();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            BigInteger num1 = BigInteger.Parse(textBox1.Text);
            BigInteger num2 = BigInteger.Parse(textBox2.Text);
            textBox3.Text = (num1 / num2).ToString();
        }
    }
}
