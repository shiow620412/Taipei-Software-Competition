using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace taiper_106_4
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        int G = 34943;
        private void button1_Click(object sender, EventArgs e)
        {
            string input = textBox1.Text;

            int[] arr = Array.ConvertAll(input.ToCharArray(), x => Convert.ToInt32(x));
            string dividend = string.Join("", Array.ConvertAll(arr, x => Convert.ToString(x, 2).PadLeft(8, '0')));
            dividend += "".PadLeft(16, '0');
            int mod = 0;
            for(int i = 0; i<dividend.Length;i++)
            {
                mod <<= 1;
                mod += int.Parse(dividend.Substring(i, 1));
                if (mod >= G) mod -= G;
            }
            label1.Text = Convert.ToString(G - mod, 16).ToUpper();
        }
    }
}
