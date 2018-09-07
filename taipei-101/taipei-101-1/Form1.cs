using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace taipei_101_1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            double N1, N2, N3, N4;
            if (double.TryParse(textBox1.Text, out N1) &&
                double.TryParse(textBox2.Text, out N2) &&
                double.TryParse(textBox3.Text, out N3) &&
                double.TryParse(textBox4.Text, out N4) &&
                N3 != N4)
            {
                double p = (N2 + N3 - N1) / (-N2 - N4 + N1);
                double y = N1*(p+1) / p;
                double x = y*p;
                if (N1 % 1 != 0 || N2 % 1 != 0 || N3 % 1 != 0 || N4 % 1 != 0 ||
                     y % 1 != 0 || x % 1 != 0)
                    textBox5.Text = "無解";
                else
                    textBox5.Text = $"X:{x}, Y:{y}";
            }
            else
                MessageBox.Show("輸入不符合條件");
        }
    }
}
