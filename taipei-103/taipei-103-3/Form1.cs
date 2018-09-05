using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace taipei_103_3
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int[] input1 = Array.ConvertAll(textBox2.Text.Split(','),s=>int.Parse(s));
            int[] input2 = Array.ConvertAll(textBox1.Text.Split(','),s=>int.Parse(s));
            int[,] output = new int[input1.Length, input2.Length];
            for(int i = 0; i < output.GetLength(0);i++)
            {
                for(int j =0; j< output.GetLength(1);j++)
                {
                    if (i == 0 && j == 0)
                        output[i, j] = Math.Abs(input1[i] - input2[j]);
                    else if (i == 0 && j > 0)
                        output[i, j] = Math.Abs(input1[i] - input2[j]) + output[0, j - 1];
                    else if (i > 0 && j == 0)
                        output[i, j] = Math.Abs(input1[i] - input2[j]) + output[i - 1, 0];
                    else
                        output[i, j] = Math.Abs(input1[i] - input2[j]) + Math.Min(Math.Min(output[i - 1, j] ,output[i, j - 1] ), output[i - 1, j - 1]);
                }
            }
            textBox3.Clear();
            textBox3.Text += "0\t";
            for (int i = 0; i < input2.Length; i++)
                textBox3.Text += input2[i] + "\t";
            textBox3.Text += "\r\n";
            for (int i = 0; i < output.GetLength(0); i++)
            {
                textBox3.Text += input1[i]+"\t";
                for (int j = 0; j < output.GetLength(1); j++)
                {
                    textBox3.Text += output[i, j]+ "\t";
                }
                textBox3.Text += "\r\n";
            }

        }
    }
}
